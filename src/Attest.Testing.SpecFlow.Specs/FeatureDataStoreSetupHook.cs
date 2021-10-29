using TechTalk.SpecFlow;

namespace Attest.Testing.SpecFlow.Specs
{
    [Binding]
    internal sealed class FeatureDataStoreSetupHook
    {
        private readonly FeatureDataStoreDataStore _featureDataStore;

        public FeatureDataStoreSetupHook(FeatureContext featureContext)
        {
            _featureDataStore = new FeatureDataStoreDataStore(featureContext);
        }

        [BeforeScenario]
        public void ScenarioSetup()
        {
            if (_featureDataStore.Data == null)
            {
                _featureDataStore.Data = "Value";
            }
        }
    }
}
