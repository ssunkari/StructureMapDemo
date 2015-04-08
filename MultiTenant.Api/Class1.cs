
using StructureMap;
using TenantA;
using TenantB;

namespace MultiTenant.Api
{
    public static class Bootstrapper
    {
        private static Container _container;

        public static void Bootstrap()
        {
            _container = new Container();
            _container.Configure(x=>
                {
                    x.Scan(scanner =>
                        {
                            scanner.TheCallingAssembly();
                            scanner.WithDefaultConventions();
                        }
                        );
                    x.AddRegistry<ARegistries>();
                    x.AddRegistry<BRegistries>();
                });
        }

    }
}