//using EquipmentRental.Data.Data;
//using EquipmentRental.Data.Entities;
using EquipmentRental.Data.Helpers;
using EquipmentRental.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using rental_System_db.Data;
using rental_System_db.Entities;
//using rental_System_db.Helpers;

namespace EquipmentRental.Web.Controllers
{
    public class RentalRequestController : Controller
    {
        private readonly RentalDBContext _context;

        public RentalRequestController(RentalDBContext context)
        {
            _context = context;
        }

        // GET: RentalRequest
        public async Task<IActionResult> Index(string searchString, string statusFilter, DateTime? startDate, DateTime? endDate)
        {
            // Check role - only staff can view all rental requests
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("MyRequests");
            }

            ViewBag.SearchString = searchString;
            ViewBag.StatusFilter = statusFilter;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            var requestsQuery = _context.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .ThenInclude(e => e.Category)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(searchString))
            {
                requestsQuery = requestsQuery.Where(r =>
                    r.Equipment.Name.Contains(searchString) ||
                    r.User.Name.Contains(searchString) ||
                    r.User.Email.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                requestsQuery = requestsQuery.Where(r => r.Status == statusFilter);
            }

            if (startDate.HasValue)
            {
                requestsQuery = requestsQuery.Where(r => r.RentalStartDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                requestsQuery = requestsQuery.Where(r => r.RentalEndDate <= endDate.Value);
            }

            // Order by request date descending (newest first)
            requestsQuery = requestsQuery.OrderByDescending(r => r.RequestDate);

            // Status filter options
            ViewBag.StatusOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "All" },
                new SelectListItem { Value = "Pending", Text = "Pending" },
                new SelectListItem { Value = "Approved", Text = "Approved" },
                new SelectListItem { Value = "Rejected", Text = "Rejected" },
                new SelectListItem { Value = "Completed", Text = "Completed" },
                new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
            };

