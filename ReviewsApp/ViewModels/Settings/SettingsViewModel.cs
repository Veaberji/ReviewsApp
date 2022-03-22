using Microsoft.AspNetCore.Mvc.Rendering;
using ReviewsApp.Models.Settings;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.Settings
{
    public class SettingsViewModel
    {
        public IEnumerable<Themes> Themes { get; set; }
        public IEnumerable<SelectListItem> Cultures { get; set; }
    }
}
