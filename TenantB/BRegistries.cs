using StructureMapLessons;

namespace TenantB
{
    public class BRegistries : ServiceRegistry
    {
            public BRegistries()
            {
                For<IHandler>().Use<BHandle>();
                For<IPrint>().Use<PrintB>();
            }
    }
}