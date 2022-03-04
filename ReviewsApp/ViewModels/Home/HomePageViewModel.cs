using ReviewsApp.Models.MainReview;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.Home
{
    public class HomePageViewModel
    {
        //todo: change to view model
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<TagCloudViewModel> Tags { get; set; }
    }
}
