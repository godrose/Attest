using Solid.Bootstrapping;
using Solid.Extensibility;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.FakeData
{
    /// <summary>
    /// The bootstrapper fake builders-related extension methods
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Registers dependencies required to use fake builders.
        /// </summary>
        /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns></returns>
        public static TBootstrapper UseBuilders<TBootstrapper>(this TBootstrapper bootstrapper)
            where TBootstrapper : class, IHaveRegistrator, IExtensible<IHaveRegistrator>
        {
            bootstrapper.Use(new UseBuildersMiddleware<IHaveRegistrator>());
            return bootstrapper;
        }
    }
}
