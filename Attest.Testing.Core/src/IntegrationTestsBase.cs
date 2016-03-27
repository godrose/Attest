using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Base class for all integration-tests fixtures that involve real IoC container.
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container.</typeparam>
    /// <typeparam name="TRootObject">Type of root object, from whom the test's flow starts.</typeparam>
    public abstract class IntegrationTestsBase<TContainer, TRootObject> : TestsBase<TContainer>
        where TContainer : IIocContainer, new() where TRootObject : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTestsBase{TContainer, TRootObject}"/> class.
        /// </summary>
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

    /// <summary>
    /// Base class for all integration-tests fixtures that involve real IoC container.
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container.</typeparam>
    /// <typeparam name="TContainerAdapter">Type of IoC container adapter.</typeparam>
    /// <typeparam name="TRootObject">Type of root object, from whom the test's flow starts.</typeparam>
    public abstract class IntegrationTestsBase<TContainer, TContainerAdapter, TRootObject> : 
        IntegrationTestsBase<TContainerAdapter, TRootObject>
        where TContainerAdapter : IIocContainer, IIocContainerAdapter<TContainer>, new() 
        where TRootObject : class
    {        
    }
}
