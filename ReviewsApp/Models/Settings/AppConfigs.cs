namespace ReviewsApp.Models.Settings
{
    public class AppConfigs
    {
        public static string Title { get; set; }
        public static string DefaultTheme { get; set; }
        public static string ThemeCookie { get; set; }
        public static int CookieLivePeriodYears { get; set; }
        public static int PreviewBodySize { get; set; }
        public static int TopRatedReviewsAmount { get; set; }
    }
}
