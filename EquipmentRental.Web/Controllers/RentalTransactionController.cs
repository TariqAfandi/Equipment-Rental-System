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
    public class RentalTransactionController : Controller
    {
        private readonly RentalDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RentalTransactionController(RentalDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: RentalTransaction
        public async Task<IActionResult> Index(string searchString, string statusFilter)
        {
            // Check role - only staff can view all transactions
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("MyRentals");
            }

            ViewBag.SearchString = searchString;
            ViewBag.StatusFilter = statusFilter;

            var transactionsQuery = _context.RentalTransactions
                .Include(t => t.RentalRequest)
                .Include(t => t.User)
                .Include(t => t.Equipment)
                .ThenInclude(e => e.Category)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(searchString))
            {
                transactionsQuery = transactionsQuery.Where(t =>
                    t.Equipment.Name.Contains(searchString) ||
                    t.User.Name.Contains(searchString) ||
                    t.User.Email.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                transactionsQuery = transactionsQuery.Where(t => t.Status == statusFilter);
            }

            // Order by transaction date descending (newest first)
            transactionsQuery = transactionsQuery.OrderByDescending(t => t.TransactionDate);

            // Status filter options
            ViewBag.StatusOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "All" },
                new SelectListItem { Value = "Active", Text = "Active" },
                new SelectListItem { Value = "Completed", Text = "Completed" },
                new SelectListItem { Value = "Overdue", Text = "Overdue" },
                new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
            };

            return View(await transactionsQuery.ToListAsync());
        }

        // GET: RentalTransaction/MyRentals
        public async Task<IActionResult> MyRentals()
        {
            // Get user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var transactions = await _context.RentalTransactions
                .Include(t => t.Equipment)
                .ThenInclude(e => e.Category)
                .Where(t => t.UserId == userId.Value)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();

            return View(transactions);
        }

        // GET: RentalTransaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalTransaction = await _context.RentalTransactions
                .Include(t => t.User)
                .Include(t => t.Equipment)
                .ThenInclude(e => e.Category)
                .Include(t => t.RentalRequest)
                .Include(t => t.Documents)
                .Include(t => t.ReturnRecord)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rentalTransaction == null)
            {
                return NotFound();
            }

            // Check if user has permission to view this transaction
            int? userId = HttpContext.Session.GetInt32("UserId");
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            if (!isStaff && rentalTransaction.UserId != userId)
            {
                return Forbid();
            }

            return View(rentalTransaction);
        }

        // GET: RentalTransaction/Create
        public async Task<IActionResult> Create(int? requestId)
        {
            // Check role - only staff can create transactions
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            if (!requestId.HasValue)
            {
                return BadRequest("Rental request ID is required.");
            }

            var rentalRequest = await _context.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .ThenInclude(e => e.Category)
                .FirstOrDefaultAsync(r => r.Id == requestId);

            if (rentalRequest == null)
            {
                return NotFound("Rental request not found.");
            }

            // Check if request is approved
            if (rentalRequest.Status != "Approved")
            {
                TempData["ErrorMessage"] = "Only approved rental requests can be processed for checkout.";
                return RedirectToAction("Details", "RentalRequest", new { id = requestId });
            }

            // Check if a transaction already exists for this request
            var existingTransaction = await _context.RentalTransactions
                .FirstOrDefaultAsync(t => t.RentalRequestId == requestId);

            if (existingTransaction != null)
            {
                TempData["ErrorMessage"] = "A transaction already exists for this rental request.";
                return RedirectToAction("Details", "RentalTransaction", new { id = existingTransaction.Id });
            }

            // Create view model with default values
            var viewModel = new RentalTransactionViewModel
            {
                RentalRequestId = rentalRequest.Id,
                UserId = rentalRequest.UserId,
                UserName = rentalRequest.User.Name,
                EquipmentId = rentalRequest.EquipmentId,
                EquipmentName = rentalRequest.Equipment.Name,
                CategoryName = rentalRequest.Equipment.Category.Name,
                ActualStartDate = DateTime.Now,
                ExpectedReturnDate = rentalRequest.RentalEndDate,
                RentalFee = rentalRequest.TotalCost ?? 0,
                DepositAmount = rentalRequest.Equipment.DepositAmount,
                PaymentStatus = "Pending",
                Status = "Active"
            };

            return View(viewModel);
        }

        // POST: RentalTransaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalTransactionViewModel viewModel)
        {
            // Check role - only staff can create transactions
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // Verify the rental request
                var rentalRequest = await _context.RentalRequests
                    .Include(r => r.Equipment)
                    .FirstOrDefaultAsync(r => r.Id == viewModel.RentalRequestId);

                if (rentalRequest == null)
                {
                    return NotFound("Rental request not found.");
                }

                // Check if request is approved
                if (rentalRequest.Status != "Approved")
                {
                    TempData["ErrorMessage"] = "Only approved rental requests can be processed for checkout.";
                    return RedirectToAction("Details", "RentalRequest", new { id = viewModel.RentalRequestId });
                }

                // Check if a transaction already exists for this request
                var existingTransaction = await _context.RentalTransactions
                    .FirstOrDefaultAsync(t => t.RentalRequestId == viewModel.RentalRequestId);

                if (existingTransaction != null)
                {
                    TempData["ErrorMessage"] = "A transaction already exists for this rental request.";
                    return RedirectToAction("Details", "RentalTransaction", new { id = existingTransaction.Id });
                }

                // Create new rental transaction
                var rentalTransaction = new RentalTransaction
                {
                    RentalRequestId = viewModel.RentalRequestId,
                    UserId = viewModel.UserId,
                    EquipmentId = viewModel.EquipmentId,
                    TransactionDate = DateTime.Now,
                    ActualStartDate = viewModel.ActualStartDate,
                    ExpectedReturnDate = viewModel.ExpectedReturnDate,
                    RentalFee = viewModel.RentalFee,
                    DepositAmount = viewModel.DepositAmount,
                    PaymentStatus = viewModel.PaymentStatus,
                    Status = "Active",
                    Notes = viewModel.Notes
                };

                _context.Add(rentalTransaction);

                // Update equipment status
                var equipment = await _context.Equipment.FindAsync(viewModel.EquipmentId);
                if (equipment != null)
                {
                    equipment.AvailabilityStatus = "Rented";
                    _context.Update(equipment);
                }

                // Update rental request status
                rentalRequest.Status = "Completed";
                _context.Update(rentalRequest);

                await _context.SaveChangesAsync();

                // Create notification for the user
                await NotificationHelper.CreateRentalTransactionNotification(_context, rentalTransaction, "Created");

                // Log the transaction creation
                int userId = HttpContext.Session.GetInt32("UserId").Value;
                await LogHelper.LogUserAction(
                    _context,
                    userId,
                    "Rental Transaction Created",
                    $"Rental transaction created for equipment: {equipment.Name}, Customer: {viewModel.UserName}",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                TempData["SuccessMessage"] = "Rental transaction created successfully.";
                return RedirectToAction(nameof(Details), new { id = rentalTransaction.Id });
            }

            return View(viewModel);
        }

        // GET: RentalTransaction/UploadDocument/5
        public async Task<IActionResult> UploadDocument(int? id)
        {
            // Check if user is authorized
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            if (!isStaff)
            {
                return Forbid();
            }

            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.RentalTransactions
                .Include(t => t.User)
                .Include(t => t.Equipment)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null)
            {
                return NotFound();
            }

            var viewModel = new DocumentUploadViewModel
            {
                RentalTransactionId = transaction.Id,
                TransactionReference = $"{transaction.Equipment.Name} - {transaction.User.Name}"
            };

            return View(viewModel);
        }

        // POST: RentalTransaction/UploadDocument/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadDocument(DocumentUploadViewModel viewModel)
        {
            // Check if user is authorized
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            if (!isStaff)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                if (viewModel.File == null || viewModel.File.Length == 0)
                {
                    ModelState.AddModelError("File", "Please select a file to upload.");
                    return View(viewModel);
                }

                // Verify file extension
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(viewModel.File.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("File", "Only PDF, DOC, DOCX, JPG, JPEG, and PNG files are allowed.");
                    return View(viewModel);
                }

                // Verify file size (max 10MB)
                if (viewModel.File.Length > 10 * 1024 * 1024)
                {
                    ModelState.AddModelError("File", "File size cannot exceed 10MB.");
                    return View(viewModel);
                }

                try
                {
                    // Generate a unique file name
                    string fileName = Guid.NewGuid().ToString() + fileExtension;

                    // Set the file path
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "documents");

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string filePath = Path.Combine(uploadsFolder, fileName);

                    // Save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.File.CopyToAsync(stream);
                    }

                    // Get current user ID
                    int userId = HttpContext.Session.GetInt32("UserId").Value;

                    // Create document record
                    var document = new Document
                    {
                        UserId = userId,
                        RentalTransactionId = viewModel.RentalTransactionId,
                        FileName = viewModel.File.FileName,
                        FileType = fileExtension.TrimStart('.'),
                        FilePath = $"/uploads/documents/{fileName}",
                        UploadDate = DateTime.Now,
                        Description = viewModel.Description
                    };

                    _context.Documents.Add(document);
                    await _context.SaveChangesAsync();

                    // Log the document upload
                    await LogHelper.LogUserAction(
                        _context,
                        userId,
                        "Document Uploaded",
                        $"Document '{viewModel.File.FileName}' uploaded for transaction ID {viewModel.RentalTransactionId}",
                        HttpContext.Connection.RemoteIpAddress?.ToString()
                    );

                    TempData["SuccessMessage"] = "Document uploaded successfully.";
                    return RedirectToAction(nameof(Details), new { id = viewModel.RentalTransactionId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error uploading document: {ex.Message}");
                }
            }

            return View(viewModel);
        }

        // GET: RentalTransaction/DeleteDocument/5
        public async Task<IActionResult> DeleteDocument(int? id)
        {
            // Check if user is authorized
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            if (!isStaff)
            {
                return Forbid();
            }

            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.RentalTransaction)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: RentalTransaction/DeleteDocument/5
        [HttpPost, ActionName("DeleteDocument")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDocumentConfirmed(int id)
        {
            // Check if user is authorized
            string userRole = HttpContext.Session.GetString("UserRole");
            bool isStaff = userRole == "Administrator" || userRole == "RentalManager";

            if (!isStaff)
            {
                return Forbid();
            }

            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            int transactionId = document.RentalTransactionId.Value;

            // Delete the physical file
            try
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, document.FilePath.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                // Log the error but continue with deleting the database record
                int userId = HttpContext.Session.GetInt32("UserId").Value;
                await LogHelper.LogError(
                    _context,
                    ex,
                    userId,
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );
            }

            // Delete the database record
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            // Log the document deletion
            int currentUserId = HttpContext.Session.GetInt32("UserId").Value;
            await LogHelper.LogUserAction(
                _context,
                currentUserId,
                "Document Deleted",
                $"Document '{document.FileName}' deleted from transaction ID {transactionId}",
                HttpContext.Connection.RemoteIpAddress?.ToString()
            );

            TempData["SuccessMessage"] = "Document deleted successfully.";
            return RedirectToAction(nameof(Details), new { id = transactionId });
        }

       // The end of your last method should have proper closing braces
        
        private bool RentalTransactionExists(int id)
        {
            return _context.RentalTransactions.Any(e => e.Id == id);
        }
    }
}