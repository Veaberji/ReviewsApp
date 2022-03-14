using System;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.MainReview
{
    public class ReviewDetailsViewModel : BaseReviewViewModel
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<string> ImagesUrls { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
