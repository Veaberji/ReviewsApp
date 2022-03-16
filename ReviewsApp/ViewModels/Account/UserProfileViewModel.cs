using ReviewsApp.ViewModels.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.Account
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public IEnumerable<PreviewViewModel> Reviews { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}
