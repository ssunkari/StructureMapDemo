using System.Collections.Generic;
using StructureMap;
using StructureMapLessons;

namespace MultiTenant.Api
{
    public class TenantContainerResolver : IContainerResolver
    {
        public IEnumerable<IApplicationTenant> Tenants { get; private set; }

        public TenantContainerResolver(IEnumerable<IApplicationTenant> tenants)
        {
            this.Tenants = tenants;
        }

        public IContainer Resolve(ITenantResolver resolver)
        {
            return resolver.Resolve(this.Tenants).DependencyContainer;
        }
    }
}