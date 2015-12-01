using Attest.Fake.Core;
using Attest.Tests.Core;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Attest.Tests.SpecFlow
{
    /// <summary>
    /// Base class for all integration-tests fixtures that involve real IoC container and test bootstrapper
    /// and use SpecFlow as test framework provider
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container</typeparam>
    /// <typeparam name="TFakeFactory">Type of fake factory</typeparam>    
    public abstract class EndToEndTestsBase<TContainer, TFakeFactory> : Core.EndToEndTestsBase<TContainer, TFakeFactory> 
        where TContainer : IIocContainer, new() 
        where TFakeFactory : IFakeFactory, new()
    {
        private readonly IInitializationParametersManager<TContainer> _initializationParametersManager;

        protected EndToEndTestsBase(TContainer container)
        {
            _initializationParametersManager = new InitializationParametersManager<TContainer>(container);
        }

        [BeforeScenario]
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        [AfterScenario]
        protected override void TearDown()
        {
            OnBeforeTeardown();
            TearDownCore();
            OnAfterTeardown();
        }

        private void SetupCore()
        {
            var initializationParameters = _initializationParametersManager.GetInitializationParameters();            
            IocContainer = initializationParameters.IocContainer;            
            //Then the scenario helper is initialized with the new instance of the IoC container
            ScenarioHelper.Initialize(IocContainer);
        }

        /// <summary>
        /// Provides additional opportunity to modify the test setup logic
        /// </summary>
        protected virtual void SetupOverride()
        {

        }

        private void TearDownCore()
        {
            ScenarioHelper.Clear();            
        }

        /// <summary>
        /// Called when the teardown starts
        /// </summary>
        protected virtual void OnBeforeTeardown()
        {
            
        }

        /// <summary>
        /// Called when the teardown finishes
        /// </summary>
        protected virtual void OnAfterTeardown()
        {
            
        }                
    }
}
