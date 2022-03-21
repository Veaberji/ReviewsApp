namespace ReviewsApp.Models.Settings
{
    public class SearchConfigs
    {
        public static string EndpointUrl { get; set; }
        public static string ReviewsIndex { get; set; }
        public static string CommentsIndex { get; set; }
        public static string PreTag { get; set; }
        public static string PostTag { get; set; }
        public static string TitleNameInReviewsIndex { get; set; }
        public static string BodyNameInReviewsIndex { get; set; }
        public static string BodyNameInCommentsIndex { get; set; }

    }
}
