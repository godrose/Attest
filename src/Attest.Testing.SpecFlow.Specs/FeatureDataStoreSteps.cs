using FluentAssertions;
using TechTalk.SpecFlow;

namespace Attest.Testing.SpecFlow.Specs
{
    [Binding]
    internal sealed class FeatureDataStoreSteps
    {
        private readonly FeatureDataStoreDataStore _featureDataStore;

        public FeatureDataStoreSteps(FeatureContext featureContext)
        {
            _featureDataStore = new FeatureDataStoreDataStore(featureContext);
        }

        [Then(@"The data previously stored in the feature data store should stay the same for all scenarios in the current feature")]
        public void ThenIAccessTheDataPreviouslyStoredInTheFeatureDataStore()
        {
            _featureDataStore.Data.Should().NotBeNull();
        }

        [Then(@"The data should have been set only once")]
        public void ThenTheDataShouldHaveBeenSetOnlyOnce()
        {
            _featureDataStore.NumberOfSetCalls.Should().Be(1);
        }

    }
}
