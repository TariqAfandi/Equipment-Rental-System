//using EquipmentRental.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using rental_System_db.Data;

namespace EquipmentRental.Web.Controllers
{
    public class LogController : Controller
    {
        private readonly RentalDBContext _context;

        public LogController(RentalDBContext context)
        {
            _context = context;
        }

        // GET: Log
        public async Task<IActionResult> Index(string searchString, string actionFilter, DateTime? fromDate, DateTime? toDate)
        {
            // Check role - only administrators can view logs
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.SearchString = searchString;
            ViewBag.ActionFilter = actionFilter;
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;

            var logsQuery = _context.Logs
                .Include(l => l.User)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(searchString))
            {
                logsQuery = logsQuery.Where(l =>
                    l.Details.Contains(searchString) ||
                    l.Action.Contains(searchString) ||
                    l.User.Name.Contains(searchString) ||
                    l.User.Email.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(actionFilter))
            {
                logsQuery = logsQuery.Where(l => l.Action == actionFilter);
            }

            if (fromDate.HasValue)
            {
                logsQuery = logsQuery.Where(l => l.Timestamp >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                // Add a day to include the end date fully
                logsQuery = logsQuery.Where(l => l.Timestamp <= toDate.Value.AddDays(1));
            }

            // Get unique action types for filter dropdown
            ViewBag.ActionTypes = await _context.Logs
                .Select(l => l.Action)
                .Distinct()
                .OrderBy(a => a)
                .ToListAsync();

            // Order by timestamp descending (newest first)
            logsQuery = logsQuery.OrderByDescending(l => l.Timestamp);

            return View(await logsQuery.ToListAsync());
        }

        // GET: Log/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Check role - only administrators can view logs
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // GET: Log/ClearOldLogs
        public IActionResult ClearOldLogs()
        {
            // Check role - only administrators can clear logs
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Log/ClearOldLogs
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearOldLogs(int days)
        {
            // Check role - only administrators can clear logs
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            if (days <= 0)
            {
                ModelState.AddModelError("", "Please enter a positive number of days.");
                return View();
            }

            // Calculate cutoff date
            DateTime cutoffDate = DateTime.Now.AddDays(-days);

            // Delete logs older than the cutoff date
            var oldLogs = await _context.Logs
                .Where(l => l.Timestamp < cutoffDate)
                .ToListAsync();

            int count = oldLogs.Count;

            _context.Logs.RemoveRange(oldLogs);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Successfully cleared {count} logs older than {days} days.";
            return RedirectToAction(nameof(Index));
        }
    }
}