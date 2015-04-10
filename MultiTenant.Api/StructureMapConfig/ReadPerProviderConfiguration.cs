using StructureMapLessons;

namespace MultiTenant.Api.StructureMapConfig
{
    public class PerProviderConfiguration : IProviderConfiguration
    {
        public string ProviderName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FtpUrl { get; set; }
        public string ImagesUnc { get; set; }
        public string ProcessedImagesUnc { get; set; }
        public string processedImageURL { get; set; }
        public string RoomInfo { get; set; }
    }
}