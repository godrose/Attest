using System;
using FluentAssertions;
using Solid.Patterns.Builder;
using TechTalk.SpecFlow;

namespace Attest.Fake.Setup.Specs
{
    [Binding]
    internal sealed class MultipleCallsStepsAdapter
    {
        private readonly ScenarioContext _scenarioContext;

        public MultipleCallsStepsAdapter(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"There is a multiple calls setup with different results")]
        public void GivenThereIsAMultipleCallsSetupWithDifferentResults()
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
            _scenarioContext.Add("firstId", firstGaugeId);
            _scenarioContext.Add("secondId", secondGaugeId);
            _scenarioContext.Add("builder", phasesProviderBuilder);
        }

        [When(@"The provider for multiple calls is created")]
        public void WhenTheProviderForMultipleCallsIsCreated()
        {
            var builder = _scenarioContext.Get<PhasesProviderBuilder>("builder");
            var provider = ((IBuilder<IPhasesProvider>)builder).Build();
            _scenarioContext.Add("provider", provider);
        }

        [When(@"The provider for multiple calls is invoked with the first id")]
        public void WhenTheProviderForMultipleCallsIsInvokedWithTheFirstId()
        {
            StoreProviderWithIdCallResult("firstId", "firstResult");
        }


        [When(@"The provider for multiple calls is invoked with the second id")]
        public void WhenTheProviderForMultipleCallsIsInvokedWithTheSecondId()
        {
            StoreProviderWithIdCallResult("secondId", "secondResult");
        }

        private void StoreProviderWithIdCallResult(string idKey, string resultKey)
        {
            var provider = _scenarioContext.Get<IPhasesProvider>("provider");
            var id = _scenarioContext.Get<Guid>(idKey);
            var result = provider.GetPhasesByGauge(id);
            _scenarioContext.Add(resultKey, result);
        }

        [Then(@"The provider calls should return different results for different ids")]
        public void ThenTheProviderCallsShouldReturnDifferentResultsForDifferentIds()
        {
            var firstResult = _scenarioContext.Get<Guid[]>("firstResult");
            var secondResult = _scenarioContext.Get<Guid[]>("secondResult");
            secondResult.Should().NotBeEquivalentTo(firstResult);
        }
    }
}
