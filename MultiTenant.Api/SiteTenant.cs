using System;
using System.Collections.Generic;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMapLessons;

namespace MultiTenant.Api
{
    public class SiteTenant : IApplicationTenant
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
        public string Theme { get; set; }
        public IEnumerable<string> Urls { get; set; }



        public IContainer DependencyContainer
        {
            get { return _container; }
        }


        public void InitializeContainer(Action<ConfigurationExpression> customExpression = null)
        {
            _container = new Container();
            _container.Configure(config =>
            {
                config.For<IApplicationTenant>().Singleton().Use(this);
                AddConfigurataion(config);
                if (customExpression != null)
                    customExpression(config);
            });
        }

        private void AddConfigurataion(ConfigurationExpression config)
        {
           
        }
    }

    public interface ITenantConfiguration
    {
    }
   

    public class FakeTenantRepository : ITenantRepository
    {
        public IList<SiteTenant> Tenants
        {
            get
            {
                var tenants = new List<SiteTenant> {
                new SiteTenant
                {
                    Name = "A",
                    Theme = "Default",
                    Urls = new List<string>() { "http://localhost:53825/" },
                   
                },
                new SiteTenant {
                    Name = "B",
                    Theme = "Custom",
                    Urls = new List<string>() { "http://beta.mywebsite.com:53825/" }
                }
            };
                return tenants;
            }
        }
    }


    public class ATenant: SiteTenant
    {
        private IRegistry _registry;

        public ATenant(IRegistry registry)
        {
           
        }
    }

    public interface ITenantRepository
    {
        IList<SiteTenant> Tenants { get; }
    }

    public interface IContainerResolver

    {
        IContainer Resolve(ITenantResolver resolver);
    }

    public interface ITenantResolver
    {
        IApplicationTenant Resolve(IEnumerable<IApplicationTenant> tenants);
    }

    public class TenantNotFoundException : Exception
    {
    }
   /* public interface IProviderResolver
    {
        TProviderType Resolve<TProviderType>(string providerName)
            where TProviderType : class;
    }*/
}