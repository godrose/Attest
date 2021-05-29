using Solid.Bootstrapping;
using Solid.Extensibility;

namespace Attest.Testing.SpecFlow
{
    /// <summary>
    /// The bootstrapper extension methods.
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Registers dependencies required for using key value store.
        /// </summary>
        /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns></returns>
        public static TBootstrapper UseKeyValueStore<TBootstrapper>(this TBootstrapper bootstrapper)
            where TBootstrapper : class, IHaveRegistrator, IExtensible<IHaveRegistrator>
        {
            bootstrapper.Use(new UseKeyValueStoreMiddleware<IHaveRegistrator>());
            return bootstrapper;
        }
    }
}
