namespace StructureMapLessons
{
    public interface IProviderConfiguration
    {
        string ProviderName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string FtpUrl { get; set; }
        string ImagesUnc { get; set; }
        string ProcessedImagesUnc { get; set; }
        string processedImageURL { get; set; }
        string RoomInfo { get; set; }
    }
}