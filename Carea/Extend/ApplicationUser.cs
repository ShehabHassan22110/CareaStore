using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carea.Extend
{
     public class ApplicationUser:IdentityUser
    {
        public bool IsAgree { get; set; }
        public string FullName { get; set; }
        public string? Nickname { get; set; }
        public string? imgUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public int PIN { get; set; }


    }
}
