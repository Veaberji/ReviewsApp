using ReviewsApp.ViewModels.MainReview.Components;
using System;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.MainReview
{
    public class PreviewViewModel : BaseReviewViewModel
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public AuthorViewModel Author { get; set; }
        public double? AverageUserRating { get; set; }
        public string PreviewImageUrl { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public int TotalRates { get; set; }
    }
}
