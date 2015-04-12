using StructureMap.Configuration.DSL;
using StructureMapLessons;

namespace TenantB
{
    public class BRegistry : Registry
    {
            public BRegistry()
            {
                For<IHandler>().Use<BHandle>();
                For<IPrint>().Use<PrintB>();
            }
    }
}