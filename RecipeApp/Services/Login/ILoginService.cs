using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services.Login
{
    public interface ILoginService
    {
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public Task<string> ShowLogin(string returnUrl = null);

        public Task<IActionResult> PostLogin(string returnUrl = null, InputModel Input = null);
    }
}
