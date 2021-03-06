using Attest.Testing.Context;
using Attest.Testing.Core;
using Attest.Testing.Lifecycle;

namespace Attest.Testing.Integration
{
    /// <summary>
    /// Represents start application service for integration tests.
    /// </summary>
    /// <seealso cref="IStartApplicationService" />    
    public class StartApplicationServiceBase : IStartApplicationService
    {
        private readonly ScenarioHelper _scenarioHelper;
        private readonly RootObjectScenarioDataStore _rootObjectScenarioDataStore;

        /// <summary>
        /// Initializes a new instance of <see cref="StartApplicationServiceBase"/>.
        /// </summary>
        /// <param name="scenarioHelper"></param>
        /// <param name="rootObjectScenarioDataStore"></param>
        public StartApplicationServiceBase(
            ScenarioHelper scenarioHelper,
            RootObjectScenarioDataStore rootObjectScenarioDataStore)
        {
            _scenarioHelper = scenarioHelper;
            _rootObjectScenarioDataStore = rootObjectScenarioDataStore;
        }

        /// <inheritdoc />        
        public void Start(string startupPath)
        {
            Setup();
            _scenarioHelper.CreateRootObject();
            OnStart(_rootObjectScenarioDataStore.RootObject);
        }

        /// <summary>
        /// Override this method to perform setup functionality before the application starts.
        /// </summary>
        protected virtual void Setup()
        {            
        }

        /// <summary>
        /// Override this method to inject custom logic with regard to the application root object 
        /// immediately after the object has been created.
        /// </summary>
        /// <param name="rootObject">The root object.</param>
        protected virtual void OnStart(object rootObject)
        {            
        }
    }
}