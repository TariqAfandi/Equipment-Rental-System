//using EquipmentRental.Data.Data;
//using EquipmentRental.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using rental_System_db.Data;
using rental_System_db.Entities;

namespace EquipmentRental.Web.Controllers
{
    public class NotificationController : Controller
    {
        private readonly RentalDBContext _context;

        public NotificationController(RentalDBContext context)
        {
            _context = context;
        }

        // GET: Notification
        public async Task<IActionResult> Index()
        {
            // Get user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId.Value)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return View(notifications);
        }

        // GET: Notification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .FirstOrDefaultAsync(m => m.Id == id);

            if (notification == null)
            {
                return NotFound();
            }

            // Check if user owns this notification
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (notification.UserId != userId)
            {
                return Forbid();
            }

            // Mark as read if not already
            if (!notification.IsRead)
            {
                notification.IsRead = true;
                notification.ReadAt = DateTime.Now;
                _context.Update(notification);
                await _context.SaveChangesAsync();
            }

            return View(notification);
        }

        // POST: Notification/MarkAsRead/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            // Check if user owns this notification
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (notification.UserId != userId)
            {
                return Forbid();
            }

            // Mark as read
            notification.IsRead = true;
            notification.ReadAt = DateTime.Now;
            _context.Update(notification);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Notification/MarkAllAsRead
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAllAsRead()
        {
            // Get user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get all unread notifications for this user
            var unreadNotifications = await _context.Notifications
                .Where(n => n.UserId == userId.Value && !n.IsRead)
                .ToListAsync();

            // Mark all as read
            foreach (var notification in unreadNotifications)
            {
                notification.IsRead = true;
                notification.ReadAt = DateTime.Now;
                _context.Update(notification);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Notification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .FirstOrDefaultAsync(m => m.Id == id);

            if (notification == null)
            {
                return NotFound();
            }

            // Check if user owns this notification
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (notification.UserId != userId)
            {
                return Forbid();
            }

            return View(notification);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            // Check if user owns this notification
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (notification.UserId != userId)
            {
                return Forbid();
            }

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Helper method for layouts to get unread notification count
        [HttpGet]
        public async Task<JsonResult> GetUnreadCount()
        {
            // Get user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return Json(0);
            }

            int count = await _context.Notifications
                .CountAsync(n => n.UserId == userId.Value && !n.IsRead);

            return Json(count);
        }
    }
}