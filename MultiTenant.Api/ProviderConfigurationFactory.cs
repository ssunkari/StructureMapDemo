using System.Linq;
using StructureMap;
using StructureMapLessons;

namespace MultiTenant.Api
{
    public static class ProviderConfigurationFactory
    {
        public static IProviderConfiguration GetInstance(string providerName)
        {
            if (InstanceExists(providerName))
                return ObjectFactory.GetNamedInstance<IProviderConfiguration>(providerName);

            return ObjectFactory.GetInstance<IProviderConfiguration>();
        }

        private static bool InstanceExists(string providerName)
        {
            var instanceExists = ObjectFactory.Model.InstancesOf<IProviderConfiguration>().Any(
                instance => instance.Name == providerName);
            return instanceExists;
        }
    }
}