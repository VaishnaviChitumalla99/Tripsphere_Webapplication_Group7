using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tripsphere.Models
{
    public class TravelFeedback
    {
        public int Id { get; set; }

        [Required]
        public required string Message { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
