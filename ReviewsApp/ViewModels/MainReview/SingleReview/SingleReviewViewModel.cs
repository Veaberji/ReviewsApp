using ReviewsApp.ViewModels.MainReview.Components;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.MainReview.SingleReview
{
    public class SingleReviewViewModel
    {
        public ReviewViewModel Review { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public CreateCommentViewModel CreateComment { get; set; }

    }
}
