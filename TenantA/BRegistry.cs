using StructureMap.Configuration.DSL;
using StructureMapLessons;

namespace TenantA
{
    public class ARegistry : Registry
    {
            public ARegistry()
            {
                For<IHandler>().Use<AHandle>();
                For<IPrint>().Use<PrintA>();
            }
    }
}