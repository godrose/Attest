using Attest.Fake.Core;
using Attest.Tests.Core;
using NUnit.Framework;
using Solid.Practices.IoC;

namespace Attest.Tests.NUnit
{
    /// <summary>
    /// Base class for all End-To-End tests that use NUnit as test framework provider
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
            ScenarioContext.Current = new Scenario();
        }

        [SetUp]
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        [TearDown]
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
