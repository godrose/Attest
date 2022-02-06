using Attest.Testing.Bootstrapping;

namespace Attest.Testing.Context
{
    /// <summary>
    /// Bootstrapper extensions.
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Allows using scenario data stores.
        /// </summary>
        /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns></returns>
        public static TBootstrapper UseScenarioDataStores<TBootstrapper>(this TBootstrapper bootstrapper)
            where TBootstrapper : BootstrapperBase
        {
            bootstrapper.Use(new UseScenarioDataStoresMiddleware<BootstrapperBase>());
            return bootstrapper;
        }
    }
}
