using StructureMap;
using StructureMap.Configuration.DSL;

namespace StructureMapLessons
{
    public interface IBar { }
    public class Bar : IBar { }
    public interface IFoo { }

    public class Foo : IFoo
    {
        public IBar Bar { get; private set; }

        public Foo(IBar bar)
        {
            Bar = bar;
        }

        public void Init()
        {

            var container1 = new Container(c =>
            {
                c.For<IFoo>().Use<Foo>();
                c.For<IBar>().Use<Bar>();
            });

            var container = new Container(c =>
                                          c.Scan(scanner =>
                                              {
                                                  scanner.TheCallingAssembly();
                                                  scanner.WithDefaultConventions();
                                              }));

        }

        public class FooBarRegistry : Registry
        {
            public FooBarRegistry()
            {
                For<IFoo>().Use<Foo>();
                For<IBar>().Use<Bar>();
            }
        }
    }


}
