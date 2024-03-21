using System.ComponentModel.DataAnnotations;

namespace Pri.Api.Music.Web.Areas.Auth.ViewModels
{
    public class AuthRegisterViewModel : AuthLoginViewModel
    {
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
