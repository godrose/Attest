using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Registration;
using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Base class for all tests.
    /// </summary>
    public abstract class TestsBase
    {
        /// <summary>
        /// Base class for tests with ioc container adapter.
        /// </summary>        
        public abstract class WithContainer : TestsBase
        {
            /// <summary>
            /// The ioc container registrator.
            /// </summary>
            protected IIocContainerRegistrator Registrator;

            /// <summary>
            /// The ioc container resolver.
            /// </summary>
            protected IIocContainerResolver Resolver;

            /// <summary>
            /// Registers service instance into the ioc container adapter.
            /// </summary>
            /// <typeparam name="TService">Type of service.</typeparam>
            /// <param name="instance">Instance to be registered.</param>
            protected void RegisterInstance<TService>(TService instance) where TService : class
            {
                RegistrationHelper.RegisterInstance(Registrator, instance);
            }

            /// <summary>
            /// Builds service from its builder and registers it into the ioc container adapter.
            /// </summary>
            /// <typeparam name="TService">Type of service.</typeparam>
            /// <param name="builder">Builder to be registered.</param>
            protected void RegisterBuilder<TService>(IBuilder<TService> builder) where TService : class
            {
                RegistrationHelper.RegisterBuilder(Registrator, builder);
            }

            /// <summary>
            /// Registers service fake into the ioc container adapter.
            /// </summary>
            /// <typeparam name="TService">Type of service.</typeparam>
            /// <param name="fake">Fake to be registered.</param>
            protected void RegisterFake<TService>(IFake<TService> fake) where TService : class
            {
                RegistrationHelper.RegisterFake(Registrator, fake);
            }

            /// <summary>
            /// Registers service mock into the ioc container adapter.
            /// </summary>
            /// <typeparam name="TService">Type of service.</typeparam>
            /// <param name="fake">Mock to be registered.</param>
            protected void RegisterMock<TService>(IMock<TService> fake) where TService : class
            {                
                RegistrationHelper.RegisterMock(Registrator, fake);
            }

            /// <summary>
            /// Resolves service from the ioc container adapter.
            /// </summary>
            /// <typeparam name="TService">Type of service.</typeparam>
            /// <returns>Resolved service.</returns>
            protected TService Resolve<TService>() where TService : class
            {
                return RegistrationHelper.Resolve<TService>(Resolver);
            }
        }

        /// <summary>
        /// Override this method to implement custom test setup logic.
        /// </summary>
        protected abstract void Setup();

        /// <summary>
        /// Override this method to implement custom test teardown logic.
        /// </summary>
        protected abstract void TearDown();
    }    
}
