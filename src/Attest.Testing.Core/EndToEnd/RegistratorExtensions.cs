using Attest.Testing.Lifecycle;
using Solid.Practices.IoC;

namespace Attest.Testing.EndToEnd
{
    /// <summary>
    /// The <see cref="IDependencyRegistrator"/> end-to-end related extensions.
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Uses local application for end-to-end.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <returns></returns>
        public static IDependencyRegistrator UseLocalApplicationForEndToEnd(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<IStartLocalApplicationService, StartLocalApplicationService>();
            return dependencyRegistrator;
        }
    }
}
