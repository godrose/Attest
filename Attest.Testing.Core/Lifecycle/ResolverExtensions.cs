using Attest.Testing.Modularity;
using Solid.Practices.IoC;

namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// The <see cref="IDependencyResolver"/> lifecycle-related extensions
    /// </summary>
    public static class ResolverExtensions
    {
        /// <summary>
        /// Initializes all instances of <see cref="ISetupService"/>
        /// </summary>
        /// <param name="dependencyResolver"></param>
        public static void Setup(this IDependencyResolver dependencyResolver)
        {
            var setupServices = dependencyResolver.ResolveAll<ISetupService>();
            foreach (var setupService in setupServices)
            {
                setupService.Setup();
            }
        }

        /// <summary>
        /// Ensures proper teardown of all instances of <see cref="ITeardownService"/>
        /// </summary>
        /// <param name="dependencyResolver"></param>
        public static void Teardown(this IDependencyResolver dependencyResolver)
        {
            var applicationModules = dependencyResolver.ResolveAll<IDynamicApplicationModule>();
            foreach (var applicationModule in applicationModules)
            {
                applicationModule.Stop();
            }
            var teardownServices = dependencyResolver.ResolveAll<ITeardownService>();
            foreach (var teardownService in teardownServices)
            {
                teardownService.Teardown();
            }
        }
    }
}
