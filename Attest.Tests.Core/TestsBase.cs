using Attest.Fake.Builders;
using Attest.Fake.Core;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    /// <summary>
    /// Base class for tests
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container</typeparam>
    public abstract class TestsBase<TContainer>
        where TContainer : IIocContainer, new()
    {       
        /// <summary>
        /// IoC container
        /// </summary>
        protected TContainer IocContainer;

        /// <summary>
        /// Override this method to implement custom test setup logic
        /// </summary>
        protected abstract void Setup();

        /// <summary>
        /// Override this method to implement custom test teardown logic
        /// </summary>
        protected abstract void TearDown();

        /// <summary>
        /// Registers service instance into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="instance">Instance to be registered</param>
        protected void RegisterInstance<TService>(TService instance) where TService : class
        {
            TestsHelper.RegisterInstance(IocContainer, instance);
        }

        /// <summary>
        /// Registers service builder into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="builder">Builder to be registered</param>
        protected void RegisterBuilder<TService>(FakeBuilderBase<TService> builder) where TService : class
        {
            TestsHelper.RegisterBuilder(IocContainer, builder);
        }        

        /// <summary>
        /// Registers service fake into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="fake">Fake to be registered</param>
        protected void RegisterFake<TService>(IFake<TService> fake) where TService : class
        {
            TestsHelper.RegisterFake(IocContainer, fake);
        }

        /// <summary>
        /// Registers service mock into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="fake">Mock to be registered</param>
        protected void RegisterMock<TService>(IMock<TService> fake) where TService : class
        {
            TestsHelper.RegisterMock(IocContainer, fake);
        }

        /// <summary>
        /// Resolves service from the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <returns>Resolved service</returns>
        protected TService Resolve<TService>() where TService : class
        {
            return TestsHelper.Resolve<TService>(IocContainer);
        }
    }
}
