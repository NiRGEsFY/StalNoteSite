using System.ComponentModel.DataAnnotations;

namespace StalNoteSite.Users.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        public string ReturnUrl { get; set; }
    }
}
