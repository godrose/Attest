using Attest.Fake.Data;
using Attest.Testing.Contracts;
using Solid.Patterns.Builder;

namespace Attest.Testing.Core.FakeData
{   
    /// <summary>
    /// Represents builder registration service for context-based scenarios.
    /// </summary>
    /// <seealso cref="IBuilderRegistrationService" />
    public class BuilderRegistrationService : IBuilderRegistrationService
    {
        /// <inheritdoc />        
        public void RegisterBuilder<TService>(IBuilder<TService> builder) where TService : class
        {
            BuildersCollectionContext.AddBuilder(builder);
        }
    }
}
