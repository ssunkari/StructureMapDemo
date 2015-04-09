using StructureMap;
using TenantA;
using TenantB;

namespace MultiTenant.Api
{
    public static class ServiceBootstrapper
    {

        public static void Bootstrap()
        {
            ObjectFactory.Initialize(x=>
                {
                    x.Scan(scanner =>
                        {
                            scanner.TheCallingAssembly();
                            scanner.WithDefaultConventions();
                        }
                        );
                });
          
            var AContainer = new Container();
            
            AContainer.Configure(x =>
                {
                    x.AddRegistry<ARegisteries>();
                });
            

            var BContainer = new Container();
            BContainer.Configure(x =>
            {
                x.AddRegistry<BRegistries>();
            });
            

            ObjectFactory
                .Container.Configure(x => {
                    
                    x.For<IContainer>().Use(AContainer).Named("A");
                    x.For<IContainer>().Use(BContainer).Named("B");
                });
        }
    }
}