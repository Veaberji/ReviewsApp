using System.Collections.Generic;

namespace ReviewsApp.ViewModels.MainReview
{
    public class ReviewEditViewModel : CreateReviewViewModel
    {
        public int Id { get; set; }
        public List<string> OldImagesUrls { get; set; }
        public string ImagesToDelete { get; set; }
    }
}
