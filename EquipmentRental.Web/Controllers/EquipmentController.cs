//using EquipmentRental.Data.Data;
//using EquipmentRental.Data.Entities;
using EquipmentRental.Data.Helpers;
using EquipmentRental.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using rental_System_db.Data;
using rental_System_db.Entities;

namespace EquipmentRental.Web.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly RentalDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EquipmentController(RentalDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Equipment
        public async Task<IActionResult> Index(int? categoryId, string searchString, string sortOrder, string availabilityFilter)
        {
            // Set up ViewBag for sorting
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SearchString = searchString;
            ViewBag.CategoryId = categoryId;
            ViewBag.AvailabilityFilter = availabilityFilter;

            // Get user role for permissions
            string? userRole = HttpContext.Session.GetString("UserRole");
            ViewBag.IsStaff = userRole == "Administrator" || userRole == "RentalManager";

            // Get all equipment with their categories
            var equipmentQuery = _context.Equipment
                .Include(e => e.Category)
                .AsQueryable();

            // Apply filtering
            if (categoryId.HasValue)
            {
                equipmentQuery = equipmentQuery.Where(e => e.CategoryId == categoryId);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                equipmentQuery = equipmentQuery.Where(e =>
                    e.Name.Contains(searchString) ||
                    (e.Description != null && e.Description.Contains(searchString)));
            }

            if (!String.IsNullOrEmpty(availabilityFilter))
            {
                equipmentQuery = equipmentQuery.Where(e => e.AvailabilityStatus == availabilityFilter);
            }

            // Apply sorting
            switch (sortOrder)
            {
                case "name_desc":
                    equipmentQuery = equipmentQuery.OrderByDescending(e => e.Name);
                    break;
                case "price":
                    equipmentQuery = equipmentQuery.OrderBy(e => e.RentalPrice);
                    break;
                case "price_desc":
                    equipmentQuery = equipmentQuery.OrderByDescending(e => e.RentalPrice);
                    break;
                default: // Default sort by name ascending
                    equipmentQuery = equipmentQuery.OrderBy(e => e.Name);
                    break;
            }

            // Get categories for filter dropdown
            ViewBag.Categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();

            // Availability status options for filter
            ViewBag.AvailabilityOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "All" },
                new SelectListItem { Value = "Available", Text = "Available" },
                new SelectListItem { Value = "Unavailable", Text = "Unavailable" },
                new SelectListItem { Value = "UnderMaintenance", Text = "Under Maintenance" }
            };

            return View(await equipmentQuery.ToListAsync());
        }

        // GET: Equipment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.Category)
                .Include(e => e.Feedbacks)
                .ThenInclude(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipment/Create
        public async Task<IActionResult> Create()
        {
            // Check role - only staff can create equipment
            string? userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();

            return View();
        }

        // POST: Equipment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipmentFormViewModel viewModel)
        {
            // Check role - only staff can create equipment
            string? userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                string? imageUrl = null;

                // Process image upload if provided
                if (viewModel.ImageFile != null)
                {
                    // Generate a unique file name
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageFile.FileName);

                    // Set the file path
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "equipment");

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string filePath = Path.Combine(uploadsFolder, fileName);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the image URL
                    imageUrl = $"/uploads/equipment/{fileName}";
                }

                // Map view model to entity
                var equipment = new Equipment
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    CategoryId = viewModel.CategoryId,
                    RentalPrice = viewModel.RentalPrice,
                    AvailabilityStatus = viewModel.AvailabilityStatus,
                    ConditionStatus = viewModel.ConditionStatus,
                    DepositAmount = viewModel.DepositAmount,
                    ImageUrl = imageUrl,
                    CreatedAt = DateTime.Now
                };

                _context.Add(equipment);
                await _context.SaveChangesAsync();

                // Log the equipment creation
                int? userId = HttpContext.Session.GetInt32("UserId");
                if (userId.HasValue)
                {
                    await LogHelper.LogUserAction(
                        _context,
                        userId.Value,
                        "Equipment Created",
                        $"Equipment '{equipment.Name}' was created",
                        HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown"
                    );
                }

                return RedirectToAction(nameof(Index));
            }

            // If we got this far, something failed, redisplay form
            ViewBag.Categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();

            return View(viewModel);
        }

        // GET: Equipment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Check role - only staff can edit equipment
            string? userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            // Map entity to view model
            var viewModel = new EquipmentFormViewModel
            {
                Id = equipment.Id,
                Name = equipment.Name,
                Description = equipment.Description,
                CategoryId = equipment.CategoryId,
                RentalPrice = equipment.RentalPrice,
                AvailabilityStatus = equipment.AvailabilityStatus,
                ConditionStatus = equipment.ConditionStatus,
                DepositAmount = equipment.DepositAmount,
                ExistingImageUrl = equipment.ImageUrl
            };

            ViewBag.Categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();

            return View(viewModel);
        }

        // POST: Equipment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EquipmentFormViewModel viewModel)
        {
            // Check role - only staff can edit equipment
            string? userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Get the existing equipment to preserve certain properties
                    var equipment = await _context.Equipment.FindAsync(id);
                    if (equipment == null)
                    {
                        return NotFound();
                    }

                    // Process image upload if a new image is provided
                    if (viewModel.ImageFile != null)
                    {
                        // Generate a unique file name
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageFile.FileName);

                        // Set the file path
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "equipment");

                        // Create directory if it doesn't exist
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        string filePath = Path.Combine(uploadsFolder, fileName);

                        // Save the file
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await viewModel.ImageFile.CopyToAsync(fileStream);
                        }

                        // Delete the old image if exists
                        if (!string.IsNullOrEmpty(equipment.ImageUrl))
                        {
                            string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, equipment.ImageUrl.TrimStart('/'));
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        // Set the new image URL
                        equipment.ImageUrl = $"/uploads/equipment/{fileName}";
                    }
                    else if (viewModel.DeleteExistingImage && !string.IsNullOrEmpty(equipment.ImageUrl))
                    {
                        // Delete the existing image if requested
                        string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, equipment.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                        equipment.ImageUrl = null;
                    }

                    // Update equipment properties
                    equipment.Name = viewModel.Name;
                    equipment.Description = viewModel.Description;
                    equipment.CategoryId = viewModel.CategoryId;
                    equipment.RentalPrice = viewModel.RentalPrice;
                    equipment.AvailabilityStatus = viewModel.AvailabilityStatus;
                    equipment.ConditionStatus = viewModel.ConditionStatus;
                    equipment.DepositAmount = viewModel.DepositAmount;

                    _context.Update(equipment);
                    await _context.SaveChangesAsync();

                    // Log the equipment update
                    int? userId = HttpContext.Session.GetInt32("UserId");
                    if (userId.HasValue)
                    {
                        await LogHelper.LogUserAction(
                            _context,
                            userId.Value,
                            "Equipment Updated",
                            $"Equipment '{equipment.Name}' was updated",
                            HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown"
                        );
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // If we got this far, something failed, redisplay form
            ViewBag.Categories = await _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();

            return View(viewModel);
        }

        // GET: Equipment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // Check role - only Administrator can delete equipment
            string? userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            // Check if equipment has any rental requests or transactions
            int requestCount = await _context.RentalRequests.CountAsync(r => r.EquipmentId == id);
            int transactionCount = await _context.RentalTransactions.CountAsync(t => t.EquipmentId == id);

            ViewBag.HasRentalRequests = requestCount > 0;
            ViewBag.HasRentalTransactions = transactionCount > 0;
            ViewBag.RequestCount = requestCount;
            ViewBag.TransactionCount = transactionCount;

            return View(equipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Check role - only Administrator can delete equipment
            string? userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            // Check if equipment has any rental requests or transactions
            int requestCount = await _context.RentalRequests.CountAsync(r => r.EquipmentId == id);
            int transactionCount = await _context.RentalTransactions.CountAsync(t => t.EquipmentId == id);

            if (requestCount > 0 || transactionCount > 0)
            {
                TempData["ErrorMessage"] = $"Cannot delete equipment. It has {requestCount} rental requests and {transactionCount} transactions.";
                return RedirectToAction(nameof(Index));
            }

            // Delete the image file if exists
            if (!string.IsNullOrEmpty(equipment.ImageUrl))
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, equipment.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();

            // Log the equipment deletion
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                await LogHelper.LogUserAction(
                    _context,
                    userId.Value,
                    "Equipment Deleted",
                    $"Equipment '{equipment.Name}' was deleted",
                    HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown"
                );
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipment.Any(e => e.Id == id);
        }
    }
}