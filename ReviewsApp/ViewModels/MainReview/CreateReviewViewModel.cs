using ReviewsApp.ViewModels.MainReview.Components;

namespace ReviewsApp.ViewModels.MainReview
{
    public class CreateReviewViewModel : BaseReviewViewModel
    {
        public TagViewModel TagViewModel { get; set; }

        public string ImagesUrls { get; set; }
    }
}
