using Attest.Fake.Core;
using Attest.Fake.Moq;
using Solid.Common;
using TechTalk.SpecFlow;

namespace Attest.Tests.Infra
{
    [Binding]
    internal sealed class GeneralStepsAdapter
    {
        [Given(@"The system runs in \.NETStandard environment")]
        public void GivenTheSystemRunsIn_NETStandardEnvironment()
        {
            PlatformProvider.Current = new NetStandardPlatformProvider();
        }

        [Given(@"Moq setup is used")]
        public void GivenMoqSetupIsUsed()
        {
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
        }
    }
}
