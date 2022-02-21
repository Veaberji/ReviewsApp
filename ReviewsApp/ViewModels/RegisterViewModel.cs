using ReviewsApp.Models.Settings;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels
{
    //todo: del
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(Constrains.MaxStringLength)]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(Constrains.MaxStringLength)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(Constrains.MaxStringLength)]
        public string Email { get; set; }
    }
}
