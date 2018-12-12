using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Registration;
using Solid.Patterns.Builder;
using Solid.Practices.IoC;

namespace Attest.Fake.Data.Shared
{
    /// <summary>
    /// Builder registration extension methods.
    /// </summary>
    public static class BuilderRegistrationExtensions
    {
        /// <summary>
        /// Registers builders products for the provided types and <see cref="IDependencyRegistrator"/> dependency registrator
        /// from the <see cref="BuildersCollectionContext"/> 
        /// into the provided registrator.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="contractToBuildersMap">The mapping between contracts and their builders.</param>
        /// <param name="builderFactory">The builder factory method.</param>
        public static void RegisterBuildersProducts(
            this IDependencyRegistrator dependencyRegistrator,
            Dictionary<Type, Type> contractToBuildersMap,
            Func<Type, object> builderFactory)
        {
            RegisterBuildersProducts(dependencyRegistrator,
                RegistrationHelper.RegisterBuilderProduct
                , contractToBuildersMap,
                builderFactory);
        }

        /// <summary>
        /// Registers builders products for the provided types and custom dependency registrator
        /// </summary>
        /// <typeparam name="TDependencyRegistrator">The type of the dependency registrator.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="registrationMethod">The builder registration method.</param>
        /// <param name="contractToBuildersMap">The mapping between contracts and their builders.</param>
        /// <param name="builderFactory">The builder factory method.</param>
        public static void RegisterBuildersProducts<TDependencyRegistrator>(
            this TDependencyRegistrator dependencyRegistrator,
            Action<TDependencyRegistrator, Type, IBuilder> registrationMethod,
            Dictionary<Type, Type> contractToBuildersMap,
            Func<Type, object> builderFactory)
        {
            foreach (var match in contractToBuildersMap)
            {
                var contractType = match.Key;
                var builderType = match.Value;
                var builders = BuildersCollectionContext.GetBuilders(builderType).OfType<IBuilder>().ToArray();
                if (builders.Length == 0)
                {
                    var builderInstance = (IBuilder)builderFactory(builderType);
                    registrationMethod(dependencyRegistrator, contractType, builderInstance);
                }
                else
                {
                    foreach (var builder in builders)
                    {
                        registrationMethod(dependencyRegistrator, contractType, builder);
                    }
                }
            }
        }
    }
}