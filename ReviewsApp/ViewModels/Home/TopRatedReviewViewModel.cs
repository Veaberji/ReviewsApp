namespace ReviewsApp.ViewModels.Home
{
    public class TopRatedReviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string AuthorName { get; set; }
        public double? AverageUserRating { get; set; }
    }
}
