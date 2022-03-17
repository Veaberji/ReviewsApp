using ReviewsApp.ViewModels.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<PreviewViewModel> Reviews { get; set; }
        public IEnumerable<TagCloudViewModel> TagCloud { get; set; }
        public PaginationViewModel Pagination { get; set; }
        public IEnumerable<TopRatedReviewViewModel> TopRatedReviews { get; set; }

    }
}
