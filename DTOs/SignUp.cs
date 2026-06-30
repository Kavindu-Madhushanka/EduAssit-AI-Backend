using System.ComponentModel.DataAnnotations;

namespace eduasst_backend.DTOs
{
    public class SignUp
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; }= string.Empty;
    }
}
