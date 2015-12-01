using Attest.Fake.Core;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    /// <summary>
    /// Base class for all integration-tests fixtures that involve real IoC container
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container</typeparam>
    /// <typeparam name="TFakeFactory">Type of fake factory</typeparam>
    /// <typeparam name="TRootObject">Type of root object, from whom the test's flow starts</typeparam>
    public abstract class IntegrationTestsBase<TContainer, TFakeFactory, TRootObject> : TestsBase<TContainer, TFakeFactory>
        where TContainer : IIocContainer, new()
        where TFakeFactory : IFakeFactory, new()
        where TRootObject : class
    {
        protected IntegrationTestsBase()
        {
            IocContainer = new TContainer();
        }

        /// <summary>
        /// This method creates the root object by resolving it from the IoC container
        /// </summary>
        /// <returns>Root object</returns>
        protected TRootObject CreateRootObject()
        {
            var rootObject = CreateRootObjectCore();
            return CreateRootObjectOverride(rootObject);
        }

        private TRootObject CreateRootObjectCore()
        {
            return Resolve<TRootObject>();
        }

        /// <summary>
        /// Provides additional opportunity to modify the root object immediately after is has been created
        /// </summary>
        /// <param name="rootObject">Newly created root object</param>
        /// <returns>Modified root object</returns>
        protected virtual TRootObject CreateRootObjectOverride(TRootObject rootObject)
        {
            return rootObject;
        }                
    }
}
