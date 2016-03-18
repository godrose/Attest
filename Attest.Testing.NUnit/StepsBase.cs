using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Registration;
using Attest.Testing.Core;
using Solid.Practices.IoC;

namespace Attest.Testing.NUnit
{
    /// <summary>
    /// Base class for step-containing classes, primarily used for [Given] steps
    /// </summary>
    public abstract class StepsBase
    {
        /// <summary>
        /// Registers service instance into the scenario context
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="instance">Instance to be registered</param>
        protected void RegisterInstance<TService>(TService instance) where TService : class
        {
            RegistrationHelper.RegisterInstance(GetIocContainer(), instance);
        }

        /// <summary>
        /// Registers the service and its implementation types in a transient manner
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        public static void RegisterTransient<TService, TImplementation>()
            where TImplementation : class, TService
        {
            RegistrationHelper.RegisterTransient<TService, TImplementation>(GetIocContainer());
        }

        /// <summary>
        /// Builds service from its builder and registers it into the IoC container
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="builder">Builder to be registered</param>
        protected void RegisterBuilder<TService>(FakeBuilderBase<TService> builder) where TService : class
        {
            RegistrationHelper.RegisterBuilder(GetIocContainer(), builder);
        }        

        /// <summary>
        /// Registers service fake into the scenario context
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="fake">Fake to be registered</param>
        protected void RegisterFake<TService>(IFake<TService> fake) where TService : class
        {
            RegistrationHelper.RegisterFake(GetIocContainer(), fake);
        }

        /// <summary>
        /// Registers service mock into the scenario context
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <param name="fake">Mock to be registered</param>
        protected void RegisterMock<TService>(IMock<TService> fake) where TService : class
        {
            RegistrationHelper.RegisterMock(GetIocContainer(), fake);
        }

        /// <summary>
        /// Resolves steps provider by type
        /// </summary>
        /// <typeparam name="TStepsProvider">Type of steps provider</typeparam>
        /// <returns>Steps provider</returns>
        protected TStepsProvider GetStepsProvider<TStepsProvider>() where TStepsProvider : class, IStepsProvider
        {
            return ScenarioHelper.Get<TStepsProvider>();
        }

        private static IIocContainer GetIocContainer()
        {
            return ScenarioHelper.Container;
        }
    }
}
