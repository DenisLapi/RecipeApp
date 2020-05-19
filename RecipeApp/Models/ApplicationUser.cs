using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Photo { get; set; }

        [NotMapped]
        [DefaultValue(false)]
        public string ShowLoginMessage { get; set; }
    }
}
