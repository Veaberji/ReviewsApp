using ReviewsApp.ViewModels.MainReview;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.Home
{
    public class HomePageViewModel
    {
        public IEnumerable<PreviewViewModel> Reviews { get; set; }
        public IEnumerable<TagCloudViewModel> Tags { get; set; }
    }
}
