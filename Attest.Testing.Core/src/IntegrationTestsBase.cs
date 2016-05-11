using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Base class for all integration-tests fixtures that use ioc container adapter.
    /// </summary>
    /// <typeparam name="TContainerAdapter">The type of ioc container adapter.</typeparam>
    /// <typeparam name="TRootObject">The type of root object, from which the test's flow starts.</typeparam>    
    public abstract class IntegrationTestsBase<TContainerAdapter, TRootObject> : 
        TestsBase<TContainerAdapter>
        where TContainerAdapter : IIocContainer
        where TRootObject : class
    {                        
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
            return Resolver.Resolve<TRootObject>();
        }

        /// <summary>
        /// Override to modify the root object immediately after it has been created.
        /// </summary>
        /// <param name="rootObject">Newly created root object</param>
        /// <returns>Modified root object</returns>
        protected virtual TRootObject CreateRootObjectOverride(TRootObject rootObject)
        {
            return rootObject;
        }                
    }

    /// <summary>
    /// Base class for all integration-tests fixtures that use ioc container.
    /// </summary>
    /// <typeparam name="TContainer">The type of ioc container.</typeparam>
    /// <typeparam name="TContainerAdapter">The type of ioc container adapter.</typeparam>
    /// <typeparam name="TRootObject">The type of root object, from which the test's flow starts.</typeparam>
    public abstract class IntegrationTestsBase<TContainer, TContainerAdapter, TRootObject> : 
        IntegrationTestsBase<TContainerAdapter, TRootObject>
        where TContainerAdapter : IIocContainer, IIocContainerAdapter<TContainer>
        where TRootObject : class
    {        
    }
}
