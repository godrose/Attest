using Solid.Bootstrapping;
using Solid.Extensibility;

namespace Attest.Testing.Integration
{
    /// <summary>
    /// The bootstrapper integration-related extension methods
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Registers dependencies required for integration tests.
        /// </summary>
        /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns></returns>
        public static TBootstrapper UseIntegration<TBootstrapper>(this TBootstrapper bootstrapper)
            where TBootstrapper : class, IHaveRegistrator, IExtensible<IHaveRegistrator>
        {
            bootstrapper.Use(new UseIntegrationMiddleware<IHaveRegistrator>());
            return bootstrapper;
        }

        /// <summary>
        /// Registers dependencies required for integration tests including start application service.
        /// </summary>
        /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
        /// <typeparam name="TStartApplicationService">The type of the start application service.</typeparam>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns></returns>
        public static TBootstrapper UseIntegration<TBootstrapper, TStartApplicationService>(this TBootstrapper bootstrapper)
            where TBootstrapper : class, IHaveRegistrator, IExtensible<IHaveRegistrator>
            where TStartApplicationService : StartApplicationServiceBase
        {
            bootstrapper.Use(new UseIntegrationMiddleware<IHaveRegistrator, TStartApplicationService>());
            return bootstrapper;
        }
    }
}
