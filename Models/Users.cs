
using System.ComponentModel.DataAnnotations;

namespace eduasst_backend.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public string FullName { get; set; }= string.Empty;
    }
}