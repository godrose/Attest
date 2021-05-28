using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    public class RootObjectScenarioDataStore : ScenarioDataStoreBase
    {
        public RootObjectScenarioDataStore(IKeyedDataStore keyedDataStore)
            :base(keyedDataStore)
        {
            
        }

        internal IDependencyRegistrator Registrator
        {
            get => GetValueImpl<IDependencyRegistrator>();
            set => SetValueImpl(value);
        }

        internal IDependencyResolver Resolver
        {
            get => GetValueImpl<IDependencyResolver>();
            set => SetValueImpl(value);
        }

        internal IRootObjectFactory RootObjectFactory
        {
            get => GetValueImpl<IRootObjectFactory>();
            set => SetValueImpl(value);
        }

        public object RootObject
        {
            get => GetValueImpl<object>();
            internal set => SetValueImpl(value);
        }
    }
}
