using Attest.Fake.Core;
using Attest.Fake.Moq;
using FluentAssertions;
using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration.Specs
{
    [Binding]
    internal sealed class RunGuardSteps
    {
        private readonly RunGuardScenarioDataStore _runGuardScenarioDataStore;
        private readonly ConfigurationScenarioDataStore _configurationScenarioDataStore;
        //TODO: Inject
        private readonly IFakeFactory _fakeFactory;

        public RunGuardSteps(ScenarioContext scenarioContext)
        {
            _runGuardScenarioDataStore = new RunGuardScenarioDataStore(scenarioContext);
            _configurationScenarioDataStore = new ConfigurationScenarioDataStore(scenarioContext);
            _fakeFactory = new FakeFactory();
        }

        [Given(@"The run guard info is defined with key ""(.*)"" and can run for value (.*)")]
        public void GivenTheRunGuardInfoIsDefinedWithKeyAndCanRunForValue(string key, int value)
        {
            _runGuardScenarioDataStore.RunGuardInfo = _fakeFactory.CreateFake<IRunGuardInfo>();
            _runGuardScenarioDataStore.RunGuardInfo
                .Setup(t => t.Key)
                .Callback(() => key);
            _runGuardScenarioDataStore.RunGuardInfo
                .Setup(t => t.CanRun(value.ToString()))
                .Callback(() => true);
        }

        [When(@"I check whether scenarios can be run")]
        public void WhenICheckWhetherScenariosCanBeRun()
        {
            //TODO: Inject/Resolve
            var configurationSectionValueProvider =
                new ConfigurationSectionValueProvider(_configurationScenarioDataStore.KeySplitter);
            _runGuardScenarioDataStore.RunGuard = new RunGuard(configurationSectionValueProvider,
                _runGuardScenarioDataStore.RunGuardInfo.Object);
            var canRun = _runGuardScenarioDataStore.RunGuard
                .CanRun(_configurationScenarioDataStore.Configuration.Object);
            _runGuardScenarioDataStore.CanRun = canRun;
        }

        [Then(@"The scenarios can be run")]
        public void ThenTheScenariosCanBeRun()
        {
            var canRun = _runGuardScenarioDataStore.CanRun;
            canRun.Should().BeTrue();
        }

        [Then(@"The scenarios cannot be run")]
        public void ThenTheScenariosCannotBeRun()
        {
            var canRun = _runGuardScenarioDataStore.CanRun;
            canRun.Should().BeFalse();
        }
    }
}
