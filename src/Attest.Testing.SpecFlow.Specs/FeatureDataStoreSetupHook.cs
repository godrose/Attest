#if REQNROLL
using Reqnroll;
#else
using TechTalk.SpecFlow;
#endif

#if REQNROLL
namespace Attest.Testing.Reqnroll.Specs
#else
namespace Attest.Testing.SpecFlow.Specs
#endif
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
