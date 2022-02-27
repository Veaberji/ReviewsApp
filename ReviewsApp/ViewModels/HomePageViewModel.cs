using ReviewsApp.Models;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<TagCloudViewModel> Tags { get; set; }
    }
}
