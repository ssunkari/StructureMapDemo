using System;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMapLessons;

namespace MultiTenant.Api.StructureMapConfig
{
    public class PerApplicationTenant : IApplicationTenant
    {
        private IContainer _container;
        public string ProviderName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FtpUrl { get; set; }
        public string ImagesUnc { get; set; }
        public string ProcessedImagesUnc { get; set; }
        public string processedImageURL { get; set; }
        public string RoomInfo { get; set; }

        public string Name { get; set; }

        public Registry TenantRegistry = new Registry();



        public IContainer DependencyContainer
        {
            get { return _container; }
        }


        public void InitializeContainer(Action<ConfigurationExpression> customExpression = null)
        {
            ; _container = new Container();
            _container.Configure(config =>
            {
                config.AddRegistry(TenantRegistry);
                config.For<IApplicationTenant>().Singleton().Use(this);
                if (customExpression != null)
                    customExpression(config);
            });
        }
    }
}