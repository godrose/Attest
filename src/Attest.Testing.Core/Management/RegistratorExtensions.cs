using Solid.Practices.IoC;

namespace Attest.Testing.Management
{
    /// <summary>
    /// The <see cref="IDependencyRegistrator"/> process management-related extensions.
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Registers dependencies required for integration tests.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <returns></returns>
        public static IDependencyRegistrator UseManagement<TProcessManagementService>(this IDependencyRegistrator dependencyRegistrator)
            where TProcessManagementService : class, IProcessManagementService
        {
            dependencyRegistrator.AddSingleton<IProcessManagementService, TProcessManagementService>();
            return dependencyRegistrator;
        }
    }
}
