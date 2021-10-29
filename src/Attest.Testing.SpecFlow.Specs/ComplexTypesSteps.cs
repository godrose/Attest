using FluentAssertions;
using TechTalk.SpecFlow;
using Xunit;

namespace Attest.Testing.SpecFlow.Specs
{
    [Binding]
    internal sealed class ComplexTypesSteps
    {
        private readonly ComplexTypesScenarioDataStore _scenarioDataStore;

        public ComplexTypesSteps(ScenarioContext scenarioContext)
        {
            _scenarioDataStore = new ComplexTypesScenarioDataStore(scenarioContext);
        }

        [Given(@"The scenario data store contains property with Dictionary type")]
        public void GivenTheScenarioDataStoreContainsPropertyWithDictionaryType()
        {
            //readability only
        }

        [When(@"I add an entry to this property")]
        public void WhenIAddAnEntryToThisProperty()
        {
            var error = Record.Exception(() => _scenarioDataStore.ComplexType.Add("name", "value"));
            _scenarioDataStore.Error = error;
        }

        [Then(@"No exception is thrown")]
        public void ThenNoExceptionIsThrown()
        {
            _scenarioDataStore.Error.Should().BeNull();
        }
    }
}
