using StructureMap;

namespace MultiTenant.Api
{
    public class TenantFactory 
    {
        public static IContainer GetNamedContainer(string value)
        {
            var factory = ObjectFactory.GetInstance<IContainerResolver>();
           return factory.Resolve(new ProviderTenantResolver(value));
        }
    }
}