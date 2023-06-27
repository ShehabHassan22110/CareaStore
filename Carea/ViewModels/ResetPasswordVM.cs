using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Carea.ViewModels
{
    public class ResetPasswordVM
    {
        public string Token { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "You must Enter V alid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage = "Min length 3")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage = "Min length 3")]
        [Compare("Password")]
        [Display(Name = "confirm Password")]
        public string ConfirmPassword { get; set; }


    }
}
