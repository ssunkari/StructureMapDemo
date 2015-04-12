using System;
using System.Collections.Generic;
using StructureMap;

namespace MultiTenant.Api
{
    public class ProviderTypeMap
    {
        public readonly Dictionary<Type, ITypeResolver> _typeDictionary = new Dictionary<Type, ITypeResolver>();

        public IEnumerable<Type> MappedTypes
        {
            get { return _typeDictionary.Keys; }
        }

        public void SetMapping<TFor, TUse>()
            where TUse : TFor
        {
            if (_typeDictionary.ContainsKey(typeof (TFor)))
            {
                _typeDictionary[typeof (TFor)] = new TypeResolver<TUse>();
            }
            else
            {
                _typeDictionary.Add(typeof (TFor), new TypeResolver<TUse>());
            }
        }
        public T Resolve<T>(IContext context)
        {
            var type = typeof(T);
            if (_typeDictionary.ContainsKey(type))
            {
                return (T)_typeDictionary[type].ResolveFrom(context);
            }
            return default(T);
            //  IProviderConfiguration configuration = context.GetInstance<IProviderConfiguration>();
            // throw new ResolverException(type, configuration.ProviderName);
        }

        public bool ContainsType<T>()
        {
            return _typeDictionary.ContainsKey(typeof(T));
            
        }
    }
}