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

        public AuthController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
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
                return RedirectToAction("Index", "Records",new {Area="" });
            }
            ModelState.AddModelError("", "Wrong credentials!");
            return View(authLoginViewModel);
        }
    }
}
