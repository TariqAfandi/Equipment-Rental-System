//using EquipmentRental.Data.Data;
using EquipmentRental.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using rental_System_db.Data;

namespace EquipmentRental.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RentalDBContext _context;

        public HomeController(ILogger<HomeController> logger, RentalDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Check if user is logged in
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                int userId = HttpContext.Session.GetInt32("UserId").Value;
                string userRole = HttpContext.Session.GetString("UserRole");

                // Redirect based on role
                if (userRole == "Administrator" || userRole == "RentalManager")
                {
                    return RedirectToAction("Dashboard");
                }
                else // Customer
                {
                    return View(); // Show customer home view
                }
            }

            // Not logged in, show default home page
            return View();
        }

        public IActionResult Dashboard()
        {
            // Only allow access if logged in
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string? userRole = HttpContext.Session.GetString("UserRole");
            ViewBag.UserRole = userRole;

            // Prepare dashboard data based on role
            if (userRole == "Administrator" || userRole == "RentalManager")
            {
                // Get counts for dashboard
                ViewBag.TotalEquipment = _context.Equipment.Count();
                ViewBag.TotalCategories = _context.Categories.Count();
                ViewBag.TotalRequests = _context.RentalRequests.Count();
                ViewBag.PendingRequests = _context.RentalRequests.Count(r => r.Status == "Pending");
                ViewBag.ActiveRentals = _context.RentalTransactions.Count(t => t.Status == "Active");
                ViewBag.OverdueRentals = _context.RentalTransactions.Count(t => t.Status == "Overdue");
            }
            else // Customer
            {
                // Get customer-specific data
                ViewBag.MyRequests = _context.RentalRequests.Count(r => r.UserId == userId);
                ViewBag.MyPendingRequests = _context.RentalRequests.Count(r => r.UserId == userId && r.Status == "Pending");
                ViewBag.MyActiveRentals = _context.RentalTransactions.Count(t => t.UserId == userId && t.Status == "Active");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminLogs()
        {
            // Only allow access if logged in as Administrator
            if (HttpContext.Session.GetString("UserRole") != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            var logs = _context.Logs.OrderByDescending(l => l.Timestamp).ToList();
            return View(logs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}