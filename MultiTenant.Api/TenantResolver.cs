namespace MultiTenant.Api
{
    public class TenantResolver{

        public static TProviderType Resolve<TProviderType>(string providerName)
            where TProviderType : class
        {
            var tenantContainer = TenantFactory.GetNamedContainer(providerName);
            return tenantContainer.GetInstance<TProviderType>();
        }
    }
}