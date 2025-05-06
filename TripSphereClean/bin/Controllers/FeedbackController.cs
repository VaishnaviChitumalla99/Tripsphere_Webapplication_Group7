using Microsoft.AspNetCore.Mvc;

namespace TripSphere.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(string destination, int rating, string comments)
        {
            // You can store feedback here (TempData, DB, or file)
            TempData["Message"] = "Thank you for your feedback!";
            return RedirectToAction("Index");
        }
    }
}
