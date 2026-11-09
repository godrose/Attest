using Solid.Bootstrapping;
using Solid.Extensibility;

// ReSharper disable once CheckNamespace
#if REQNROLL
namespace Attest.Testing.Context.Reqnroll
#else
namespace Attest.Testing.Context.SpecFlow
#endif
{
    /// <summary>
    /// The bootstrapper extension methods.
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Registers dependencies required for using key value data store.
        /// </summary>
        /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns></returns>
        public static TBootstrapper UseKeyValueDataStore<TBootstrapper>(this TBootstrapper bootstrapper)
            where TBootstrapper : class, IHaveRegistrator, IExtensible<IHaveRegistrator>
        {
            bootstrapper.Use(new UseKeyValueDataStoreMiddleware<IHaveRegistrator>());
            return bootstrapper;
        }
    }
}
