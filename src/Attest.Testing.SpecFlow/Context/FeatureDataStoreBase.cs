using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
{
    /// <summary>
    /// Base class for feature data stores in SpecFlow-based projects.
    /// It allows accessing feature context via named properties.
    /// </summary>
    public abstract class FeatureDataStoreBase : ContextDataStoreBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioDataStoreBase"/> class.
        /// </summary>
        /// <param name="featureContext"></param>
        protected FeatureDataStoreBase(FeatureContext featureContext)
        : base(new FeatureContextKeyValueDataStoreAdapter(featureContext))
        {
            
        }
    }
}
