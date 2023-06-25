
using System.ComponentModel.DataAnnotations;

namespace Carea.Models
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
