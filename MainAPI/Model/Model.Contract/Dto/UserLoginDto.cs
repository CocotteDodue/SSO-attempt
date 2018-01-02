using System.ComponentModel.DataAnnotations;

namespace ModelContract.Dto
{
    public class UserLoginDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
