using Attest.Tests.Core;
using NUnit.Framework;
using Solid.Practices.IoC;

namespace Attest.Tests.NUnit
{
    /// <summary>
    /// Base class for all End-To-End tests that use NUnit as test framework provider
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container</typeparam>
    public abstract class EndToEndTestsBase<TContainer> : Core.EndToEndTestsBase<TContainer>
        where TContainer : IIocContainer, new()
    {
        private readonly IInitializationParametersManager<TContainer> _initializationParametersManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndToEndTestsBase{TContainer}"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        protected EndToEndTestsBase(TContainer container)
        {
            _initializationParametersManager = new InitializationParametersManager<TContainer>(container);
            ScenarioContext.Current = new Scenario();
        }

        /// <summary>
        /// Override this method to implement custom test setup logic
        /// </summary>
        [SetUp]
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        /// <summary>
        /// Override this method to implement custom test teardown logic
        /// </summary>
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
