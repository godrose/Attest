using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Factory for creating instances of <see cref="ServiceCall{TService}"/>. 
    /// Note that the newly created instances have no method calls.
    /// </summary>
    public static class ServiceCallFactory
    {
        /// <summary>
        /// Creates the service call without method calls.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="fake">The fake.</param>
        /// <returns></returns>
        public static IHaveNoMethods<TService> CreateServiceCall<TService>(IFake<TService> fake) where TService : class
        {
            return new ServiceCall<TService>(fake);
        }
    }
}