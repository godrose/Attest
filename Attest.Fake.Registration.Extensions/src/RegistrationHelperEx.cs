using Attest.Fake.Core;
using Solid.Practices.IoC;

namespace Attest.Fake.Registration.Extensions
{
    /// <summary>
    /// Provides extended utilities for registering different types of fake objects into IoC container
    /// </summary>
    public static class RegistrationHelperEx<TFakeFactory> where TFakeFactory : IFakeFactory, new()
    {
        private static readonly TFakeFactory FakeFactory = new TFakeFactory();

        /// <summary>
        /// Registers service stub into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="container">IoC container</param>        
        public static void RegisterStub<TService>(IIocContainer container) where TService : class
        {
            container.RegisterInstance(FakeFactory.CreateFake<TService>());            
        }
    }
}
