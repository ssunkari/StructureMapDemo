using StructureMap.Configuration.DSL;
using TenantA;

namespace TenantB
{
    public class BRegistries : Registry
    {
            public BRegistries()
            {
                For<IPrint>().Use<PrintB>();
            }
    }
}