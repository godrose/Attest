using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Common;
using Solid.Practices.Composition;
using Solid.Practices.IoC;

namespace Attest.Fake.Conventions
{
    /// <summary>
    /// Helpers methods for batch convention-based registration 
    /// </summary>
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Registers fake providers' implementations into the provided dependency registrator.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        public static void RegisterFakeProviders(this IDependencyRegistrator dependencyRegistrator)
        {
            var assembliesProvider = new CustomAssemblySourceProvider(PlatformProvider.Current.GetRootPath(), null,
                new[] { ConventionsManager.ContractsAssemblyEnding(), ConventionsManager.FakeAssemblyEnding() });
            var allAssemblies = assembliesProvider.Assemblies.ToArray();
            var contractTypes = allAssemblies.FindContractTypes();
            var fakeTypes = allAssemblies.FindFakeTypes();
            var contractToFakeMatches = new Dictionary<Type, Type>();
            foreach (var type in fakeTypes)
            {
                var contractType =
                    contractTypes.FirstOrDefault(
                        t => t.Name == "I" + type.Name.Replace(ConventionsManager.FakePrefix(), string.Empty));
                if (contractType != null)
                {
                    contractToFakeMatches.Add(contractType, type);
                }
            }

            foreach (var contractToFakeMatch in contractToFakeMatches)
            {
                dependencyRegistrator.RegisterSingleton(contractToFakeMatch.Key, contractToFakeMatch.Value);
            }
        }

        /// <summary>
        /// Registers providers' builders into the provided dependency registrator.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        public static IDependencyRegistrator RegisterBuilders(this IDependencyRegistrator dependencyRegistrator)
        {
            var assembliesProvider = new CustomAssemblySourceProvider(PlatformProvider.Current.GetRootPath(), null,
                new[] { ConventionsManager.BuildersAssemblyEnding() });
            var assemblies = assembliesProvider.Assemblies.ToArray();
            var buildersTypes = assemblies.FindBuildersTypes();
            foreach (var type in buildersTypes)
            {
                var instance = BuilderFactory.CreateBuilderInstance(type);
                dependencyRegistrator.RegisterInstance(type, instance);
            }
            return dependencyRegistrator;
        }
    }
}
