using System;
using System.IO;
using MultiTenant.Api.StructureMapConfig;
using StructureMap;
using StructureMapLessons;

namespace MultiTenant.Api
{
    public static class ServiceBootstrapper
    {
        private static readonly string _productName = string.Empty;
        private static readonly string _appPath = new AssemblyDirectory().GetAssemblyDirectory() + "\\StructureMap";

        public static void Bootstrap()
        {
            var importConfig = GetImportConfigContainer();
            var tenants = importConfig.GetAllInstances<IApplicationTenant>();

            foreach (var tenant in tenants)
           {
                tenant.InitializeContainer(
                    config =>
                    {
                       config.AddRegistry<BaseRegistry>();
                    }
                    );

            } 
             ObjectFactory.Initialize(

                 config =>
                 {
                     config.For<IContainerResolver>()
                         .TheDefault.Is.ConstructedBy(() => new TenantContainerResolver(tenants));
                     config.Scan(scanner =>
                     {
                         scanner.TheCallingAssembly();
                         scanner.WithDefaultConventions();
                     });
                 });
            
           
        }

        private static readonly string _environment = new ReadEnvironmentConfiguration().GetEnvironmentConfig();


        private static IContainer GetImportConfigContainer()
        {
            var container = new Container();
            container.Configure(AddXmlConfiguration);
            return container;
        }


        private static void AddXmlConfiguration(ConfigurationExpression configurationExpression)
        {
            var firstPart = _productName == string.Empty ? "*." :
                String.Format("{0}.StructureMap.", _productName);

            AddConfigFilesMatchingPattern(firstPart + _environment + ".config", configurationExpression);
        }

        private static void AddConfigFilesMatchingPattern(string filePattern, ConfigurationExpression configurationExpression)
        {
            var dir = new DirectoryInfo(_appPath);
            foreach (FileInfo file in dir.GetFiles(filePattern))
            {
                configurationExpression.AddConfigurationFromXmlFile(file.FullName);
            }
        }
    }
}