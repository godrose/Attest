using Solid.Practices.IoC;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
{
    /// <summary>
    /// The dependency registrator extension methods.
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Registers dependencies required for using key value data store.
        /// </summary>
        /// <returns></returns>
        public static IDependencyRegistrator UseKeyValueDataStore(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IKeyValueDataStore, ScenarioContextKeyValueDataStoreAdapter>();
            return dependencyRegistrator;
        }
    }
}
