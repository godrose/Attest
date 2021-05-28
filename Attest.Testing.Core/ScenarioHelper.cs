using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Wrapper class over the scenario context which provides concise API of adding and retrieving services
    /// as well as scenario initialization logic with respect to the root object and ioc container adapter.
    /// </summary>
    public class ScenarioHelper
    {
        private readonly RootObjectScenarioDataStore _scenarioDataStore;

        public ScenarioHelper(IKeyedDataStore keyedDataStore)
        {
            _scenarioDataStore = new RootObjectScenarioDataStore(keyedDataStore);
        }

        /// <summary>
        /// Initializes the <see cref="ScenarioContext"/>. with the provided container and root object factory.
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
            _scenarioDataStore.RootObject = rootObjectFactory.CreateRootObject();
        }
    }
}
