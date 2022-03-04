using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(UserRegistrationConstrains.MaxStringLength)]
        public string Login { get; set; }

        [Required]
        [MaxLength(UserRegistrationConstrains.MaxStringLength)]
        [Display(Name = "Your displayed Name")]
        public string DisplayName { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(UserRegistrationConstrains.MaxStringLength)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(UserRegistrationConstrains.MaxStringLength)]
        public string Email { get; set; }
    }
}
