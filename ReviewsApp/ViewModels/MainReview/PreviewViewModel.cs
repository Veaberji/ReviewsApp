using System;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.MainReview
{
    public class PreviewViewModel : BaseReviewViewModel
    {
        public DateTime DateAdded { get; set; }
        public string AuthorName { get; set; }
        public double? AverageUserRating { get; set; }
        public string PreviewImageUrl { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
