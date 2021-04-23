using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Builders;
using Solid.Patterns.Builder;

namespace Attest.Fake.Data
{
    /// <summary>
    /// Builder registration extension methods.
    /// </summary>
    public static class BuilderRegistrationExtensions
    {
        /// <summary>
        /// Registers builders for the provided types and custom dependency registrator using <see cref="BuildersCollectionContext"/>.
        /// </summary>
        /// <typeparam name="TDependencyRegistrator">The type of the dependency registrator.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="buildersCollectionContext">The builders collection context.</param>
        /// <param name="registrationMethod">The builder registration method.</param>
        /// <param name="contractsToImplementationsMap">The mapping between contracts and their implementations.</param>
        /// <param name="builderFactory">The builder factory method.</param>
        public static void RegisterBuilders<TDependencyRegistrator>(
            this TDependencyRegistrator dependencyRegistrator,
            BuildersCollectionContext buildersCollectionContext,
            Action<TDependencyRegistrator, Type, IBuilder> registrationMethod,
            Dictionary<Type, Type> contractsToImplementationsMap,
            Func<Type, object> builderFactory)
        {
            var builders = buildersCollectionContext.GetAllBuilders().ToArray();
            dependencyRegistrator.RegisterBuilders(registrationMethod, contractsToImplementationsMap, builderFactory, builders);
        }
    }
}