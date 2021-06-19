using Attest.Testing.Context.SpecFlow;
using TechTalk.SpecFlow;

namespace Attest.Fake.Moq.Specs
{
    internal sealed class EventInvocationScenarioDataStore : ScenarioDataStoreBase
    {
        public EventInvocationScenarioDataStore(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        public EventProviderBuilder ProviderBuilder
        {
            get => GetValue<EventProviderBuilder>();
            set => SetValue(value);
        }

        public object ArrivedArgsRef
        {
            get => GetValue<object>();
            set => SetValue(value);
        }

        public object ArgsToBeSent
        {
            get => GetValue<object>();
            set => SetValue(value);
        }
    }
}
