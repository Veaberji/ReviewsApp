namespace ReviewsApp.Models.Settings
{
    public class AppConfigs
    {
        public static string Title { get; set; }
        public static string DefaultTheme { get; set; }
        public static string ThemeCookie { get; set; }
        public static int CookieLivePeriodYears { get; set; }
        public static int TagCloudSize { get; set; }
        public static string AzureImagesContainer { get; set; }
        public static string BaseImagesUrl { get; set; }
        public static string DefaultImageUrl { get; set; }
        public static int MaxImageSizeInBytes { get; set; }
        public static int SizeToCutImageFileName { get; set; }
        public static int PaginationLinksAmount { get; set; }
    }
}
