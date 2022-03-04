using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(UserRegistrationConstrains.MaxStringLength)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(UserRegistrationConstrains.MaxStringLength)]
        public string Password { get; set; }
    }
}
