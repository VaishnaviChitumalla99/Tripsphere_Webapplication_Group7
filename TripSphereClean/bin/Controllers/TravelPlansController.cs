using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tripsphere.Data;
using Tripsphere.Models;

namespace Tripsphere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelPlansController : ControllerBase
    {
        private readonly TripsphereDbContext _context;

        public TravelPlansController(TripsphereDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(TravelPlan plan)
        {
            var plans = await _context.TravelPlans
                .Include(tp => tp.TravelMode)
                .ToListAsync();
            return Ok(plans);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TravelPlan plan)
        {
            _context.TravelPlans.Add(plan);
            await _context.SaveChangesAsync();
            return Ok(plan);
        }
    }
}
