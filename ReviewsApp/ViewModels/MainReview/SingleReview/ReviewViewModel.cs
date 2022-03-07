using System.Collections.Generic;

namespace ReviewsApp.ViewModels.MainReview.SingleReview
{
    public class ReviewViewModel : PreviewViewModel
    {
        public IEnumerable<string> ImagesUrls { get; set; }
        public int TotalLikes { get; set; }
        public bool IsLikedByCurrentUser { get; set; }
    }
}
