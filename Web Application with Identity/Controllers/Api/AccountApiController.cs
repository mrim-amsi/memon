using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountApiController(UserManager<IdentityUser> userManager,
                                      SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //public IActionResult Register()
        //{
        //    return View();
        //}
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return Ok(user);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return BadRequest(ModelState);
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return Ok(user);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
