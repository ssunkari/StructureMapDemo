using TenantA;
using TenantB;

namespace MultiTenant.Api.StructureMapConfig
{
    public class TenantBConfiguration : PerApplicationTenant
    {
        public TenantBConfiguration()
        {
            TenantRegistry = new BRegistry();
        }
    }
}