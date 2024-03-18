using System.ComponentModel.DataAnnotations;

namespace Pri.Api.Music.Api.Dtos
{
    public class AccountLoginRequestDto
    {
        [EmailAddress]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
