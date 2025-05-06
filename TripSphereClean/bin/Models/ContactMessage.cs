
using System.ComponentModel.DataAnnotations;

namespace Tripsphere.Models
{
    public class ContactMessage
    {
        [Key]  // ✅ This makes it the primary key
        public int MessageId { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime? SubmittedOn { get; set; }
    }
}
