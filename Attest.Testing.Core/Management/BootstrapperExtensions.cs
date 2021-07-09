using Solid.Bootstrapping;
using Solid.Extensibility;

namespace Attest.Testing.Management
{
    /// <summary>
    /// The bootstrapper process management-related extension methods
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Registers dependencies required for process management.
        /// </summary>
        /// <typeparam name="TBootstrapper"></typeparam>
        /// <typeparam name="TProcessManagementService"></typeparam>
        /// <param name="bootstrapper"></param>
        /// <returns></returns>
        public static TBootstrapper UseManagement<TBootstrapper, TProcessManagementService>(
            this TBootstrapper bootstrapper)
            where TBootstrapper : class, IHaveRegistrator, IExtensible<IHaveRegistrator>
            where TProcessManagementService : class, IProcessManagementService
        {
            bootstrapper.Use(new UseManagementMiddleware<TProcessManagementService>());
            return bootstrapper;
        }
    }
}
