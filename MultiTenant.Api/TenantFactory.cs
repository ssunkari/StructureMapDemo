using System.Linq;
using StructureMap;

namespace MultiTenant.Api
{
    public static class TenantFactory
    {
        public static IContainer GetNamedContainerInstance(string value)
        {
            if (InstanceExists(value))
                return ObjectFactory.GetNamedInstance<IContainer>(value);

            return ObjectFactory.GetInstance<IContainer>();
        }

        private static bool InstanceExists(string value)
        {
            var instanceExists = ObjectFactory.Model.InstancesOf<IContainer>().Any(
                instance => instance.Name == value);
            return instanceExists;
        }
    }
}