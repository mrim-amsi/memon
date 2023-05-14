using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity.Controllers.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AccountApiController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountApiController(UserManager<IdentityUser> userManager,
                                      SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        [Route("GetUser")]

        public async Task<ActionResult<IdentityUser>> GetUser(string username)
        {
            IdentityUser user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        //[HttpGet]
        //[Route("SallonBranches/GetUsers")]

        //public async Task<ActionResult> GetUsers(LoginViewModel a)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(a.Email, a.Password, false, false);



        //    return Ok(a.Email);
        //}


        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register(string phoneNumber, string userName)

        {
            var userExsit = await _signInManager.UserManager.Users
                   .SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (userExsit != null)
            {
                return Ok(new statusUser
                {
                    applicationUser = userExsit,
                    message = "هذا الرقم مسجل من قبل حاول تسجيل الدخول ",
                    boolStatus = false,
                    numStatus = 400,
                });
            }

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = userName,
                    Email = userName,
                    PhoneNumber = phoneNumber,
                };

                var result = await _userManager.CreateAsync(user, "A123456as#");

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return Ok(new statusUser
                    {
                        applicationUser = userExsit,
                        message = "تم تسجيل مستخدم جديد بنجاح",
                        boolStatus = true,
                        numStatus = 200,
                    });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("Login")]

        public async Task<ActionResult> Login(string phoneNumber)
        {

            var user = await _signInManager.UserManager.Users
                   .SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (user != null)
            {
                return Ok(new statusUser
                {
                    applicationUser = user,
                    message = "تم تسجيل الدخول بنجاح",
                    boolStatus = true,
                    numStatus = 200,
                });
            }


            //if (ModelState.IsValid)
            //{
            //    var result = await _signInManager.PasswordSignInAsync(user.Email, user.PasswordHash,true, false);

            //    if (result.Succeeded)
            //    {
            //        return Ok(user);
            //    }

            //    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            //    return Ok(result);
            //}
            return Ok(new statusUser
            {
                applicationUser = user,
                message = "هذا الرقم لايوجد لديه حساب يرجى تسجل مستخدم جديد",
                boolStatus = false,
                numStatus = 400,
            });
        }


    }
}
