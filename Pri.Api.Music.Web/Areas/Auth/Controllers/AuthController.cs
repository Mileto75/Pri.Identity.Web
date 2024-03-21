using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pri.Api.Music.Core.Entities;
using Pri.Api.Music.Web.Areas.Auth.ViewModels;

namespace Pri.Api.Music.Web.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var authLoginViewModel = new AuthLoginViewModel();
            if(string.IsNullOrEmpty(returnUrl))
            {
                authLoginViewModel.ReturnUrl = "/records";
            }
            authLoginViewModel.ReturnUrl = returnUrl;
            return View(authLoginViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(AuthLoginViewModel authLoginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(authLoginViewModel);
            }
            //use the signinManager
            var result = await _signInManager.PasswordSignInAsync
                (authLoginViewModel.Username, authLoginViewModel.Password
                ,false,false);
            if(result.Succeeded)
            {
                return Redirect(authLoginViewModel.ReturnUrl);
            }
            ModelState.AddModelError("", "Wrong credentials!");
            return View(authLoginViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            //inti the date
            var authRegisterViewModel = new AuthRegisterViewModel();
            authRegisterViewModel.DateOfBirth = DateTime.Now;
            return View(authRegisterViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(AuthRegisterViewModel authRegisterViewModel)
        {
            //date must be in past
            if(authRegisterViewModel.DateOfBirth >= DateTime.Now)
            {
                ModelState.AddModelError("DateOfBirth", "Date must be in the past!");
            }
            if(!ModelState.IsValid)
            {
                return View(authRegisterViewModel);
            }
            //create the user
            var newUser = new ApplicationUser 
            {
                UserName = authRegisterViewModel.Username,
                Email = authRegisterViewModel.Username,
                Firstname = authRegisterViewModel.Firstname,
                Lastname = authRegisterViewModel.Lastname,
                DateOfBirth = authRegisterViewModel.DateOfBirth
            };
            //store in database
            var result  = await _userManager.CreateAsync(newUser,authRegisterViewModel.Password);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(authRegisterViewModel);
            }
            //user registered => generate emailconfirmation token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            ViewBag.UserId = newUser.Id;
            ViewBag.Token = token;
            return View("ValidateEmail");
        }
        public async Task<IActionResult> ValidateEmail(string userId,string token)
        {
            //validate the emailconfirmation token
            //get the user
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if(result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Error");
        }
    }
}
