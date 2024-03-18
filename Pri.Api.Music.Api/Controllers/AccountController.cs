using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pri.Api.Music.Api.Dtos;
using Pri.Api.Music.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pri.Api.Music.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginRequestDto accountLoginRequestDto)
        {
            var result = await _signInManager.PasswordSignInAsync(accountLoginRequestDto.Username
                ,accountLoginRequestDto.Password,false,false);
            if(result.Succeeded)
            {
                //get the user
                var user = await _userManager.FindByNameAsync(accountLoginRequestDto.Username);
                var userClaims = await _userManager.GetClaimsAsync(user);
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                userClaims.Add(new Claim(ClaimTypes.Email, user.UserName));
                //get the claims
                //Created signinKey
                var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigninKey")));
                var signinCredentials  = new SigningCredentials(signInKey,SecurityAlgorithms.HmacSha256);
                //create and return token
                var token = new JwtSecurityToken(
                    audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                    issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                    expires: DateTime.Now.AddDays(_configuration.GetValue<int>("JWTConfiguration:TokenExpiration")),
                    signingCredentials: signinCredentials,
                    claims: userClaims
                    );
                //serializeToken
                var serialzedToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(serialzedToken);
            }
            return Unauthorized("Wrong credentials");
        }
    }
}
