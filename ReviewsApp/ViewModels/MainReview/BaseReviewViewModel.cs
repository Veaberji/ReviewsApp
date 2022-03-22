using ReviewsApp.ViewModels.MainReview.Components;

namespace ReviewsApp.ViewModels.MainReview
{
    public class BaseReviewViewModel
    {
        public virtual string Title { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public virtual string Body { get; set; }
        public virtual int AuthorGrade { get; set; }
    }
}
