using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
{
    /// <summary>
    /// Implementation of <see cref="IKeyValueDataStore" /> using <see cref="FeatureContext"/>.
    /// </summary>
    public class FeatureContextKeyValueDataStoreAdapter : IKeyValueDataStore
    {
        private readonly FeatureContext _featureContext;

        /// <summary>
        /// Initializes a new instance of <see cref="ScenarioContextKeyValueDataStoreAdapter"/>
        /// </summary>
        /// <param name="featureContext"></param>
        public FeatureContextKeyValueDataStoreAdapter(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        /// <inheritdoc />
        public bool ContainsKey(string key)
        {
            return _featureContext.ContainsKey(key);
        }

        /// <inheritdoc />
        public T GetValueByKey<T>(string key)
        {
            return (T)_featureContext[key];
        }

        /// <inheritdoc />
        public void SetValueByKey<T>(T value, string key)
        {
            _featureContext[key] = value;
        }
    }
}