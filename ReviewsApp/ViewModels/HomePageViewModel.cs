using ReviewsApp.Models;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels
{
    public class HomePageViewModel
    {
        //todo: change to view model
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<TagCloudViewModel> Tags { get; set; }
    }
}
