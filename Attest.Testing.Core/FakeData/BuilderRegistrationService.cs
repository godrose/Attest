using Attest.Fake.Data;
using Attest.Testing.Contracts;
using Solid.Patterns.Builder;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.FakeData
{   
    /// <summary>
    /// Represents builder registration service for context-based scenarios.
    /// </summary>
    /// <seealso cref="IBuilderRegistrationService" />
    public class BuilderRegistrationService : IBuilderRegistrationService
    {
        private readonly BuildersCollectionContext _buildersCollectionContext;

        /// <summary>
        /// Creates an instance of <see cref="BuilderRegistrationService"/>
        /// </summary>
        /// <param name="buildersCollectionContext">The builders collection context.</param>
        public BuilderRegistrationService(BuildersCollectionContext buildersCollectionContext)
        {
            _buildersCollectionContext = buildersCollectionContext;
        }

        /// <inheritdoc />        
        public void RegisterBuilder<TService>(IBuilder<TService> builder) where TService : class
        {
            _buildersCollectionContext.AddBuilder(builder);
        }
    }
}
