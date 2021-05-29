using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Represents data store for integration tests with root object.
    /// </summary>
    public class RootObjectScenarioDataStore : ScenarioDataStoreBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RootObjectScenarioDataStore"/>.
        /// </summary>
        /// <param name="keyValueDataStore"></param>
        public RootObjectScenarioDataStore(IKeyValueDataStore keyValueDataStore)
            :base(keyValueDataStore)
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

        /// <summary>
        /// Gets the root object.
        /// </summary>
        public object RootObject
        {
            get => GetValueImpl<object>();
            internal set => SetValueImpl(value);
        }
    }
}
