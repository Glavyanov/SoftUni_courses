using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Data.Models.Accounts;
using WebShopDemo.Models;
using static WebShopDemo.Core.Data.ValidationConstants.ClaimsConstants;
using static WebShopDemo.Core.Data.ValidationConstants.RolesConstants;

namespace WebShopDemo.Controllers
{
    /// <summary>
    /// Web shop accounts
    /// </summary>
    public class AccountController : BaseController
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        /// <summary>
        /// Load the register view
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();
        

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                UserName = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                await userManager
                    .AddClaimAsync(user, new System.Security.Claims.Claim(FirstName, user.FirstName ?? user.Email));

                return RedirectToAction("Index", "Home");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnURL = null)
        {
            var model = new LoginViewModel()
            {
                ReturnURL = returnURL
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (model.ReturnURL != null)
                    {
                        return Redirect(model.ReturnURL);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateRoles()
        {
            await roleManager.CreateAsync(new IdentityRole(Manager));
            await roleManager.CreateAsync(new IdentityRole(Supervisor));
            await roleManager.CreateAsync(new IdentityRole(Admin));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AddRoles()
        {
            var users = await userManager.Users.ToListAsync();

            if( users.Count >= 2 )
            {
                await userManager.AddToRoleAsync(users[0], Manager);
                await userManager.AddToRolesAsync(users[^1], new string[] { Manager, Supervisor });
            } 

            return RedirectToAction("Index", "Home");
        }
    }
}
