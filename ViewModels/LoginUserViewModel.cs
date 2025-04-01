using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
