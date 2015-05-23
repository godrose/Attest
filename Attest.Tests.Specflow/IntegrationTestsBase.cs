using System;
using Attest.Fake.Core;
using Attest.Tests.Core;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Attest.Tests.Specflow
{
    interface IRootObjectFactory
    {
        object CreateRootObject();
    }    

    public abstract class IntegrationTestsBase<TContainer, TFakeFactory, TRootObject, TBootstrapper> :
        IntegrationTestsBase<TContainer, TFakeFactory, TRootObject>,
        IRootObjectFactory
        where TContainer : IIocContainer, new()
        where TFakeFactory : IFakeFactory, new()
        where TRootObject : class
    {        
        [BeforeScenario]
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        [AfterScenario]
        protected override void TearDown()
        {
            TearDownCore();
            TearDownOverride();
        }

        private void SetupCore()
        {
            IocContainer = new TContainer();
            Activator.CreateInstance(typeof(TBootstrapper), IocContainer);
            ScenarioHelper.Initialize(IocContainer, this);
        }

        protected virtual void SetupOverride()
        {

        }

        private void TearDownCore()
        {
            ScenarioHelper.Clear();
        }

        protected virtual void TearDownOverride()
        {

        }

        private TRootObject CreateRootObjectTyped()
        {
            return CreateRootObject();
        }

        object IRootObjectFactory.CreateRootObject()
        {
            return CreateRootObjectTyped();
        }
    }
}
