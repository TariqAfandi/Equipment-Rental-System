//using EquipmentRental.Data.Data;
//using EquipmentRental.Data.Entities;
using EquipmentRental.Data.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using rental_System_db.Data;
using rental_System_db.Entities;

namespace EquipmentRental.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly RentalDBContext _context;

        public CategoryController(RentalDBContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            // Check role - Category management is for staff only
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator" && userRole != "RentalManager")
            {
                return RedirectToAction("Index", "Home");
            }

            return View(await _context.Categories.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            // Check role - only Administrators can create categories
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] Category category)
        {
            // Check role - only Administrators can create categories
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                category.CreatedAt = DateTime.Now;
                category.IsActive = true;

                _context.Add(category);
                await _context.SaveChangesAsync();

                // Log the category creation
                int userId = HttpContext.Session.GetInt32("UserId").Value;
                await LogHelper.LogUserAction(
                    _context,
                    userId,
                    "Category Created",
                    $"Category '{category.Name}' was created",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Check role - only Administrators can edit categories
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsActive")] Category category)
        {
            // Check role - only Administrators can edit categories
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Get the existing category to preserve CreatedAt date
                    var existingCategory = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
                    if (existingCategory == null)
                    {
                        return NotFound();
                    }

                    category.CreatedAt = existingCategory.CreatedAt; // Preserve original creation date

                    _context.Update(category);
                    await _context.SaveChangesAsync();

                    // Log the category update
                    int userId = HttpContext.Session.GetInt32("UserId").Value;
                    await LogHelper.LogUserAction(
                        _context,
                        userId,
                        "Category Updated",
                        $"Category '{category.Name}' was updated",
                        HttpContext.Connection.RemoteIpAddress?.ToString()
                    );
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // Check role - only Administrators can delete categories
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            // Check if category has any equipment
            int equipmentCount = await _context.Equipment.CountAsync(e => e.CategoryId == id);
            ViewBag.HasEquipment = equipmentCount > 0;
            ViewBag.EquipmentCount = equipmentCount;

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Check role - only Administrators can delete categories
            string userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Administrator")
            {
                return RedirectToAction("Index", "Home");
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Check if category has any equipment
            int equipmentCount = await _context.Equipment.CountAsync(e => e.CategoryId == id);
            if (equipmentCount > 0)
            {
                TempData["ErrorMessage"] = $"Cannot delete category '{category.Name}' because it contains {equipmentCount} equipment items.";
                return RedirectToAction(nameof(Index));
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            // Log the category deletion
            int userId = HttpContext.Session.GetInt32("UserId").Value;
            await LogHelper.LogUserAction(
                _context,
                userId,
                "Category Deleted",
                $"Category '{category.Name}' was deleted",
                HttpContext.Connection.RemoteIpAddress?.ToString()
            );

            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}