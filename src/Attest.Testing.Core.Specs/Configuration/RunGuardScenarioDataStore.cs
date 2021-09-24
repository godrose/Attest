using Attest.Fake.Core;
using Attest.Testing.Context.SpecFlow;
using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration.Specs
{
    internal sealed class RunGuardScenarioDataStore : ScenarioDataStoreBase
    {
        public RunGuardScenarioDataStore(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        public IFake<IRunGuardInfo> RunGuardInfo
        {
            get => GetValue<IFake<IRunGuardInfo>>();
            set => SetValue(value);
        }

        public IRunGuard RunGuard
        {
            get => GetValue<IRunGuard> ();
            set => SetValue(value);
        }

        public bool CanRun
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
    }
}
