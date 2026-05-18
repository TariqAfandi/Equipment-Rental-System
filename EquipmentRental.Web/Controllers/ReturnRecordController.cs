//using EquipmentRental.Data.Data;
//using EquipmentRental.Data.Entities;
using EquipmentRental.Data.Helpers;
using EquipmentRental.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using rental_System_db.Data;
using rental_System_db.Entities;

namespace EquipmentRental.Web.Controllers
{
    public class ReturnRecordController : Controller
    {
        private readonly RentalDBContext _context;

        public ReturnRecordController(RentalDBContext context)
        {
            _context = context;
        }

        // GET: ReturnRecord
        public async Task<IActionResult> Index(string searchString, string conditionFilter)
        {
            // Check role - only staff can view all return records
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.SearchString = searchString;
            ViewBag.ConditionFilter = conditionFilter;

            var returnsQuery = _context.ReturnRecords
                .Include(r => r.RentalTransaction)
                .ThenInclude(t => t.Equipment)
                .Include(r => r.RentalTransaction.User)
                .Include(r => r.ProcessedByUser)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(searchString))
            {
                returnsQuery = returnsQuery.Where(r =>
                    r.RentalTransaction.Equipment.Name.Contains(searchString) ||
                    r.RentalTransaction.User.Name.Contains(searchString) ||
                    r.ProcessedByUser.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(conditionFilter))
            {
                returnsQuery = returnsQuery.Where(r => r.ReturnCondition == conditionFilter);
            }

            // Order by return date descending (newest first)
            returnsQuery = returnsQuery.OrderByDescending(r => r.ReturnDate);

            ViewBag.ConditionOptions = new List<string> { "Good", "Damaged", "Lost" };

            return View(await returnsQuery.ToListAsync());
        }

        // GET: ReturnRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnRecord = await _context.ReturnRecords
                .Include(r => r.RentalTransaction)
                .ThenInclude(t => t.Equipment)
                .Include(r => r.RentalTransaction.User)
                .Include(r => r.ProcessedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (returnRecord == null)
            {
                return NotFound();
            }

            // Check if user has permission to view this record
            int? userId = HttpContext.Session.GetInt32("UserId");
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            if (!isStaff && returnRecord.RentalTransaction.UserId != userId)
            {
                return Forbid();
            }

            return View(returnRecord);
        }

        // GET: ReturnRecord/Create/5 (transactionId)
        public async Task<IActionResult> Create(int? id)
        {
            // Check role - only staff can create return records
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.RentalTransactions
                .Include(t => t.Equipment)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null)
            {
                return NotFound();
            }

            // Check if transaction is active
            if (transaction.Status != "Active" && transaction.Status != "Overdue")
            {
                TempData["ErrorMessage"] = "Only active or overdue rentals can be processed for return.";
                return RedirectToAction("Details", "RentalTransaction", new { id });
            }

            // Check if a return record already exists
            var existingReturn = await _context.ReturnRecords
                .FirstOrDefaultAsync(r => r.RentalTransactionId == id);

            if (existingReturn != null)
            {
                TempData["ErrorMessage"] = "A return record already exists for this transaction.";
                return RedirectToAction("Details", "ReturnRecord", new { id = existingReturn.Id });
            }

            // Calculate late fee (if applicable)
            decimal lateFee = 0;
            if (DateTime.Now > transaction.ExpectedReturnDate)
            {
                int daysLate = (int)(DateTime.Now - transaction.ExpectedReturnDate).TotalDays;
                if (daysLate > 0)
                {
                    // Late fee is 10% of rental fee per day late
                    lateFee = transaction.RentalFee * 0.1m * daysLate;
                }
            }

            // Create view model
            var viewModel = new ProcessReturnViewModel
            {
                RentalTransactionId = transaction.Id,
                ReturnDate = DateTime.Now,
                ReturnCondition = "Good",
                LateFee = lateFee,
                DamageFee = 0,
                RefundAmount = transaction.DepositAmount,
                ProcessedByUserId = HttpContext.Session.GetInt32("UserId").Value,

                // Additional display info
                EquipmentName = transaction.Equipment.Name,
                CustomerName = transaction.User.Name,
                RentalStartDate = transaction.ActualStartDate,
                ExpectedReturnDate = transaction.ExpectedReturnDate,
                DepositAmount = transaction.DepositAmount
            };

