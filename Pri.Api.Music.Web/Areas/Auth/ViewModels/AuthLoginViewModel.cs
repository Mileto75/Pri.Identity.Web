using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Pri.Api.Music.Web.Areas.Auth.ViewModels
{
    public class AuthLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}
