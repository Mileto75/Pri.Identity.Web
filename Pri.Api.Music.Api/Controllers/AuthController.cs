using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pri.Api.Music.Api.Dtos;
using Pri.Api.Music.Core.Entities;

namespace Pri.Api.Music.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginRequestDto authLoginRequestDto)
        {
            //authenticate the user
            var result = await _signInManager.PasswordSignInAsync
                (authLoginRequestDto.Username,authLoginRequestDto.Password,false,false);
            if(!result.Succeeded)//wrong credentials
            {
                ModelState.AddModelError("", "Wrong credentials!");
                return Unauthorized(ModelState.Values);
            }
            //get the user
            var user = await _userManager.FindByNameAsync(authLoginRequestDto.Username);
            //get the claims
            var claims = await _userManager.GetClaimsAsync(user);
            //generate the token

            //return the token
            return Ok();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

    }
}
