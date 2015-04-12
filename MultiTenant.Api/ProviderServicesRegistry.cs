using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StructureMap.Configuration.DSL;
using StructureMapLessons;

namespace MultiTenant.Api
{
    public class ProviderServicesRegistry :Registry
    {
        public ProviderServicesRegistry()
        {
            var configurePerProviderTypes = new ConfigurePerProviderTypes();

            configurePerProviderTypes.ConfigureFor(this);
        }
         
    }

    public class ConfigurePerProviderTypes
    {
        private Registry _registry;

        public void ConfigureFor(Registry registry)
        {
            _registry = registry;

            _registry.Scan(scanner =>
            {
                scanner.AssemblyContainingType(_registry.GetType());
                scanner.WithDefaultConventions();
            });

            Configure();
        }

        private void Configure()
        {
            var types = from config in GetAllProviderConfigurations()
                        from type in config.GetConfiguredTypes()
                        select type;

            Configure(types.Distinct());
        }

        private void Configure(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                AddPerProviderType(type);
            }
        }

        private IEnumerable<IProviderConfiguration> GetAllProviderConfigurations()
        {
            try
            {
                var assembly = _registry.GetType().Assembly;
                var types = assembly.GetTypes();

                return from type in types
                       where !type.IsAbstract && type.IsClass
                             && typeof(IProviderConfiguration).IsAssignableFrom(type)
                       select (IProviderConfiguration)ConstructInstance(type);
            }
            catch (ReflectionTypeLoadException exception)
            {
                throw new Exception();
                //throw new ProviderConfigurationException(exception.LoaderExceptions);
            }

        }

        private static object ConstructInstance(Type configType)
        {
            var constructor = configType.GetConstructors()[0];
            var nullParams = from p in constructor.GetParameters()
                             select (object)null;
            return constructor.Invoke(nullParams.ToArray());
        }

        private void AddPerProviderType(Type type)
        {
            // note:   we need to invoke the generic version via reflection
            // note:   because the StructureMap DSL doesn't provide the methods
            // note:   we need when we configure using type objects. :( 
            var addOverridableType = GetType()
                .GetMethod("AddPerProviderType")
                .MakeGenericMethod(type);

            addOverridableType.Invoke(this, new object[] { });
        }

        public void AddPerProviderType<T>()
        {
            //System.Diagnostics.Debug.WriteLine("Per provider type: " + typeof(T).FullName);
            _registry.For<T>().TheDefault.Is.ConstructedBy(
                context =>
#if DEBUG
                {
                    var configuration = context.GetInstance<IProviderConfiguration>();
                    if (configuration.Specifies<T>())
                    {
                        return configuration.ResolveFromContext<T>(context);
                    }
                    throw new ApplicationException(
                        string.Format("Provider '{0}' does not specify requested type '{1}'"
                                      , configuration.ProviderName
                                      , typeof(T)));
                }
#else
                     context.GetInstance<IProviderConfiguration>().ResolveFromContext<T>(context)
#endif
);
        }
    }
}