namespace ReviewsApp.Models.Settings
{
    public class AppConfigs
    {
        public static string Title { get; set; }
        public static string DefaultTheme { get; set; }
        public static string ThemeCookie { get; set; }
        public static int CookieLivePeriodYears { get; set; }

        //todo: to TagCloudConfigs
        public static int TagCloudSize { get; set; }

        //todo: to ImageConfigs
        public static string AzureImagesContainer { get; set; }
        public static string BaseImagesUrl { get; set; }
        public static string DefaultImageUrl { get; set; }
        public static int SizeToCutImageFileName { get; set; }
        public static int MaxImageSizeInBytes { get; set; }
        public static int MaxImageSizeInMegaBytes { get; set; }
        public static int ImagesToUploadInParallel { get; set; }
        public static int MaxImages { get; set; }

        //todo: to PageConfigs
        public static int PaginationLinksAmount { get; set; }
        public static int PreviewsPerPage { get; set; }
        public static int PreviewBodySize { get; set; }
        public static int TopRatedReviewsAmount { get; set; }
    }
}
