using System;
using StructureMap;

namespace MultiTenant.Api
{
    public interface ITypeResolver
    {
        object ResolveFrom(IContext context);
    }
    public class TypeResolver<TUse> : ITypeResolver
    {
        public object ResolveFrom(IContext context)
        {
            try
            {
                return context.GetInstance<TUse>();
            }
            catch (InvalidCastException)
            {
                /*
                     * HACK: This is one of those occasions that really deserves a comment
                     * Generally the context.GetInstance<TUse>() will work correctly. it's not quite what
                     * we want as we don't care about generics here, but this is all that structuremap gives us.
                     * however, if you bring spring into the mix, things are different. spring introspection
                     * will insert proxies which sidestep all the type safety stuff which means it cannot be
                     * casted to a type of TUse. so...
                     * the concrete implementation of IContext is BuildSession and the implementation of 
                     * GetInstance<T> is return (T) this.CreateInstance(typeof(T))
                     * it's 'orrible, but we expose this.
                     * */
                var buildSesson = context as BuildSession;
                if (buildSesson != null)
                    return buildSesson.CreateInstance(typeof(TUse));
            }

            return null;
        }
    }
}