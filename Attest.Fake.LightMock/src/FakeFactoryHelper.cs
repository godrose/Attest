using System;
using Attest.Fake.Core;
using LightMock;

namespace Attest.Fake.LightMock
{
    /// <summary>
    /// Helper class for creating fake instances.
    /// </summary>
    public static class FakeFactoryHelper
    {
        /// <summary>
        /// Creates the fake using the specified proxy creator method.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="proxyCreator">The proxy creator method.</param>
        /// <returns>Fake instance.</returns>
        public static IFake<TService> CreateFake<TService>(Func<IInvocationContext<TService>, TService> proxyCreator)
            where TService : class
        {
            var context = new MockContext<TService>();
            var proxy = proxyCreator(context);
            return new Fake<TService>(proxy, context);
        }
    }
}