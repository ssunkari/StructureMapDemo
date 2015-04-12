using StructureMapLessons;

namespace TenantB
{
    public class PrintB : IPrint
    {
        private readonly ICommonText _common;
        private readonly IApplicationTenant _applicationTenant;

        public PrintB(ICommonText common, IApplicationTenant applicationTenant)
        {
            _common = common;
            _applicationTenant = applicationTenant;
        }

        public string GetLine()
        {
            return _common.GetCommonText() + "B" + _applicationTenant.ProviderName;
        }
    }
}
