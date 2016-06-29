using System;

namespace Attest.Fake.Builders
{
    /// <summary>
    /// Base class for data/model providers
    /// </summary>
    /// <typeparam name="TBuilder">Type of builder</typeparam>
    /// <typeparam name="TService">Type of service</typeparam>
    public abstract class FakeProviderBase<TBuilder, TService>
        where TService : class
        where TBuilder : FakeBuilderBase<TService>
    {
        /// <summary>
        /// Gets an instance of the faked service, after the builder setup is applied
        /// </summary>
        /// <param name="createBuilder">Builder instantiation function</param>
        /// <param name="setupBuilder">Builder setup function</param>
        /// <returns>Instance of service after the setup is applied</returns>
        protected TService GetService(Func<TBuilder> createBuilder, Func<TBuilder, TBuilder> setupBuilder)
        {
            var builder = createBuilder();
            builder = setupBuilder(builder);
            return builder.GetService();
        }
    }
}
