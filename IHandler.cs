namespace StructureMapLessons
{
    public interface IHandler
    {
        string Handle();
    }

    public interface ICommonText
    {
        string GetCommonText();
    }

    public class CommonText : ICommonText
    {
        public string GetCommonText()
        {
            return "This is Tenant";
        }
    }
}