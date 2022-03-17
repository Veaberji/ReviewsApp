using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.Profile
{
    public class UserDataViewModel
    {
        [Required]
        [MaxLength(UserRegistrationConstrains.MaxStringLength)]
        [Display(Name = "New displayed Name")]
        public string DisplayName { get; set; }
    }
}
