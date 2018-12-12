using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Patterns.Builder;

namespace Attest.Fake.Data
{
    /// <summary>
    /// Builder registration extension methods.
    /// </summary>
    public static class BuilderRegistrationExtensions
    {        
        /// <summary>
        /// Registers builders for the provided types and custom dependency registrator.
        /// </summary>
        /// <typeparam name="TDependencyRegistrator">The type of the dependency registrator.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="registrationMethod">The builder registration method.</param>
        /// <param name="contractsToImplementationsMap">The mapping between contracts and their implementations.</param>
        /// <param name="builderFactory">The builder factory method.</param>
        public static void RegisterBuilders<TDependencyRegistrator>(
            this TDependencyRegistrator dependencyRegistrator,
            Action<TDependencyRegistrator, Type, IBuilder> registrationMethod,
            Dictionary<Type, Type> contractsToImplementationsMap,
            Func<Type, object> builderFactory)
        {
            foreach (var match in contractsToImplementationsMap)
            {
                var contractType = match.Key;
                var builderType = match.Value;
                var builders = BuildersCollectionContext.GetAllBuilders().ToArray();
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

        /// <summary>
        /// Registers builders for the provided types and custom dependency registrator.
        /// </summary>
        /// <typeparam name="TDependencyRegistrator">The type of the dependency registrator.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="registrationMethod">The builder registration method.</param>
        /// <param name="contractsToImplementationsMap">The mapping between contracts and their implementations.</param>        
        /// <param name="builders">The builders.</param>
        public static void RegisterBuilders<TDependencyRegistrator>(
            this TDependencyRegistrator dependencyRegistrator,
            Action<TDependencyRegistrator, Type, IBuilder> registrationMethod,
            Dictionary<Type, Type> contractsToImplementationsMap,            
            IBuilder[] builders)
        {
            foreach (var match in contractsToImplementationsMap)
            {
                var contractType = match.Key;
                var builderType = match.Value;
                var typedBuilders = builders.Where(t => t.GetType() == builderType).ToArray();
                if (typedBuilders.Length > 0)
                {
                    foreach (var builder in typedBuilders)
                    {
                        registrationMethod(dependencyRegistrator, contractType, builder);
                    }
                }               
            }
        }
    }
}