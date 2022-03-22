namespace ReviewsApp.Models.Settings;

public class ImageConfigs
{
    public static string AzureImagesContainer { get; set; }
    public static string BaseImagesUrl { get; set; }
    public static string DefaultImageUrl { get; set; }
    public static int SizeToCutImageFileName { get; set; }
    public static int MaxImageSizeInBytes { get; set; }
    public static int MaxImageSizeInMegaBytes { get; set; }
    public static int ImagesToUploadInParallel { get; set; }
    public static int MaxImages { get; set; }
}