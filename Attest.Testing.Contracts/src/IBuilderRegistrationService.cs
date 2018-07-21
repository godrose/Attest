using Solid.Patterns.Builder;

namespace Attest.Testing.Contracts
{
    /// <summary>
    /// The builder registration service.
    /// </summary>
    public interface IBuilderRegistrationService
    {
        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="builder">The builder.</param>
        void RegisterBuilder<TService>(IBuilder<TService> builder) where TService : class;
    }
}
