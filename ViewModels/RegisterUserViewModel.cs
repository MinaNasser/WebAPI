using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class RegisterUserViewModel
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        public string Address { get; set; }


    }
}
