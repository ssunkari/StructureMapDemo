using StructureMapLessons;

namespace TenantB
{
    public class BHandle:IHandler
    {
        private readonly IPrint _print;

        public BHandle(IPrint print)
        {
            _print = print;
        }

        public string Handle()
        {
            return _print.GetLine();
        }
    }
}