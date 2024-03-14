using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pri.Api.Music.Core.Entities;

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
    }
}
