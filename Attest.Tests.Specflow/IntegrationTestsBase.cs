using System;
using Attest.Fake.Core;
using Attest.Tests.Core;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Attest.Tests.SpecFlow
{
    /// <summary>
    /// Base class for all integration-tests fixtures that involve real IoC container and test bootstrapper
    /// ans use SpecFlow as test framework provider
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container</typeparam>
    /// <typeparam name="TFakeFactory">Type of fake factory</typeparam>
    /// <typeparam name="TRootObject">Type of root object, from whom the test's flow starts</typeparam>
    /// <typeparam name="TBootstrapper">Type of bootstrapper</typeparam>
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
            //First a new instance of the IoC container created for each test run
            IocContainer = new TContainer();
            //Then the bootstrapper is instantiated - its signature is constrained to have the IoC container as its only parameter
            Activator.CreateInstance(typeof(TBootstrapper), IocContainer);
            //Then the scenario helper is initialized with the new instance of the IoC container and the root object factory
            ScenarioHelper.Initialize(IocContainer, this);
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
        /// Provides additional opportunity to modify the test teardown logic
        /// </summary>
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
