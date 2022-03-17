using ReviewsApp.ViewModels.MainReview.Components;
using System.Collections.Generic;

namespace ReviewsApp.ViewModels.MainReview.SingleReview
{
    public class ReviewPageViewModel
    {
        public ReviewViewModel Review { get; set; }
        public StarRatingViewModel StarRating { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public CreateCommentViewModel CreateComment { get; set; }
    }
}
