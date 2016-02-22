using Attest.Fake.Builders;
using Attest.Fake.Core;
using Solid.Practices.IoC;

namespace Attest.Fake.Registration
{
    /// <summary>
    /// Provides utilities for registering different types of fake objects into IoC container
    /// </summary>
    public static class RegistrationHelper
    {
        /// <summary>
        /// Registers service instance into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="container">IoC container</param>
        /// <param name="instance">Instance to be registered</param>        
        public static void RegisterInstance<TService>(IIocContainer container, TService instance) where TService : class
        {
            container.RegisterInstance(instance);
        }

        /// <summary>
        /// Registers the service in the transient mode.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="container">The container.</param>
        public static void RegisterTransient<TService, TImplementation>(IIocContainer container)
            where TImplementation : class, TService
        {
            container.RegisterTransient<TService, TImplementation>();
        }

        /// <summary>
        /// Builds service from its builder and registers it into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="container">IoC container</param>
        /// <param name="builder">Service builder</param>
        public static void RegisterBuilder<TService>(IIocContainer container, FakeBuilderBase<TService> builder) where TService : class
        {
            container.RegisterHandler(builder.GetService);            
        }        

        /// <summary>
        /// Registers service fake into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="container">IoC container</param>
        /// <param name="fake">Fake to be registered</param>
        public static void RegisterFake<TService>(IIocContainer container, IFake<TService> fake) where TService : class
        {
            RegisterHaveFake(container, fake);
        }

        /// <summary>
        /// Registers service mock into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="container">IoC container</param>
        /// <param name="mock">Mock to be registered</param>
        public static void RegisterMock<TService>(IIocContainer container, IMock<TService> mock) where TService : class
        {
            RegisterHaveFake(container, mock);
        }

        private static void RegisterHaveFake<TService>(IIocContainer container, IHaveFake<TService> fake) where TService : class
        {
            RegisterInstance(container, fake.Object);
        }

        /// <summary>
        /// Resolves service from the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="container">IoC container</param>
        /// <returns>Resolved service</returns>
        public static TService Resolve<TService>(IIocContainer container) where TService : class
        {
            return container.Resolve<TService>();
        }
    }
}