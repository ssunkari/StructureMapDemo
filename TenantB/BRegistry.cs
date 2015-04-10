using StructureMapLessons;

namespace TenantB
{
    public class BRegistry : BaseRegistry
    {
            public BRegistry()
            {
                For<IHandler>().Use<BHandle>();
                For<IPrint>().Use<PrintB>();
            }
    }
}