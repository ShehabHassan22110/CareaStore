using System.ComponentModel.DataAnnotations;

namespace Carea.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? device_id { get; set; }

    }
}
