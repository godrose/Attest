using System.Collections.Generic;
using System.Reflection;
using Solid.IoC.Registration;
using Solid.Practices.IoC;

namespace Attest.Testing.Context
{
    /// <summary>
    /// The dependency registrator extensions.
    /// </summary>
    public static class RegistratorExtensions
    {
        private const string ScenarioDataStoreEnding = "ScenarioDataStore";

        /// <summary>
        /// Registers scenario data stores according to their contracts.
        /// </summary>
        /// <param name="dependencyRegistrator"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IDependencyRegistrator RegisterScenarioDataStoresAsContracts(
            this IDependencyRegistrator dependencyRegistrator,
            IEnumerable<Assembly> assemblies)
        {
            dependencyRegistrator.RegisterImplementationsAsContracts(assemblies, assembliesCollection => assembliesCollection.FindTypesByEnding(ScenarioDataStoreEnding),                
                RegistrationMethodContext.GetDefaultRegistrationMethod<IDependencyRegistrator>());
            return dependencyRegistrator;
        }
    }
}
