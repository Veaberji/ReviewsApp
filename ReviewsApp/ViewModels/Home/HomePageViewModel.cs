using System.Collections.Generic;

namespace ReviewsApp.ViewModels.Home
{
    public class HomePageViewModel
    {
        //todo: change to view model
        public IEnumerable<Models.Review> Reviews { get; set; }
        public IEnumerable<TagCloudViewModel> Tags { get; set; }
    }
}
