using Attest.Testing.Core;
using Solid.Practices.IoC;
using ScenarioContext = TechTalk.SpecFlow.ScenarioContext;

namespace Attest.Testing.SpecFlow
{
    /// <summary>
    /// Wrapper class over the scenario context which adds root object-related services.
    /// </summary>
    public class ScenarioHelper
    {
        private readonly RootObjectScenarioDataStore _rootObjectScenarioDataStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioHelper"/> class.
        /// </summary>
        /// <param name="scenarioContext"></param>
        public ScenarioHelper(ScenarioContext scenarioContext)
        {
            _rootObjectScenarioDataStore = new RootObjectScenarioDataStore(scenarioContext);
        }

        internal void Initialize(
            IIocContainer iocContainer,
            IRootObjectFactory rootObjectFactory)
        {
            _rootObjectScenarioDataStore.Container = iocContainer;
            _rootObjectScenarioDataStore.RootObjectFactory = rootObjectFactory;
        }

        internal void Initialize(
            IIocContainer iocContainer)
        {
            _rootObjectScenarioDataStore.Container = iocContainer;
        }

        /// <summary>
        /// Creates the root object and adds it to the scenario context
        /// </summary>
        public void CreateRootObject()
        {
            var rootObjectFactory = _rootObjectScenarioDataStore.RootObjectFactory;
            _rootObjectScenarioDataStore.RootObject = rootObjectFactory.CreateRootObject();
        }
    }
}