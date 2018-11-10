using Solid.Patterns.Builder;

namespace LogoFX.Client.Testing.Contracts
{
    /// <summary>
    /// The Builders should be registered via this API
    /// </summary>
    public interface IBuilderRegistrationService
    {
        /// <summary>
        /// Registers the builder into IoC container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="builder">The builder.</param>
        void RegisterBuilder<TService>(IBuilder<TService> builder) where TService : class;
    }
}
