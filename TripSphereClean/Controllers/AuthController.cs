using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripSphere.Data;
using TripSphere.Models;

namespace TripSphere.Controllers
{
    public class AuthController : Controller
    {
        private readonly TripsphereDbContext _context;

        public AuthController(TripsphereDbContext context)
        {
            _context = context;
        }

        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("user_id", user.UserId);
                HttpContext.Session.SetString("fullname", user.Username);

                TempData["Message"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Invalid credentials.";
            return View();
        }

        // GET: /Auth/Signup
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        // POST: /Auth/Signup
        [HttpPost]
        public async Task<IActionResult> Signup(string fullname, string email, string username, string password, string confirm)
        {
            if (password != confirm)
            {
                TempData["Error"] = "Passwords do not match.";
                return View();
            }

            // Normalize email and username
            email = email.Trim().ToLower();
            username = username.Trim().ToLower();

            // Check for duplicate email or username (case-insensitive)
            bool exists = await _context.Users
                .AnyAsync(u => u.Email.ToLower() == email || u.Username.ToLower() == username);

            if (exists)
            {
                TempData["Error"] = "Email or username already exists.";
                return View();
            }

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password // ⚠️ Reminder: hash password in production
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Account created successfully! Please login.";
            return RedirectToAction("Login");
        }

        // GET: /Auth/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Logged out successfully.";
            return RedirectToAction("Login");
        }
    }
}
