using Microsoft.AspNetCore.Mvc;
using Tripsphere.Data;
using Tripsphere.Models;

namespace Tripsphere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelModeController : ControllerBase
    {
        private readonly TripsphereDbContext _context;

        public TravelModeController(TripsphereDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var modes = _context.TravelModes.ToList();
            return Ok(modes);
        }
    }
}
