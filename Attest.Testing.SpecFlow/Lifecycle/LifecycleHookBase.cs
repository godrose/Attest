using Attest.Testing.Contracts;
using BoDi;
using Solid.Common;
using Solid.IoC.Adapters.BoDi;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle.SpecFlow
{
    /// <summary>
    /// Base class for lifecycle hook to be used during scenario run.
    /// Provides common yet extensible implementations for different lifecycle parts.
    /// </summary>
    public abstract class LifecycleHookBase
    {
        private readonly ObjectContainerAdapter _iocContainer;
        private static ILifecycleService _lifecycleService;

        /// <summary>
        /// Initializes a new instance of <see cref="LifecycleHookBase"/>
        /// </summary>
        /// <param name="objectContainer">The framework's IoC container.</param>
        protected LifecycleHookBase(ObjectContainer objectContainer) =>
            _iocContainer = new ObjectContainerAdapter(objectContainer);

        /// <summary>
        /// Runs once before all scenarios.
        /// </summary>
        [BeforeTestRun]
        public static void BeforeAllScenarios()
        {
            PlatformProvider.Current = new NetStandardPlatformProvider();
        }

        /// <summary>
        /// Runs before each scenario.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            InitializeContainer(_iocContainer);            
            BeforeScenarioOverride(_iocContainer);
            _lifecycleService = _iocContainer.Resolve<ILifecycleService>();
            _lifecycleService.Setup();
            _iocContainer.Setup();            
        }

        /// <summary>
        /// Override to initialize the IoC container with your dependencies.
        /// </summary>
        /// <param name="iocContainer">The IoC container.</param>
        protected abstract void InitializeContainer(IIocContainer iocContainer);
        
        /// <summary>
        /// Override to inject custom logic during scenario setup.
        /// </summary>
        /// <param name="iocContainer">The IoC container.</param>
        protected virtual void BeforeScenarioOverride(IIocContainer iocContainer)
        {

        }

        /// <summary>
        /// Runs after each scenario.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            _iocContainer.Teardown();
            AfterScenarioOverride(_iocContainer);
        }

        /// <summary>
        /// Override to inject custom logic during scenario teardown.
        /// </summary>
        /// <param name="iocContainer">The IoC container.</param>
        protected virtual void AfterScenarioOverride(IIocContainer iocContainer)
        {

        }

        /// <summary>
        /// Runs once after all scenarios.
        /// </summary>
        [AfterTestRun]
        public static void AfterAllScenarios()
        {
            _lifecycleService.Teardown();
        }
    }
}
