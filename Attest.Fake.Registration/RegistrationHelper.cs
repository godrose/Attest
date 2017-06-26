using System;
using Attest.Fake.Builders;
using Attest.Fake.Core;
using Solid.Practices.IoC;

namespace Attest.Fake.Registration
{
    /// <summary>
    /// Provides utilities for registering different types of fake objects into IoC containerRegistrator
    /// </summary>
    public static class RegistrationHelper
    {
        /// <summary>
        /// Registers service instance into the ioc container.
        /// </summary>
        /// <typeparam name="TService">The type of service.</typeparam>
        /// <param name="containerRegistrator">The ioc container registrator.</param>
        /// <param name="instance">The instance to be registered.</param>        
        public static void RegisterInstance<TService>(IIocContainerRegistrator containerRegistrator, TService instance) where TService : class
        {
            containerRegistrator.RegisterInstance(instance);
        }

        /// <summary>
        /// Registers the service in the singleton mode.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="containerRegistrator">The ioc container registrator.</param>
        public static void RegisterSingleton<TService, TImplementation>(IIocContainerRegistrator containerRegistrator)
            where TImplementation : class, TService
        {
            containerRegistrator.RegisterSingleton<TService, TImplementation>();
        }

        /// <summary>
        /// Registers the service in the transient mode.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="containerRegistrator">The ioc container registrator.</param>
        public static void RegisterTransient<TService, TImplementation>(IIocContainerRegistrator containerRegistrator)
            where TImplementation : class, TService
        {
            containerRegistrator.RegisterTransient<TService, TImplementation>();
        }

        /// <summary>
        /// Builds service from its builder and registers it into the ioc container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="containerRegistrator">The ioc container registrator.</param>
        /// <param name="builder">The service builder.</param>
        public static void RegisterBuilder<TService>(IIocContainerRegistrator containerRegistrator, IBuilder<TService> builder) where TService : class
        {
            containerRegistrator.RegisterTransient(builder.Build);            
        }

        /// <summary>
        /// Builds service from its builder and registers it into the ioc container.
        /// </summary>        
        /// <param name="containerRegistrator">The ioc container registrator.</param>
        /// <param name="serviceType">The type of the service.</param>
        /// <param name="builder">The service builder.</param>
        public static void RegisterBuilder(IIocContainerRegistrator containerRegistrator,Type serviceType, IBuilder builder)
        {
            containerRegistrator.RegisterTransient(serviceType, serviceType, builder.Build);
        }

        /// <summary>
        /// Registers service fake into the ioc container registrator.
        /// </summary>
        /// <typeparam name="TService">The type of service.</typeparam>
        /// <param name="containerRegistrator">The ioc container registrator.</param>
        /// <param name="fake">The fake to be registered.</param>
        public static void RegisterFake<TService>(IIocContainerRegistrator containerRegistrator, IFake<TService> fake) where TService : class
        {
            RegisterHaveFake(containerRegistrator, fake);
        }

        /// <summary>
        /// Registers service mock into the ioc container registrator.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="containerRegistrator">The ioc container registrator.</param>
        /// <param name="mock">The mock to be registered.</param>
        public static void RegisterMock<TService>(IIocContainerRegistrator containerRegistrator, IMock<TService> mock) where TService : class
        {
            RegisterHaveFake(containerRegistrator, mock);
        }

        private static void RegisterHaveFake<TService>(IIocContainerRegistrator containerRegistrator, IHaveFake<TService> fake) where TService : class
        {
            RegisterInstance(containerRegistrator, fake.Object);
        }

        /// <summary>
        /// Resolves service from the ioc container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="containerResolver">The ioc container resolver.</param>
        /// <returns>The resolved service.</returns>
        public static TService Resolve<TService>(IIocContainerResolver containerResolver) where TService : class
        {
            return containerResolver.Resolve<TService>();
        }
    }
}