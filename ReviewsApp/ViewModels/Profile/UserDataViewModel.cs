using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.Profile
{
    public class UserDataViewModel
    {
        [Required(ErrorMessage = "New Display Name Required")]
        [MaxLength(UserRegistrationConstrains.MaxStringLength,
            ErrorMessage = "Maximum Display Name length")]
        [Display(Name = "New Display Name")]
        public string DisplayName { get; set; }
    }
}
