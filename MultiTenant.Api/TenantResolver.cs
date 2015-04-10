using System.Linq;
using MultiTenant.Api.StructureMapConfig;
using StructureMapLessons;

namespace MultiTenant.Api
{
    public static class TenantResolver
    {
        public static TProviderType Resolve<TProviderType>(string providerName)
            where TProviderType : class
        {
            var providerConfiguration = TenantFactory.GetNamedContainerInstance(providerName);
            return providerConfiguration.With<IProviderConfiguration>(GetImportConfiguration(providerName)).GetInstance<TProviderType>();
        }

        private static IProviderConfiguration GetImportConfiguration(string providerName)
        {
            var container = TenantFactory.GetNamedContainerInstance("ImportConfig");
            if (container.Model.InstancesOf<IProviderConfiguration>().Any(x => x.Name == providerName))
                return container.GetInstance<IProviderConfiguration>(providerName);
            return new PerProviderConfiguration();
        }
    }
}