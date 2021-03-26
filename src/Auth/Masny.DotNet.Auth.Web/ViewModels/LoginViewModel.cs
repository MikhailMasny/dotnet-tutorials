using System.ComponentModel.DataAnnotations;

namespace Masny.DotNet.Auth.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Invalid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
