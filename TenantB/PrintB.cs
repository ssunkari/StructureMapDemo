using StructureMapLessons;

namespace TenantB
{
    public class PrintB : IPrint
    {
        private readonly ICommonText _common;
        private readonly IProviderConfiguration _providerConfiguration;

        public PrintB(ICommonText common, IProviderConfiguration providerConfiguration)
        {
            _common = common;
            _providerConfiguration = providerConfiguration;
        }

        public string GetLine()
        {
            return _common.GetCommonText() + "B" + _providerConfiguration.ProviderName;
        }
    }
}
