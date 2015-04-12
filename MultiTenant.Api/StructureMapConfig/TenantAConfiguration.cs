using TenantA;

namespace MultiTenant.Api.StructureMapConfig
{
    public class TenantAConfiguration : PerApplicationTenant
    {
        public TenantAConfiguration()
        {
            TenantRegistry = new ARegistry();
        }
    }
}