using ReviewsApp.ViewModels.Review.Components;

namespace ReviewsApp.ViewModels.Review
{
    public class CreateReviewViewModel : BaseReviewViewModel
    {
        public string AuthorId { get; set; }

        public TagViewModel TagViewModel { get; set; }

        public string ImagesUrls { get; set; }
    }
}
