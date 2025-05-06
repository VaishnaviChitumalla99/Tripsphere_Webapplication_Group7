using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripSphere.Data;
using TripSphere.Models;
using System.Threading.Tasks;

namespace TripSphere.Controllers
{
    public class TripsController : Controller
    {
        private readonly TripsphereDbContext _context;

        public TripsController(TripsphereDbContext context)
        {
            _context = context;
        }

        // GET: /Trips/Book
        [HttpGet]
        public async Task<IActionResult> Book()
        {
            var trips = await _context.TripModels.ToListAsync();
            return View(trips);
        }

        // POST: /Trips/Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(TripModel newTrip)
        {
            if (ModelState.IsValid)
            {
                _context.TripModels.Add(newTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Book");
            }
            return View(newTrip);
        }

        // GET: /Trips/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var trip = await _context.TripModels.FindAsync(id);
            return trip == null ? NotFound() : View(trip);
        }

        // POST: /Trips/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TripModel updatedTrip)
        {
            if (id != updatedTrip.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(updatedTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Book");
            }

            return View(updatedTrip);
        }

        // GET: /Trips/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _context.TripModels.FindAsync(id);
            if (trip == null)
                return NotFound();

            _context.TripModels.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction("Book");
        }

        // GET: /Trips/Analytics
        [HttpGet]
        public async Task<IActionResult> Analytics()
        {
            var trips = await _context.TripModels.ToListAsync();
            return View(trips);
        }
    }
}
