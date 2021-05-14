using Attest.Fake.Data;
using Attest.Testing.Contracts;
using Attest.Testing.Core;
using BoDi;
using Solid.Common;
using Solid.IoC.Adapters.BoDi;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Attest.Testing.SpecFlow
{
    public abstract class LifecycleHookBase
    {
        private readonly ObjectContainerAdapter _iocContainer;
        private static ILifecycleService _lifecycleService;

        protected LifecycleHookBase(ObjectContainer objectContainer) =>
            _iocContainer = new ObjectContainerAdapter(objectContainer);

        [BeforeTestRun]
        public static void BeforeAllScenarios()
        {
            PlatformProvider.Current = new NetStandardPlatformProvider();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            InitializeContainer(_iocContainer);
            //TODO: Should be initialized once
            BuildersCollectionStorageContext.Current = _iocContainer.Resolve<IDataStorage<string>>();
            _lifecycleService = _iocContainer.Resolve<ILifecycleService>();
            _lifecycleService.Setup();
            _iocContainer.Setup();
            BeforeScenarioOverride(_iocContainer);
        }

        protected abstract void InitializeContainer(IIocContainer iocContainer);
        
        protected virtual void BeforeScenarioOverride(IIocContainer iocContainer)
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            _iocContainer.Teardown();
            AfterScenarioOverride(_iocContainer);
        }

        protected virtual void AfterScenarioOverride(IIocContainer iocContainer)
        {

        }

        [AfterTestRun]
        public static void AfterAllScenarios()
        {
            _lifecycleService.Teardown();
        }
    }
}
