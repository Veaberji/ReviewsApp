using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Login Required")]
        [MaxLength(UserRegistrationConstrains.MaxStringLength,
            ErrorMessage = "Maximum login length")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Display Name Required")]
        [MaxLength(UserRegistrationConstrains.MaxStringLength,
            ErrorMessage = "Maximum Display Name length")]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        [MaxLength(UserRegistrationConstrains.MaxStringLength,
                    ErrorMessage = "Maximum password length")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [MaxLength(UserRegistrationConstrains.MaxStringLength,
            ErrorMessage = "Maximum Email length")]
        public string Email { get; set; }
    }
}
