using Attest.Testing.Core;
using TechTalk.SpecFlow;
using ScenarioContext = TechTalk.SpecFlow.ScenarioContext;

namespace Attest.Testing.SpecFlow
{
    /// <summary>
    /// Base class for all End-To-End tests that use SpecFlow as test framework provider.
    /// </summary>    
    public abstract class EndToEndTestsBase : Core.EndToEndTestsBase
    {
        private readonly ScenarioHelper _scenarioHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndToEndTestsBase"/> class.
        /// </summary>        
        protected EndToEndTestsBase(ScenarioContext scenarioContext)
        {
            _scenarioHelper = new ScenarioHelper(new ScenarioContextKeyValueDataStoreAdapter(scenarioContext));
        }

        /// <summary>
        /// Override this method to implement custom test setup logic.
        /// </summary>
        [BeforeScenario]
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        /// <summary>
        /// Override this method to implement custom test teardown logic.
        /// </summary>
        [AfterScenario]
        protected override void TearDown()
        {
            OnBeforeTeardown();
            TearDownCore();
            OnAfterTeardown();
        }

        private void SetupCore()
        {           
        }

        /// <summary>
        /// Provides additional opportunity to modify the test setup logic.
        /// </summary>
        protected virtual void SetupOverride()
        {

        }

        private void TearDownCore()
        {
            
        }

        /// <summary>
        /// Override to inject custom logic before the teardown starts.
        /// </summary>
        protected virtual void OnBeforeTeardown()
        {
            
        }

        /// <summary>
        /// Override to inject custom logic after the teardown finishes.
        /// </summary>
        protected virtual void OnAfterTeardown()
        {
            
        }                
    }
}
