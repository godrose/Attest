using Attest.Fake.Builders;
using Attest.Fake.Core;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    /// <summary>
    /// Provides utilities for registering different types of service-related objects into IoC container
    /// </summary>
    /// <typeparam name="TFakeFactory">Type of fake factory</typeparam>
    public static class IntegrationTestsHelper<TFakeFactory> where TFakeFactory : IFakeFactory, new()
    {
        private static readonly TFakeFactory FakeFactory = new TFakeFactory();

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
        /// Registers service bulder into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="container">IoC container</param>
        /// <param name="builder">Builder to be registered</param>
        public static void RegisterBuilder<TService>(IIocContainer container, FakeBuilderBase<TService> builder) where TService : class
        {
            RegisterInstance(container, builder.GetService());
        }

        /// <summary>
        /// Registers service stub into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="container">IoC container</param>        
        public static void RegisterStub<TService>(IIocContainer container) where TService : class
        {
            RegisterFake(container, FakeFactory.CreateFake<TService>());
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