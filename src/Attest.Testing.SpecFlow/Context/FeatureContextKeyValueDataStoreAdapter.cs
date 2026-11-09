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
    ///     Implementation of <see cref="IKeyValueDataStore" /> using <see cref="FeatureContext" />.
    /// </summary>
    public class FeatureContextKeyValueDataStoreAdapter : KeyValueDataStoreAdapterBase<FeatureContext>
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="ScenarioContextKeyValueDataStoreAdapter" />
        /// </summary>
        /// <param name="featureContext"></param>
        public FeatureContextKeyValueDataStoreAdapter(FeatureContext featureContext)
            : base(featureContext)
        {
        }
    }
}