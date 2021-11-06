using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
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