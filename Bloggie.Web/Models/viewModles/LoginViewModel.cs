using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.viewModles
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage ="Pssword has to be at least 6 characters!")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
