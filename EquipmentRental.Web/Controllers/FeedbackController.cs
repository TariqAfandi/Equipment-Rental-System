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

namespace EquipmentRental.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly RentalDBContext _context;

        public FeedbackController(RentalDBContext context)
        {
            _context = context;
        }

        // GET: Feedback
        public async Task<IActionResult> Index(int? equipmentId)
        {
            ViewBag.EquipmentId = equipmentId;

            // If equipment ID is provided, show feedback for that equipment only
            var feedbackQuery = _context.Feedbacks
                .Include(f => f.User)
                .Include(f => f.Equipment)
                .Where(f => f.IsVisible) // Only show visible feedback
                .AsQueryable();

            if (equipmentId.HasValue)
            {
                feedbackQuery = feedbackQuery.Where(f => f.EquipmentId == equipmentId);
                var equipment = await _context.Equipment.FindAsync(equipmentId);
                if (equipment != null)
                {
                    ViewBag.EquipmentName = equipment.Name;
                }
            }

            // Order by feedback date descending (newest first)
            feedbackQuery = feedbackQuery.OrderByDescending(f => f.FeedbackDate);

            return View(await feedbackQuery.ToListAsync());
        }

        // GET: Feedback/Create
        public async Task<IActionResult> Create(int? equipmentId, int? transactionId)
        {
            // Check if user is logged in
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = new FeedbackViewModel
            {
                Rating = 5 // Default rating
            };

            // If transaction ID is provided, pre-fill equipment details
            if (transactionId.HasValue)
            {
                var transaction = await _context.RentalTransactions
                    .Include(t => t.Equipment)
                    .FirstOrDefaultAsync(t => t.Id == transactionId && t.UserId == userId);

                if (transaction != null)
                {
                    // Check if user has already provided feedback for this transaction
                    var existingFeedback = await _context.Feedbacks
                        .FirstOrDefaultAsync(f => f.RentalTransactionId == transactionId);

                    if (existingFeedback != null)
                    {
                        TempData["ErrorMessage"] = "You have already provided feedback for this rental.";
                        return RedirectToAction("Details", "RentalTransaction", new { id = transactionId });
                    }

                    viewModel.EquipmentId = transaction.EquipmentId;
                    viewModel.EquipmentName = transaction.Equipment.Name;
                    viewModel.RentalTransactionId = transaction.Id;
                    ViewBag.SelectedEquipment = true;
                }
                else
                {
                    return NotFound();
                }
            }
            // If equipment ID is provided, pre-fill equipment details
            else if (equipmentId.HasValue)
            {
                var equipment = await _context.Equipment
                    .FirstOrDefaultAsync(e => e.Id == equipmentId);

                if (equipment != null)
                {
                    // Check if user has rented this equipment before
                    var userTransactions = await _context.RentalTransactions
                        .AnyAsync(t => t.EquipmentId == equipmentId && t.UserId == userId && t.Status == "Completed");

                    if (!userTransactions)
                    {
                        TempData["ErrorMessage"] = "You can only provide feedback for equipment you have rented.";
                        return RedirectToAction("Details", "Equipment", new { id = equipmentId });
                    }

                    viewModel.EquipmentId = equipment.Id;
                    viewModel.EquipmentName = equipment.Name;
                    ViewBag.SelectedEquipment = true;
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                // No equipment or transaction specified, show equipment selection list
                // Only show equipment the user has rented before
                var userCompletedRentals = await _context.RentalTransactions
                    .Where(t => t.UserId == userId && t.Status == "Completed")
                    .Select(t => t.EquipmentId)
                    .Distinct()
                    .ToListAsync();

                var rentedEquipment = await _context.Equipment
                    .Where(e => userCompletedRentals.Contains(e.Id))
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name
                    })
                    .ToListAsync();

                if (rentedEquipment.Count == 0)
                {
                    TempData["ErrorMessage"] = "You haven't rented any equipment yet.";
                    return RedirectToAction("Index", "Equipment");
                }

                ViewBag.Equipment = rentedEquipment;
                ViewBag.SelectedEquipment = false;
            }

            return View(viewModel);
        }

        // POST: Feedback/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeedbackViewModel viewModel)
        {
            // Check if user is logged in
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                // Verify the equipment exists
                var equipment = await _context.Equipment
                    .FirstOrDefaultAsync(e => e.Id == viewModel.EquipmentId);

                if (equipment == null)
                {
                    return NotFound("Equipment not found.");
                }

                // Verify the user has rented this equipment before
                var hasRented = await _context.RentalTransactions
                    .AnyAsync(t => t.EquipmentId == viewModel.EquipmentId && t.UserId == userId && t.Status == "Completed");

                if (!hasRented)
                {
                    TempData["ErrorMessage"] = "You can only provide feedback for equipment you have rented.";
                    return RedirectToAction("Details", "Equipment", new { id = viewModel.EquipmentId });
                }

                // If transaction ID is provided, verify it
                if (viewModel.RentalTransactionId.HasValue)
                {
                    var transaction = await _context.RentalTransactions
                        .FirstOrDefaultAsync(t => t.Id == viewModel.RentalTransactionId && t.UserId == userId);

                    if (transaction == null)
                    {
                        return NotFound("Transaction not found.");
                    }

                    // Check if user has already provided feedback for this transaction
                    var existingFeedback = await _context.Feedbacks
                        .FirstOrDefaultAsync(f => f.RentalTransactionId == viewModel.RentalTransactionId);

                    if (existingFeedback != null)
                    {
                        TempData["ErrorMessage"] = "You have already provided feedback for this rental.";
                        return RedirectToAction("Details", "RentalTransaction", new { id = viewModel.RentalTransactionId });
                    }
                }

                // Create new feedback
                var feedback = new Feedback
                {
                    UserId = userId.Value,
                    EquipmentId = viewModel.EquipmentId,
                    RentalTransactionId = viewModel.RentalTransactionId,
                    Rating = viewModel.Rating,
                    Comment = viewModel.Comment,
                    FeedbackDate = DateTime.Now,
                    IsVisible = true // Default to visible
                };

                _context.Add(feedback);
                await _context.SaveChangesAsync();

                // Log the feedback
                await LogHelper.LogUserAction(
                    _context,
                    userId.Value,
                    "Feedback Submitted",
                    $"Feedback submitted for equipment: {equipment.Name}, Rating: {viewModel.Rating}",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                TempData["SuccessMessage"] = "Thank you for your feedback!";
                return RedirectToAction(nameof(Index), new { equipmentId = viewModel.EquipmentId });
            }

            // If validation fails, repopulate the view model
            if (viewModel.EquipmentId > 0)
            {
                var equipment = await _context.Equipment.FindAsync(viewModel.EquipmentId);
                if (equipment != null)
                {
                    viewModel.EquipmentName = equipment.Name;
                    ViewBag.SelectedEquipment = true;
                }
            }
            else
            {
                // Get equipment selection list
                var userCompletedRentals = await _context.RentalTransactions
                    .Where(t => t.UserId == userId && t.Status == "Completed")
                    .Select(t => t.EquipmentId)
                    .Distinct()
                    .ToListAsync();

                var rentedEquipment = await _context.Equipment
                    .Where(e => userCompletedRentals.Contains(e.Id))
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name
                    })
                    .ToListAsync();

                ViewBag.Equipment = rentedEquipment;
                ViewBag.SelectedEquipment = false;
            }

            return View(viewModel);
        }

        // GET: Feedback/Manage
        public async Task<IActionResult> Manage()
        {
            // Check role - only staff can manage all feedback
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            var feedback = await _context.Feedbacks
                .Include(f => f.User)
                .Include(f => f.Equipment)
                .OrderByDescending(f => f.FeedbackDate)
                .ToListAsync();

            return View(feedback);
        }

        // POST: Feedback/ToggleVisibility/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleVisibility(int id)
        {
            // Check role - only staff can manage feedback visibility
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            // Toggle visibility
            feedback.IsVisible = !feedback.IsVisible;
            _context.Update(feedback);
            await _context.SaveChangesAsync();

            // Log the action
            int userId = HttpContext.Session.GetInt32("UserId").Value;
            await LogHelper.LogUserAction(
                _context,
                userId,
                "Feedback Visibility Changed",
                $"Feedback ID {feedback.Id} visibility changed to {feedback.IsVisible}",
                HttpContext.Connection.RemoteIpAddress?.ToString()
            );

            return RedirectToAction(nameof(Manage));
        }
    }
}