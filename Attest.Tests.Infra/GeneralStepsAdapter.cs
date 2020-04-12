using Attest.Fake.Core;
using Attest.Fake.Moq;
using TechTalk.SpecFlow;

namespace Attest.Tests.Infra
{
    [Binding]
    internal sealed class GeneralStepsAdapter
    {
        [Given(@"Moq setup is used")]
        public void GivenMoqSetupIsUsed()
        {
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
        }

    }
}
