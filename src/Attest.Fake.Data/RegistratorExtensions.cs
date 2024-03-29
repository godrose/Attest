using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Builders;
using Solid.IoC.Registration;
using Solid.Patterns.Builder;
using Solid.Practices.IoC;

namespace Attest.Fake.Data
{
    /// <summary>
    /// The <see cref="IDependencyRegistrator"/> extensions.
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Registers builders for the provided types and custom dependency registrator using <see cref="BuildersCollectionContext"/>.
        /// </summary>
        /// <typeparam name="TDependencyRegistrator">The type of the dependency registrator.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="buildersCollectionContext">The builders collection context.</param>
        /// <param name="registrationMethod">The builder registration method.</param>
        /// <param name="matches">The collection of type matches.</param>
        /// <param name="builderFactory">The builder factory method.</param>
        public static void RegisterBuilders<TDependencyRegistrator>(
            this TDependencyRegistrator dependencyRegistrator,
            BuildersCollectionContext buildersCollectionContext,
            Action<TDependencyRegistrator, Type, IBuilder> registrationMethod,
            IEnumerable<TypeMatch> matches,
            Func<Type, object> builderFactory)
        {
            var builders = buildersCollectionContext.GetAllBuilders().ToArray();
            dependencyRegistrator.RegisterBuilders(registrationMethod, matches, builderFactory, builders);
        }

        /// <summary>
        /// Uses <see cref="LocalFileSystemDataStorage"/> for data storage.
        /// </summary>
        /// <param name="dependencyRegistrator"></param>
        public static IDependencyRegistrator UseLocalFileSystemDataStorage(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .AddSingleton<IDataStorage<string>, LocalFileSystemDataStorage>();
            return dependencyRegistrator;
        }
    }
}