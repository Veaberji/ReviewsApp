using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login Required")]
        [MaxLength(UserRegistrationConstrains.MaxStringLength,
            ErrorMessage = "Maximum login length")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MaxLength(UserRegistrationConstrains.MaxStringLength,
            ErrorMessage = "Maximum password length")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
