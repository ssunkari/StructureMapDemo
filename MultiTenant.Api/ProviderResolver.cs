namespace MultiTenant.Api
{
    public class ProviderResolver : IProviderResolver
    {
        public TProviderType Resolve<TProviderType>(string providerName)
            where TProviderType : class
        {
            var providerConfiguration = ProviderConfigurationFactory.GetInstance(providerName);
            return providerConfiguration.Resolve<TProviderType>();
        }
    }
}