#if REQNROLL
using Reqnroll;
#else
using TechTalk.SpecFlow;
#endif

// ReSharper disable once CheckNamespace
#if REQNROLL
namespace Attest.Testing.Context.Reqnroll
#else
namespace Attest.Testing.Context.SpecFlow
#endif
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
