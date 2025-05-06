using Microsoft.AspNetCore.Mvc;
using Tripsphere.Data;
using Tripsphere.Models;

namespace Tripsphere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactMessagesController : ControllerBase
    {
        private readonly TripsphereDbContext _context;

        public ContactMessagesController(TripsphereDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactMessage message)
        {
            message.SubmittedOn = DateTime.Now;
            _context.ContactMessages.Add(message);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
