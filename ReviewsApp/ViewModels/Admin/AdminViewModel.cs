using System.Collections.Generic;

namespace ReviewsApp.ViewModels.Admin
{
    public class AdminViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
