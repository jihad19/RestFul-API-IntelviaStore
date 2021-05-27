using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Release First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Release Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
