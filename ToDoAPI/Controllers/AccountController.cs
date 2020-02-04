using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            return null;
        }
        public async Task<IActionResult> Logout()
        {

            return null;
        }

    }
}