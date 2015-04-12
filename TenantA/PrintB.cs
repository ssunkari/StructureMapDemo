using StructureMapLessons;

namespace TenantA
{
    public class PrintA : IPrint
    {
        private readonly ICommonText _common;
        private readonly IApplicationTenant _providerConfiguration;

        public PrintA(ICommonText common, IApplicationTenant providerConfiguration)
        {
            _common = common;
            _providerConfiguration = providerConfiguration;
        }

        public string GetLine()
        {
            return _common.GetCommonText() + "A"+ _providerConfiguration.ProviderName;
        }
    }
}
