using Attest.Fake.Data;
using Solid.Practices.IoC;

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
                .AddSingleton<BuildersCollectionContext>();
            return dependencyRegistrator;
        }
    }
}
