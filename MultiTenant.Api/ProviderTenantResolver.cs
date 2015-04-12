using System.Collections.Generic;
using System.Linq;
using StructureMapLessons;

namespace MultiTenant.Api
{
    public class ProviderTenantResolver : ITenantResolver
    {
        private readonly string _value;

        public ProviderTenantResolver(string value)
        {
            _value = value;
        }

        public IApplicationTenant Resolve(IEnumerable<IApplicationTenant> tenants)
        {
            var valid = from tenant in tenants
                        where tenant.ProviderName.Equals(_value)
                select tenant;

            if (!valid.Any())
                throw new TenantNotFoundException();
            return valid.First();
        }
    }
}