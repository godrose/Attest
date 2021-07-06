using System;
using Attest.Testing.Context.SpecFlow;
using TechTalk.SpecFlow;

namespace Attest.Fake.Setup.Specs
{
    internal sealed class MultipleCallsScenarioDataStore : ScenarioDataStoreBase
    {
        public MultipleCallsScenarioDataStore(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        public PhasesProviderBuilder ProviderBuilder
        {
            get => GetValue<PhasesProviderBuilder>();
            set => SetValue(value);
        }

        public IPhasesProvider Provider
        {
            get => GetValue<IPhasesProvider>();
            set => SetValue(value);
        }

        public Guid FirstId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public Guid SecondId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public Guid[] FirstResult
        {
            get => GetValue<Guid[]>();
            set => SetValue(value);
        }

        public Guid[] SecondResult
        {
            get => GetValue<Guid[]>();
            set => SetValue(value);
        }
    }
}
