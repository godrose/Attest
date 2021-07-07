using Attest.Fake.Core;
using Attest.Fake.Moq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration.Specs
{
    [Binding]
    internal sealed class ConfigurationSteps
    {
        private readonly ConfigurationScenarioDataStore _configurationScenarioDataStore;
        private readonly IFakeFactory _fakeFactory;

        public ConfigurationSteps(ScenarioContext scenarioContext)
        {
            _configurationScenarioDataStore = new ConfigurationScenarioDataStore(scenarioContext);
            _fakeFactory = new FakeFactory();
        }

        [Given(@"The configuration uses environment variable compatible key splitter")]
        public void GivenTheConfigurationUsesEnvironmentVariableCompatibleKeySplitter()
        {
            _configurationScenarioDataStore.KeySplitter = new EnvironmentVariableKeySplitter();
        }

        [Given(@"The configuration contains the key ""(.*)"" mapped to value ""(.*)""")]
        public void GivenTheConfigurationContainsTheKeyMappedToValue(string key, string value)
        {
            _configurationScenarioDataStore.Key = key;
            _configurationScenarioDataStore.ExpectedValue = value;
            _configurationScenarioDataStore.Configuration = _fakeFactory.CreateFake<IConfiguration>();
            _configurationScenarioDataStore.ConfigurationSection = _fakeFactory.CreateFake<IConfigurationSection>();
            _configurationScenarioDataStore.ConfigurationSection
                .Setup(t => t.Value)
                .Callback(() => _configurationScenarioDataStore.ExpectedValue);
            _configurationScenarioDataStore.Configuration
                .Setup(t => t.GetSection(key))
                .Callback(() => _configurationScenarioDataStore.ConfigurationSection.Object);
        }

        [Given(@"The configuration does not contain the key ""(.*)""")]
        public void GivenTheConfigurationDoesNotContainTheKeyMappedToValue(string key)
        {
            _configurationScenarioDataStore.Key = key;
            _configurationScenarioDataStore.Configuration = _fakeFactory.CreateFake<IConfiguration>();
            _configurationScenarioDataStore.Configuration
                .Setup(t => t.GetSection(key))
                .Callback(() => null);
        }

        [When(@"I get the value by this key")]
        public void WhenIGetTheValueByThisKey()
        {
            //TODO: Inject/Resolve
            var configurationSectionValueProvider =
                new ConfigurationSectionValueProvider(_configurationScenarioDataStore.KeySplitter);
            var value = configurationSectionValueProvider.GetValue(
                _configurationScenarioDataStore.Configuration.Object,
                _configurationScenarioDataStore.Key);
            _configurationScenarioDataStore.ActualValue = value;
        }

        [Then(@"The value is resolved successfully")]
        public void ThenTheValueIsResolvedSuccessfully()
        {
            _configurationScenarioDataStore
                .ActualValue
                .Should()
                .Be(_configurationScenarioDataStore.ExpectedValue);
        }

        [Then(@"The value is returned as null")]
        public void ThenTheValueIsReturnedAsNull()
        {
            _configurationScenarioDataStore
                .ActualValue
                .Should()
                .BeNull();
        }
    }
}