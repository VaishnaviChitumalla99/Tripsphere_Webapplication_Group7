using Microsoft.AspNetCore.Mvc;

namespace TripSphere.Controllers
{
    public class AuthController : Controller
    {
        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Basic placeholder logic (replace with real auth later)
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
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
        public IActionResult Signup(string fullname, string email, string username, string password, string confirm)
        {
            if (password != confirm)
            {
                TempData["Error"] = "Passwords do not match.";
                return View();
            }

            TempData["Message"] = "Account created successfully!";
            return RedirectToAction("Login");
        }
    }
}
