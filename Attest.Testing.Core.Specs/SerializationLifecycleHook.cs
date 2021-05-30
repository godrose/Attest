using Attest.Fake.Data;
using Attest.Testing.FakeData;
using TechTalk.SpecFlow;

namespace Attest.Testing.Core.Specs
{
    [Binding]
    internal sealed class SerializationLifecycleHook
    {
        //TODO: Use Container
        private readonly ScenarioContext _scenarioContext;

        public SerializationLifecycleHook(ScenarioContext scenarioContext)
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
