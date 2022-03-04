using ReviewsApp.ViewModels.MainReview.Components;

namespace ReviewsApp.ViewModels.MainReview
{
    public class CreateReviewViewModel : BaseReviewViewModel
    {
        public string AuthorId { get; set; }

        public TagViewModel TagViewModel { get; set; }

        public string ImagesUrls { get; set; }
    }
}
