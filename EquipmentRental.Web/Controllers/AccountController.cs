//using EquipmentRental.Data.Data;
//using EquipmentRental.Data.Entities;
using EquipmentRental.Data.Helpers;
using EquipmentRental.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using rental_System_db.Data;
using rental_System_db.Entities;

namespace EquipmentRental.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly RentalDBContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(RentalDBContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Login()
        {
            // If already logged in, redirect to home
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hash the password for comparison
                string hashedPassword = PasswordHelper.HashPassword(model.Password);

                // Find the user with the provided email and password
                var user = await _context.Users.FirstOrDefaultAsync(u =>
                    u.Email == model.Email &&
                    u.Password == hashedPassword);

                if (user != null)
                {
                    // Set session variables
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("UserName", user.Name);
                    HttpContext.Session.SetString("UserRole", user.Role);

                    // Log the successful login
                    await LogHelper.LogUserAction(
                        _context,
                        user.Id,
                        "Login",
                        $"User {user.Email} logged in successfully",
                        HttpContext.Connection.RemoteIpAddress?.ToString()
                    );

                    _logger.LogInformation($"User {user.Email} logged in successfully");

                    // Redirect based on role
                    return RedirectToAction("Dashboard", "Home");
                }

                // Log the failed login attempt
                await LogHelper.LogSystemAction(
                    _context,
                    "Failed Login",
                    $"Failed login attempt for email: {model.Email}",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                ModelState.AddModelError("", "Invalid email or password");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            // If already logged in, redirect to home
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                if (await _context.Users.AnyAsync(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email is already registered");
                    return View(model);
                }

                // Create new user with Customer role
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = PasswordHelper.HashPassword(model.Password),
                    Role = "Customer", // Default role for registration
                    PhoneNumber = model.PhoneNumber,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Log the registration
                await LogHelper.LogSystemAction(
                    _context,
                    "Registration",
                    $"New user registered: {model.Email}",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                // Set session variables for automatic login
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserRole", user.Role);

                _logger.LogInformation($"New user registered: {model.Email}");

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            // Log the logout if user is logged in
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                // Log the logout
                LogHelper.LogUserAction(
                    _context,
                    userId.Value,
                    "Logout",
                    "User logged out",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                ).Wait();
            }

            // Clear session
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            // Get user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login");
            }

            // Get user details
            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);
            if (user == null)
            {
                return NotFound();
            }

            // Create view model
            var viewModel = new ProfileViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Get user ID from session
                int? userId = HttpContext.Session.GetInt32("UserId");
                if (!userId.HasValue)
                {
                    return RedirectToAction("Login");
                }

                // Get user from database
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId.Value);
                if (user == null)
                {
                    return NotFound();
                }

                // Update user details
                user.Name = model.Name;
                user.PhoneNumber = model.PhoneNumber;

                // Only update password if new password provided
                if (!string.IsNullOrEmpty(model.NewPassword))
                {
                    // Verify current password
                    if (!PasswordHelper.VerifyPassword(model.CurrentPassword, user.Password))
                    {
                        ModelState.AddModelError("CurrentPassword", "Current password is incorrect");
                        return View(model);
                    }

                    // Update password
                    user.Password = PasswordHelper.HashPassword(model.NewPassword);
                }

                _context.Update(user);
                await _context.SaveChangesAsync();

                // Log the profile update
                await LogHelper.LogUserAction(
                    _context,
                    user.Id,
                    "Profile Update",
                    "User updated their profile",
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                // Update session variables
                HttpContext.Session.SetString("UserName", user.Name);

                TempData["SuccessMessage"] = "Profile updated successfully";
                return RedirectToAction("Profile");
            }

            return View(model);
        }
    }
}