using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Registration;
using Solid.Patterns.Builder;
using Solid.Practices.IoC;

namespace Attest.Testing.Core.FakeData.Shared
{
    /// <summary>
    /// Builder registration extension methods.
    /// </summary>
    public static class BuilderRegistrationExtensions
    {
        /// <summary>
        /// Registers builders of the provided types
        /// from the <see cref="BuildersCollectionContext"/> 
        /// into the provided registrator.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="contractToBuildersMap">The mapping between contracts and their builders.</param>
        /// <param name="builderInstanceFunc">The builder factory method.</param>
        public static void RegisterBuilders(
            this IDependencyRegistrator dependencyRegistrator,
            Dictionary<Type, Type> contractToBuildersMap,
            Func<Type, object> builderInstanceFunc)
        {
            foreach (var match in contractToBuildersMap)
            {
                var contractType = match.Key;
                var builderType = match.Value;
                var builderInstance = (IBuilder)builderInstanceFunc(builderType);
                var builders = BuildersCollectionContext.GetBuilders(builderType).OfType<IBuilder>().ToArray();
                if (builders.Length == 0)
                {
                    RegistrationHelper.RegisterBuilder(dependencyRegistrator, contractType, builderInstance);
                }
                else
                {
                    foreach (var builder in builders)
                    {
                        RegistrationHelper.RegisterBuilder(dependencyRegistrator, contractType, builder);
                    }
                }
            }

        }
    }
}