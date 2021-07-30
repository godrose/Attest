using System;
using System.Collections.Generic;
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
            setupServices.ForEachSafe(t => t.Setup());
        }

        /// <summary>
        /// Ensures proper teardown of all instances of <see cref="ITeardownService"/>
        /// </summary>
        /// <param name="dependencyResolver"></param>
        public static void Teardown(this IDependencyResolver dependencyResolver)
        {
            var applicationModules = dependencyResolver.ResolveAll<IDynamicApplicationModule>();
            applicationModules.ForEachSafe(t => t.Stop());

            var teardownServices = dependencyResolver.ResolveAll<ITeardownService>();
            teardownServices.ForEachSafe(t => t.Teardown());
        }

        //TODO: Move to Solid.Core - Collection Extensions
        private static void ForEachSafe<T>(this IEnumerable<T> collection, Action<T> itemAction)
        {
            if (collection == null) return;
            foreach (var item in collection)
            {
                itemAction(item);
            }
        }
    }
}