            return View(await requestsQuery.ToListAsync());
        }

        // GET: RentalRequest/MyRequests
        public async Task<IActionResult> MyRequests()
        {
            // Get user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var requests = await _context.RentalRequests
                .Include(r => r.Equipment)
                .ThenInclude(e => e.Category)
                .Where(r => r.UserId == userId.Value)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();

            return View(requests);
        }

        // GET: RentalRequest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRequest = await _context.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .ThenInclude(e => e.Category)
                .Include(r => r.ProcessedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rentalRequest == null)
            {
                return NotFound();
            }

            // Check if user has permission to view this request
            int? userId = HttpContext.Session.GetInt32("UserId");
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            if (!isStaff && rentalRequest.UserId != userId)
            {
                return Forbid();
            }

            // Check if a transaction exists for this request
            var transaction = await _context.RentalTransactions
                .FirstOrDefaultAsync(t => t.RentalRequestId == id);

            ViewBag.HasTransaction = transaction != null;
            ViewBag.TransactionId = transaction?.Id;

            return View(rentalRequest);
        }

        // GET: RentalRequest/Create
        public async Task<IActionResult> Create(int? equipmentId)
        {
            // Check if user is logged in
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = new RentalRequestViewModel
            {
                RequestDate = DateTime.Now,
                RentalStartDate = DateTime.Now.AddDays(1),
                RentalEndDate = DateTime.Now.AddDays(7)
            };

            if (equipmentId.HasValue)
            {
                var equipment = await _context.Equipment
                    .Include(e => e.Category)
                    .FirstOrDefaultAsync(e => e.Id == equipmentId);

                if (equipment == null)
                {
                    return NotFound();
                }

                if (equipment.AvailabilityStatus != "Available")
                {
                    TempData["ErrorMessage"] = "This equipment is not available for rental.";
                    return RedirectToAction("Details", "Equipment", new { id = equipmentId });
                }

                viewModel.EquipmentId = equipment.Id;
                viewModel.EquipmentName = equipment.Name;
                viewModel.EquipmentImageUrl = equipment.ImageUrl;
                viewModel.CategoryName = equipment.Category.Name;
                viewModel.RentalPrice = equipment.RentalPrice;

                ViewBag.SelectedEquipment = true;
            }
            else
            {
                ViewBag.SelectedEquipment = false;
                ViewBag.Equipment = await _context.Equipment
                    .Where(e => e.AvailabilityStatus == "Available")
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name
                    })
                    .ToListAsync();
            }

            return View(viewModel);
        }

        // POST: RentalRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalRequestViewModel viewModel)
        {
            // Check if user is logged in
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                // Get equipment details
                var equipment = await _context.Equipment
                    .FirstOrDefaultAsync(e => e.Id == viewModel.EquipmentId);

                if (equipment == null)
                {
                    return NotFound();
                }

                if (equipment.AvailabilityStatus != "Available")
                {
                    TempData["ErrorMessage"] = "This equipment is not available for rental.";
                    return RedirectToAction("Index", "Equipment");
                }

                // Check if rental dates are valid
                if (viewModel.RentalStartDate < DateTime.Now.Date)
                {
                    ModelState.AddModelError("RentalStartDate", "Rental start date cannot be in the past.");
                    ViewBag.Equipment = await GetAvailableEquipmentSelectListAsync();
                    return View(viewModel);
                }

                if (viewModel.RentalEndDate < viewModel.RentalStartDate)
                {
                    ModelState.AddModelError("RentalEndDate", "Rental end date must be after the start date.");
                    ViewBag.Equipment = await GetAvailableEquipmentSelectListAsync();
                    return View(viewModel);
                }

                // Check for overlapping rental requests that are approved
                var overlappingRequests = await _context.RentalRequests
                    .Where(r => r.EquipmentId == viewModel.EquipmentId
                        && r.Status == "Approved"
                        && ((r.RentalStartDate <= viewModel.RentalEndDate && r.RentalEndDate >= viewModel.RentalStartDate)
                            || (r.RentalStartDate >= viewModel.RentalStartDate && r.RentalStartDate <= viewModel.RentalEndDate)))
                    .AnyAsync();

                if (overlappingRequests)
                {
                    ModelState.AddModelError("", "This equipment is already booked for the selected dates.");
                    ViewBag.Equipment = await GetAvailableEquipmentSelectListAsync();
                    return View(viewModel);
                }

                // Calculate rental duration and estimated cost
                TimeSpan rentalDuration = viewModel.RentalEndDate.Subtract(viewModel.RentalStartDate);
                int rentalDays = rentalDuration.Days + 1; // Include both start and end days
                decimal totalCost = equipment.RentalPrice * rentalDays;

                // Create new rental request
                var rentalRequest = new RentalRequest
                {
                    UserId = userId.Value,
                    EquipmentId = viewModel.EquipmentId,
                    RequestDate = DateTime.Now,
                    RentalStartDate = viewModel.RentalStartDate,
                    RentalEndDate = viewModel.RentalEndDate,
                    Status = "Pending",
                    Notes = viewModel.Notes,
                    TotalCost = totalCost
                };

                _context.Add(rentalRequest);
                await _context.SaveChangesAsync();

                // Create notification for the user
                await NotificationHelper.CreateRentalRequestNotification(_context, rentalRequest, "Created");

                // Log the request creation
                await LogHelper.LogUserAction(
                    _context,
                    userId.Value,
                    "Rental Request Created",
                    $"Rental request created for equipment: {equipment.Name}",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                TempData["SuccessMessage"] = "Rental request submitted successfully.";
                return RedirectToAction(nameof(MyRequests));
            }

            ViewBag.Equipment = await GetAvailableEquipmentSelectListAsync();
            return View(viewModel);
        }

        // GET: RentalRequest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRequest = await _context.RentalRequests
                .Include(r => r.Equipment)
                .ThenInclude(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rentalRequest == null)
            {
                return NotFound();
            }

            // Check if user has permission to edit this request
            int? userId = HttpContext.Session.GetInt32("UserId");
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            if (!isStaff && rentalRequest.UserId != userId)
            {
                return Forbid();
            }

            // Only allow edits for pending requests
            if (rentalRequest.Status != "Pending")
            {
                TempData["ErrorMessage"] = "Only pending requests can be edited.";
                return RedirectToAction(nameof(Details), new { id });
            }

            var viewModel = new RentalRequestViewModel
            {
                Id = rentalRequest.Id,
                EquipmentId = rentalRequest.EquipmentId,
                EquipmentName = rentalRequest.Equipment.Name,
                EquipmentImageUrl = rentalRequest.Equipment.ImageUrl,
                CategoryName = rentalRequest.Equipment.Category.Name,
                RequestDate = rentalRequest.RequestDate,
                RentalStartDate = rentalRequest.RentalStartDate,
                RentalEndDate = rentalRequest.RentalEndDate,
                Status = rentalRequest.Status,
                Notes = rentalRequest.Notes,
                RentalPrice = rentalRequest.Equipment.RentalPrice,
                TotalCost = rentalRequest.TotalCost
            };

            ViewBag.IsStaff = isStaff;

            if (isStaff)
            {
                ViewBag.StatusOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Pending", Text = "Pending" },
                    new SelectListItem { Value = "Approved", Text = "Approved" },
                    new SelectListItem { Value = "Rejected", Text = "Rejected" },
                    new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
                };
            }

            return View(viewModel);
        }

        // POST: RentalRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RentalRequestViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            // Check if user has permission to edit this request
            int? userId = HttpContext.Session.GetInt32("UserId");
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            var rentalRequest = await _context.RentalRequests
                .Include(r => r.Equipment)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rentalRequest == null)
            {
                return NotFound();
            }

            if (!isStaff && rentalRequest.UserId != userId)
            {
                return Forbid();
            }

            // Only allow edits for pending requests
            if (rentalRequest.Status != "Pending")
            {
                TempData["ErrorMessage"] = "Only pending requests can be edited.";
                return RedirectToAction(nameof(Details), new { id });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Store original status to check if it changed
                    string originalStatus = rentalRequest.Status;

                    // Update allowed properties based on role
                    if (isStaff)
                    {
                        // Staff can update all properties
                        rentalRequest.RentalStartDate = viewModel.RentalStartDate;
                        rentalRequest.RentalEndDate = viewModel.RentalEndDate;
                        rentalRequest.Status = viewModel.Status;
                        rentalRequest.Notes = viewModel.Notes;

                        // Calculate rental duration and cost
                        TimeSpan rentalDuration = viewModel.RentalEndDate.Subtract(viewModel.RentalStartDate);
                        int rentalDays = rentalDuration.Days + 1; // Include both start and end days
                        rentalRequest.TotalCost = rentalRequest.Equipment.RentalPrice * rentalDays;

                        // If request was approved, update process information
                        if (originalStatus != "Approved" && viewModel.Status == "Approved")
                        {
                            rentalRequest.ProcessedByUserId = userId;
                            rentalRequest.ProcessedDate = DateTime.Now;
                        }
                    }
                    else
                    {
                        // Customer can only update dates and notes
                        rentalRequest.RentalStartDate = viewModel.RentalStartDate;
                        rentalRequest.RentalEndDate = viewModel.RentalEndDate;
                        rentalRequest.Notes = viewModel.Notes;

                        // Calculate rental duration and cost
                        TimeSpan rentalDuration = viewModel.RentalEndDate.Subtract(viewModel.RentalStartDate);
                        int rentalDays = rentalDuration.Days + 1; // Include both start and end days
                        rentalRequest.TotalCost = rentalRequest.Equipment.RentalPrice * rentalDays;
                    }

                    _context.Update(rentalRequest);
                    await _context.SaveChangesAsync();

                    // If status changed, create notification
                    if (originalStatus != rentalRequest.Status)
                    {
                        // Determine notification type based on status
                        string action = string.Empty;
                        switch (rentalRequest.Status)
                        {
                            case "Approved":
                                action = "Approved";
                                break;
                            case "Rejected":
                                action = "Rejected";
                                break;
                            case "Cancelled":
                                action = "Updated";
                                break;
                            default:
                                action = "Updated";
                                break;
                        }

                        await NotificationHelper.CreateRentalRequestNotification(_context, rentalRequest, action);

                        // If approved, set equipment to Unavailable
                        if (rentalRequest.Status == "Approved")
                        {
                            var equipment = await _context.Equipment.FindAsync(rentalRequest.EquipmentId);
                            if (equipment != null)
                            {
                                equipment.AvailabilityStatus = "Reserved";
                                _context.Update(equipment);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                    // Log the update
                    await LogHelper.LogUserAction(
                        _context,
                        userId.Value,
                        "Rental Request Updated",
                        $"Rental request ID {rentalRequest.Id} updated. Status: {rentalRequest.Status}",
                        HttpContext.Connection.RemoteIpAddress?.ToString()
                    );

                    TempData["SuccessMessage"] = "Rental request updated successfully.";
                    return RedirectToAction(nameof(Details), new { id = rentalRequest.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalRequestExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.IsStaff = isStaff;

            if (isStaff)
            {
                ViewBag.StatusOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Pending", Text = "Pending" },
                    new SelectListItem { Value = "Approved", Text = "Approved" },
                    new SelectListItem { Value = "Rejected", Text = "Rejected" },
                    new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
                };
            }

            return View(viewModel);
        }

        // GET: RentalRequest/Cancel/5
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRequest = await _context.RentalRequests
                .Include(r => r.Equipment)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rentalRequest == null)
            {
                return NotFound();
            }

            // Check if user has permission to cancel this request
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (rentalRequest.UserId != userId)
            {
                return Forbid();
            }

            // Only allow cancellation for pending requests
            if (rentalRequest.Status != "Pending")
            {
                TempData["ErrorMessage"] = "Only pending requests can be cancelled.";
                return RedirectToAction(nameof(Details), new { id });
            }

            return View(rentalRequest);
        }

        // POST: RentalRequest/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            var rentalRequest = await _context.RentalRequests.FindAsync(id);
            if (rentalRequest == null)
            {
                return NotFound();
            }

            // Check if user has permission to cancel this request
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (rentalRequest.UserId != userId)
            {
                return Forbid();
            }

            // Only allow cancellation for pending requests
            if (rentalRequest.Status != "Pending")
            {
                TempData["ErrorMessage"] = "Only pending requests can be cancelled.";
                return RedirectToAction(nameof(Details), new { id });
            }

            // Update request status
            rentalRequest.Status = "Cancelled";
            _context.Update(rentalRequest);
            await _context.SaveChangesAsync();

            // Create notification
            await NotificationHelper.CreateRentalRequestNotification(_context, rentalRequest, "Updated");

            // Log the cancellation
            await LogHelper.LogUserAction(
                _context,
                userId.Value,
                "Rental Request Cancelled",
                $"Rental request ID {rentalRequest.Id} cancelled by user",
                HttpContext.Connection.RemoteIpAddress?.ToString()
            );

            TempData["SuccessMessage"] = "Rental request cancelled successfully.";
            return RedirectToAction(nameof(MyRequests));
        }

        private bool RentalRequestExists(int id)
        {
            return _context.RentalRequests.Any(e => e.Id == id);
        }

        private async Task<IEnumerable<SelectListItem>> GetAvailableEquipmentSelectListAsync()
        {
            return await _context.Equipment
                .Where(e => e.AvailabilityStatus == "Available")
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                })
                .ToListAsync();
        }
    }
}