using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tripsphere.Models
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public string? Email { get; set; }

        [Required]
        [Column("username")]
        public string? Username { get; set; }

        [Required]
        [Column("password")]
        public string? Password { get; set; }
    }
}
