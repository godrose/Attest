using Attest.Testing.Contracts;
using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// The <see cref="IDependencyRegistrator"/> local application-related extensions
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Uses local application for integration.
        /// </summary>
        /// <param name="dependencyRegistrator"></param>
        /// <returns></returns>
        public static IDependencyRegistrator UseLocalApplicationForIntegration(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<IStartLocalApplicationService, Integration.StartLocalApplicationService>();
            return dependencyRegistrator;
        }

        /// <summary>
        /// Uses local application for end-to-end
        /// </summary>
        /// <param name="dependencyRegistrator"></param>
        /// <returns></returns>
        public static IDependencyRegistrator UseLocalApplicationForEndToEnd(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<IStartLocalApplicationService, EndToEnd.StartLocalApplicationService>();
            return dependencyRegistrator;
        }
    }
}
