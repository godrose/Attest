using Attest.Testing.Contracts;
using Attest.Testing.Core;
using Attest.Testing.DataStore;
using Solid.Practices.IoC;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Integration
{
    /// <summary>
    /// The <see cref="IDependencyRegistrator"/> integration-related extensions.
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Registers dependencies required for integration tests.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <returns></returns>
        public static IDependencyRegistrator UseIntegration(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .AddSingleton<ScenarioHelper>()
                .AddSingleton<RootObjectScenarioDataStore>()
                .UseLocalApplicationForIntegration();
            return dependencyRegistrator;
        }

        /// <summary>
        /// Uses local application for integration.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <returns></returns>
        public static IDependencyRegistrator UseLocalApplicationForIntegration(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<IStartLocalApplicationService, StartLocalApplicationService>();
            return dependencyRegistrator;
        }
    }
}
