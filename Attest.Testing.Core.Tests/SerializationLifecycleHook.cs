using Attest.Fake.Data;
using Attest.Testing.Core.FakeData;
using TechTalk.SpecFlow;

namespace Attest.Testing.Core.Tests
{
    [Binding]
    internal sealed class SerializationLifecycleHook
    {
        //TODO: Use Container
        private readonly TechTalk.SpecFlow.ScenarioContext _scenarioContext;

        public SerializationLifecycleHook(TechTalk.SpecFlow.ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Setup()
        {
            var buildersCollectionContext = new BuildersCollectionContext();
            _scenarioContext.Add("buildersCollectionContext", buildersCollectionContext);
            _scenarioContext.Add("builderRegistrationService",
                new BuilderRegistrationService(buildersCollectionContext));
        }
    }
}
