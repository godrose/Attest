using System;
using Attest.Fake.Core;
using Attest.Fake.Moq;
using NUnit.Framework;
using Solid.Patterns.Builder;

namespace Attest.Fake.Setup.Tests
{
    [TestFixture]
    public class MultipleCallsTests
    {
        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
        }

        [Test]
        public void MultipleCalls_ResultIsSetAsFunction_ResultsAreDifferent()
        {
            var firstGaugeId = Guid.Parse("305f5ac7-0145-4466-bd3b-d851989430f8");
            var secondGaugeId = Guid.Parse("203a72e2-0561-4c4b-8131-e55bda2975e9");
            var phases = new[]
            {
                new PhaseDto
                {
                    Id = Guid.Parse("80f35b7f-1c51-49ce-a93e-152b68b061a3"),
                },
                new PhaseDto
                {
                    Id = Guid.Parse("80f35b7f-1c51-49ce-a93e-152b68b061a2")
                }
            };
            var phasesProviderBuilder = PhasesProviderBuilder.CreateBuilder();
            phasesProviderBuilder.WithPhases(firstGaugeId, phases);
            phasesProviderBuilder.WithPhases(secondGaugeId, new PhaseDto[] { });

            var provider = ((IBuilder<IPhasesProvider>)phasesProviderBuilder).Build();
            var firstPhases = provider.GetPhasesByGauge(firstGaugeId);
            var secondPhases = provider.GetPhasesByGauge(secondGaugeId);
            CollectionAssert.AreNotEquivalent(firstPhases, secondPhases);
        }
    }
}
