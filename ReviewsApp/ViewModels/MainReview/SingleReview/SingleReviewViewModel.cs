using System.Collections.Generic;

namespace ReviewsApp.ViewModels.MainReview.SingleReview
{
    public class SingleReviewViewModel
    {
        public PreviewViewModel Review { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
