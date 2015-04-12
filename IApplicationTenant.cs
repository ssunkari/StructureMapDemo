using System;
using System.Collections.Generic;
using StructureMap;

namespace StructureMapLessons
{
    public interface IApplicationTenant
    {
        string ProviderName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string FtpUrl { get; set; }
        string ImagesUnc { get; set; }
        string ProcessedImagesUnc { get; set; }
        string processedImageURL { get; set; }
        string RoomInfo { get; set; }
         string Name { get; set; }
         IContainer DependencyContainer { get; }

        void InitializeContainer(Action<ConfigurationExpression> customExpression);
    }
}