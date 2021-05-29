using Attest.Testing.DataStore;
using Solid.Practices.IoC;

namespace Attest.Testing.SpecFlow
{
    /// <summary>
    /// The dependency registrator extension methods.
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Registers dependencies required for using key value store.
        /// </summary>
        /// <returns></returns>
        public static IDependencyRegistrator UseKeyValueStore(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IKeyValueDataStore, ScenarioContextKeyValueDataStoreAdapter>();
            return dependencyRegistrator;
        }
    }
}
