using Attest.Testing.Core;
using Solid.Practices.IoC;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context
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
            get => GetValue<IDependencyRegistrator>();
            set => SetValue(value);
        }

        internal IDependencyResolver Resolver
        {
            get => GetValue<IDependencyResolver>();
            set => SetValue(value);
        }

        internal IRootObjectFactory RootObjectFactory
        {
            get => GetValue<IRootObjectFactory>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets the root object.
        /// </summary>
        public object RootObject
        {
            get => GetValue<object>();
            internal set => SetValue(value);
        }
    }
}
