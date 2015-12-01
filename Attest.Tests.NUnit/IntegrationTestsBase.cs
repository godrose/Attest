using Attest.Fake.Core;
using Attest.Tests.Core;
using NUnit.Framework;
using Solid.Practices.IoC;

namespace Attest.Tests.NUnit
{
    /// <summary>
    /// Base class for all integration-tests fixtures that involve real IoC container and test bootstrapper
    /// and use NUnit as test framework provider
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container</typeparam>
    /// <typeparam name="TFakeFactory">Type of fake factory</typeparam>
    /// <typeparam name="TRootObject">Type of root object, from whom the test's flow starts</typeparam>
    /// <typeparam name="TBootstrapper">Type of bootstrapper</typeparam>
    public abstract class IntegrationTestsBase<TContainer, TFakeFactory, TRootObject, TBootstrapper> : 
        IntegrationTestsBase<TContainer, TFakeFactory, TRootObject>        
        where TContainer : IIocContainer, new()
        where TFakeFactory : IFakeFactory, new() 
        where TRootObject : class         
    {
        private readonly IInitializationParametersManager<TContainer> _initializationParametersManager;

        protected IntegrationTestsBase(InitializationParametersResolutionStyle resolutionStyle = InitializationParametersResolutionStyle.PerRequest)
        {
            _initializationParametersManager =
                InitializationParametersManagerStore<TBootstrapper, TContainer>.GetInitializationParametersManager(
                    resolutionStyle);
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
            TearDownCore();
            TearDownOverride();
        }

        private void SetupCore()
        {
            var initializationParameters = _initializationParametersManager.GetInitializationParameters();
            IocContainer = initializationParameters.IocContainer;            
        }

        /// <summary>
        /// Provides additional opportunity to modify the test setup logic
        /// </summary>
        protected virtual void SetupOverride()
        {
            
        }

        private void TearDownCore()
        {
            IocContainer.Dispose();
            //Dispose();
        }

        /// <summary>
        /// Provides additional opportunity to modify the test teardown logic
        /// </summary>
        protected virtual void TearDownOverride()
        {
            
        }        
    }
}
