﻿using Attest.Fake.Data;
using Attest.Testing.Contracts;
using Solid.Practices.IoC;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.FakeData
{
    /// <summary>
    /// The <see cref="IDependencyRegistrator"/> fake builders related extensions.
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Registers dependencies required to use fake builders.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <returns></returns>
        public static IDependencyRegistrator UseBuilders(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .AddSingleton<IBuilderRegistrationService, BuilderRegistrationService>()
                .AddSingleton<BuildersCollectionContext, BuildersCollectionContext>();
            return dependencyRegistrator;
        }
    }
}