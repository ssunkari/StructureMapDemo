using StructureMap.Configuration.DSL;

namespace StructureMapLessons
{
    public class BaseRegistry :Registry
    {
        public BaseRegistry()
        {
            For<IDoJob>().Use<DoJob>();
            For<ICommonText>().Use<CommonText>();
        }
    }

    public interface IDoJob
    {
        string Run();
    }

    public class DoJob : IDoJob
    {
        private readonly IHandler _handler;

        public DoJob(IHandler handler)
        {
            _handler = handler;
        }

        public string Run()
        {
            return _handler.Handle();
        }
    }
}