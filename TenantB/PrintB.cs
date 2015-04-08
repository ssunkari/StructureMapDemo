using TenantA;

namespace TenantB
{
    public class PrintB :IPrint
    {
        public string Write()
        {
            return "This is tetant B";
        }
    }
}
