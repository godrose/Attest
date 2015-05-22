using System;
using Attest.Fake.Core;
using Attest.Tests.Core;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Attest.Tests.Specflow
{
    public abstract class IntegrationTestsBase<TContainer, TFakeFactory, TRootObject, TBootstrapper> :
        IntegrationTestsBase<TContainer, TFakeFactory, TRootObject>
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
        }

        protected virtual void SetupOverride()
        {

        }

        private void TearDownCore()
        {
            //Dispose();
        }

        protected virtual void TearDownOverride()
        {

        }        
    }
}
