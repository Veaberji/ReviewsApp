using ReviewsApp.ViewModels.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public UserNamesViewModel Names { get; set; }
        public IEnumerable<PreviewViewModel> Reviews { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}
