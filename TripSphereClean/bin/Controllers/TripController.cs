using Microsoft.AspNetCore.Mvc;
using TripSphere.Models;


namespace TripSphere.Controllers
{
    public class TripsController : Controller
    {
        // Simulate persistent storage (will reset on app restart)
        private static List<TripModel> _trips = new List<TripModel>();

        [HttpGet]
        public IActionResult Book()
        {
            return View(_trips);
        }

        [HttpPost]
        public IActionResult Book(string destination, string country, string duration, string budget, string mode)
        {
            var newTrip = new TripModel
            {
                Destination = destination,
                Country = country,
                Duration = duration,
                Budget = budget,
                Mode = mode
            };

            _trips.Add(newTrip);
            return RedirectToAction("Book");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id < 0 || id >= _trips.Count)
                return NotFound();

            return View("Edit", _trips[id]);
        }

        [HttpPost]
        public IActionResult Edit(int id, TripModel updatedTrip)
        {
            if (id < 0 || id >= _trips.Count)
                return NotFound();

            _trips[id] = updatedTrip;
            return RedirectToAction("Book");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= _trips.Count)
                return NotFound();

            _trips.RemoveAt(id);
            return RedirectToAction("Book");
        }

        [HttpGet]
        public IActionResult Analytics()
        {
            return View(_trips);
        }

    }
}
