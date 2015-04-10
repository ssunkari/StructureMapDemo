using System;
using System.IO;
using MultiTenant.Api.StructureMapConfig;
using StructureMap;
using TenantA;
using TenantB;

namespace MultiTenant.Api
{
    public static class ServiceBootstrapper
    {
        private static readonly string _productName = string.Empty;
        private static readonly string _appPath = new AssemblyDirectory().GetAssemblyDirectory() + "\\StructureMap";
        private static readonly string _environment = new ReadEnvironmentConfiguration().GetEnvironmentConfig();

        public static void Bootstrap()
        {
            ObjectFactory.Initialize(x => x.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                }
                                              ));


            var aContainer = new Container();


            aContainer.Configure(x => x.AddRegistry<ARegistry>());


            var bContainer = new Container();
            bContainer.Configure(x => x.AddRegistry<BRegistry>());

            ObjectFactory
                .Container.Configure(x =>
                    {
                        x.For<IContainer>().Use(GetImportConfigContainer()).Named("ImportConfig");
                        x.For<IContainer>().Use(aContainer).Named("A");
                        x.For<IContainer>().Use(bContainer).Named("B");
                    });
        }


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