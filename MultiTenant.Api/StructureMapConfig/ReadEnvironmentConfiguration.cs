using System;
using System.IO;
using System.Reflection;
using StructureMap;

namespace MultiTenant.Api.StructureMapConfig
{
    public class ReadEnvironmentConfiguration 
    {
        readonly string _appPath = new AssemblyDirectory().GetAssemblyDirectory() + "\\StructureMap";
        public string GetEnvironmentConfig()
        {
            var container = new Container();
            container.Configure(config => config.AddConfigurationFromXmlFile(_appPath + "\\Environment.config"));
            return container.GetInstance<EnvironmentConfiguration>().Environment;
        }
    }

    public class AssemblyDirectory
    {
        public string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}