            return View(viewModel);
        }

        // POST: ReturnRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessReturnViewModel viewModel)
        {
            // Check role - only staff can create return records
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // Verify the transaction
                var transaction = await _context.RentalTransactions
                    .Include(t => t.Equipment)
                    .FirstOrDefaultAsync(t => t.Id == viewModel.RentalTransactionId);

                if (transaction == null)
                {
                    return NotFound("Transaction not found.");
                }

                // Check if transaction is active
                if (transaction.Status != "Active" && transaction.Status != "Overdue")
                {
                    TempData["ErrorMessage"] = "Only active or overdue rentals can be processed for return.";
                    return RedirectToAction("Details", "RentalTransaction", new { id = viewModel.RentalTransactionId });
                }

                // Check if a return record already exists
                var existingReturn = await _context.ReturnRecords
                    .FirstOrDefaultAsync(r => r.RentalTransactionId == viewModel.RentalTransactionId);

                if (existingReturn != null)
                {
                    TempData["ErrorMessage"] = "A return record already exists for this transaction.";
                    return RedirectToAction("Details", "ReturnRecord", new { id = existingReturn.Id });
                }

                // Calculate refund amount (deposit - damage fee)
                decimal refundAmount = (transaction.DepositAmount ?? 0) - (viewModel.DamageFee ?? 0);
                if (refundAmount < 0) refundAmount = 0;

                // Create new return record
                var returnRecord = new ReturnRecord
                {
                    RentalTransactionId = viewModel.RentalTransactionId,
                    ReturnDate = viewModel.ReturnDate,
                    ReturnCondition = viewModel.ReturnCondition,
                    LateFee = viewModel.LateFee,
                    DamageFee = viewModel.DamageFee,
                    RefundAmount = refundAmount,
                    ProcessedByUserId = viewModel.ProcessedByUserId,
                    Notes = viewModel.Notes
                };

                _context.Add(returnRecord);

                // Update transaction status and return date
                transaction.Status = "Completed";
                transaction.ActualReturnDate = viewModel.ReturnDate;
                _context.Update(transaction);

                // Update equipment status based on condition
                var equipment = await _context.Equipment.FindAsync(transaction.EquipmentId);
                if (equipment != null)
                {
                    if (viewModel.ReturnCondition == "Good")
                    {
                        equipment.AvailabilityStatus = "Available";
                    }
                    else if (viewModel.ReturnCondition == "Damaged")
                    {
                        equipment.AvailabilityStatus = "UnderMaintenance";
                        equipment.ConditionStatus = "Damaged";
                    }
                    else if (viewModel.ReturnCondition == "Lost")
                    {
                        equipment.AvailabilityStatus = "Unavailable";
                        equipment.ConditionStatus = "Lost";
                    }

                    _context.Update(equipment);
                }

                await _context.SaveChangesAsync();

                // Create notification for the user
                await NotificationHelper.CreateNotification(
                    _context,
                    transaction.UserId,
                    "Equipment Returned",
                    $"Your rental for {equipment.Name} has been processed as returned. Condition: {viewModel.ReturnCondition}",
                    "Return"
                );

                // Log the return
                int userId = HttpContext.Session.GetInt32("UserId").Value;
                await LogHelper.LogUserAction(
                    _context,
                    userId,
                    "Return Processed",
                    $"Return processed for equipment: {equipment.Name}, Condition: {viewModel.ReturnCondition}",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                TempData["SuccessMessage"] = "Return processed successfully.";
                return RedirectToAction(nameof(Details), new { id = returnRecord.Id });
            }

            // If validation fails, repopulate the view model with additional info
            var rentalTransaction = await _context.RentalTransactions
                .Include(t => t.Equipment)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == viewModel.RentalTransactionId);

            if (rentalTransaction != null)
            {
                viewModel.EquipmentName = rentalTransaction.Equipment.Name;
                viewModel.CustomerName = rentalTransaction.User.Name;
                viewModel.RentalStartDate = rentalTransaction.ActualStartDate;
                viewModel.ExpectedReturnDate = rentalTransaction.ExpectedReturnDate;
                viewModel.DepositAmount = rentalTransaction.DepositAmount;
            }

            return View(viewModel);
        }

        private bool ReturnRecordExists(int id)
        {
            return _context.ReturnRecords.Any(e => e.Id == id);
        }
    }
}