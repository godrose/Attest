using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Helper class which provides initialization logic with respect to the root object and ioc container adapter.
    /// </summary>
    public class ScenarioHelper
    {
        private readonly RootObjectScenarioDataStore _scenarioDataStore;

        /// <summary>
        /// Initializes a new instance of <see cref="ScenarioHelper"/>
        /// </summary>
        /// <param name="keyValueDataStore"></param>
        public ScenarioHelper(IKeyValueDataStore keyValueDataStore)
        {
            _scenarioDataStore = new RootObjectScenarioDataStore(keyValueDataStore);
        }

        /// <summary>
        /// Initializes the service data store with the provided container and root object factory.
        /// </summary>
        /// <param name="iocContainer">The ioc container.</param>
        /// <param name="rootObjectFactory">The root object factory.</param>
        public void Initialize(
            IIocContainer iocContainer,
            IRootObjectFactory rootObjectFactory)
        {
            _scenarioDataStore.Registrator = iocContainer;
            _scenarioDataStore.Resolver = iocContainer;
            _scenarioDataStore.RootObjectFactory = rootObjectFactory;
        }

        /// <summary>
        /// Creates the root object and stores it in the scenario data store.
        /// </summary>
        public void CreateRootObject()
        {
            var rootObjectFactory = _scenarioDataStore.RootObjectFactory;
            var rootObject = rootObjectFactory.CreateRootObject();
            _scenarioDataStore.RootObject = rootObject;
        }
    }
}
