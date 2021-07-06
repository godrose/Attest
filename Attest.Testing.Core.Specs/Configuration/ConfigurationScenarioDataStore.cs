using Attest.Fake.Core;
using Attest.Testing.Configuration;
using Attest.Testing.Context.SpecFlow;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace Attest.Testing.Core.Specs
{
    internal sealed class ConfigurationScenarioDataStore : ScenarioDataStoreBase
    {
        public ConfigurationScenarioDataStore(ScenarioContext scenarioContext) : base(scenarioContext)
        {}

        public string Key
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string ExpectedValue
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string ActualValue
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public IConfigurationSectionKeySplitter KeySplitter
        {
            get => GetValue<IConfigurationSectionKeySplitter>();
            set => SetValue(value);
        }

        public IFake<IConfiguration> Configuration
        {
            get => GetValue<IFake<IConfiguration>>();
            set => SetValue(value);
        }

        public IFake<IConfigurationSection> ConfigurationSection
        {
            get => GetValue<IFake<IConfigurationSection>>();
            set => SetValue(value);
        }
    }
}
