using StructureMapLessons;

namespace TenantB
{
    public class PrintB : IPrint
    {
        private readonly ICommonText _common;

        public PrintB()//(ICommonText common)
        {
            //_common = common;
        }

        public string GetLine()
        {
            return "Hello" + "B";
        }
    }
}
