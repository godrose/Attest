using System.Collections.Generic;
using Attest.Testing.Contracts;
using Solid.Core;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Extension methods for <see cref="StartDynamicApplicationModuleService"/>
    /// </summary>
    public static class StartDynamicApplicationModuleServiceExtensions
    {
        /// <summary>
        /// Starts collection of <see cref="IDynamicApplicationModule"/>
        /// </summary>
        /// <param name="startDynamicApplicationModuleService">The means for starting a dynamic application module.</param>
        /// <param name="applicationModules">The collection of application modules.</param>
        public static void StartCollection(
            this IStartDynamicApplicationModuleService startDynamicApplicationModuleService,
            IEnumerable<IDynamicApplicationModule> applicationModules)
        {
            var sortedModules = applicationModules.SortTopologically();
            foreach (var module in sortedModules)
            {
                startDynamicApplicationModuleService.Start(module);
            }
        }
    }
}
