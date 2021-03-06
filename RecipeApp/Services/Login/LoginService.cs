﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeApp.Models;

namespace RecipeApp.Services.Login
{
    public class LoginService : PageModel, ILoginService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginService> _logger;

        public LoginService(SignInManager<ApplicationUser> signInManager, ILogger<LoginService> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<string> ShowLogin(string returnUrl = null)
        {
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return returnUrl;
        }

        public async Task<IActionResult> PostLogin(string returnUrl = null, InputModel Input = null)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
