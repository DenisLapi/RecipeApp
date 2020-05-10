using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services.Register
{
    public interface IRegisterService
    {
        public Task<List<AuthenticationScheme>> ShowRegister(string returnUrl = null);
        public Task<IActionResult> PostRegister(string returnUrl = null, InputModel Input = null);
    }
}
