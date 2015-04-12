using StructureMapLessons;

namespace TenantA
{
    public class AHandle:IHandler
    {
        private readonly IPrint _print;

        public AHandle(IPrint print)
        {
            _print = print;
        }

        public string Handle()
        {
            return _print.GetLine();
        }
    }
}