using Attest.Fake.Core;
using Attest.Fake.Registration;
using Solid.Patterns.Builder;
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
            /// The dependency registrator.
            /// </summary>
            protected IDependencyRegistrator Registrator;

            /// <summary>
            /// The dependency resolver.
            /// </summary>
            protected IDependencyResolver Resolver;

            /// <summary>
            /// Registers dependency instance.
            /// </summary>
            /// <typeparam name="TDependency">Type of service.</typeparam>
            /// <param name="instance">Instance to be registered.</param>
            protected void RegisterInstance<TDependency>(TDependency instance) where TDependency : class
            {
                RegistrationHelper.RegisterInstance(Registrator, instance);
            }

            /// <summary>
            /// Constructs the dependency using the supplied builder and registers it in transient mode.
            /// </summary>
            /// <typeparam name="TDependency">The type of the dependency.</typeparam>
            /// <param name="builder">Builder to be registered.</param>
            protected void RegisterBuilderProduct<TDependency>(IBuilder<TDependency> builder) where TDependency : class
            {
                RegistrationHelper.RegisterBuilderProduct(Registrator, builder);
            }

            /// <summary>
            /// Registers dependency using fake wrapper.
            /// </summary>
            /// <typeparam name="TDependency">The type of the dependency.</typeparam>
            /// <param name="fake">Fake wrapper.</param>
            protected void RegisterFake<TDependency>(IFake<TDependency> fake) where TDependency : class
            {
                RegistrationHelper.RegisterFake(Registrator, fake);
            }

            /// <summary>
            /// Registers dependency using mock wrapper.
            /// </summary>
            /// <typeparam name="TDependency">The type of the dependency.</typeparam>
            /// <param name="mock">Mock wrapper.</param>
            protected void RegisterMock<TDependency>(IMock<TDependency> mock) where TDependency : class
            {                
                RegistrationHelper.RegisterMock(Registrator, mock);
            }

            /// <summary>
            /// Resolves dependency.
            /// </summary>
            /// <typeparam name="TDependency">The type of the dependency.</typeparam>
            /// <returns>The resolved dependency.</returns>
            protected TDependency Resolve<TDependency>() where TDependency : class
            {
                return RegistrationHelper.Resolve<TDependency>(Resolver);
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
