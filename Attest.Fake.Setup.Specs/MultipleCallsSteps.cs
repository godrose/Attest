using System;
using FluentAssertions;
using Solid.Patterns.Builder;
using TechTalk.SpecFlow;

namespace Attest.Fake.Setup.Specs
{
    [Binding]
    internal sealed class MultipleCallsSteps
    {
        private readonly MultipleCallsScenarioDataStore _scenarioDataStore;

        public MultipleCallsSteps(ScenarioContext scenarioContext)
        {
            _scenarioDataStore = new MultipleCallsScenarioDataStore(scenarioContext);
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
                    Id = Guid.Parse("80f35b7f-1c51-49ce-a93e-152b68b061a3")
                },
                new PhaseDto
                {
                    Id = Guid.Parse("80f35b7f-1c51-49ce-a93e-152b68b061a2")
                }
            };
            var phasesProviderBuilder = PhasesProviderBuilder.CreateBuilder();
            phasesProviderBuilder.WithPhases(firstGaugeId, phases);
            phasesProviderBuilder.WithPhases(secondGaugeId, new PhaseDto[] { });
            _scenarioDataStore.FirstId = firstGaugeId;
            _scenarioDataStore.SecondId = secondGaugeId;
            _scenarioDataStore.ProviderBuilder = phasesProviderBuilder;
        }

        [When(@"The provider for multiple calls is created")]
        public void WhenTheProviderForMultipleCallsIsCreated()
        {
            var builder = _scenarioDataStore.ProviderBuilder;
            var provider = ((IBuilder<IPhasesProvider>) builder).Build();
            _scenarioDataStore.Provider = provider;
        }

        [When(@"The provider for multiple calls is invoked with the first id")]
        public void WhenTheProviderForMultipleCallsIsInvokedWithTheFirstId()
        {
            StoreProviderWithIdCallResult(r => r.FirstId, (r, value) => r.FirstResult = value);
        }

        [When(@"The provider for multiple calls is invoked with the second id")]
        public void WhenTheProviderForMultipleCallsIsInvokedWithTheSecondId()
        {
            StoreProviderWithIdCallResult(r => r.SecondId, (r, value) => r.SecondResult = value);
        }

        private void StoreProviderWithIdCallResult(Func<MultipleCallsScenarioDataStore, Guid> valueGetter,
            Action<MultipleCallsScenarioDataStore, Guid[]> valueSetter)
        {
            var provider = _scenarioDataStore.Provider;
            var id = valueGetter(_scenarioDataStore);
            var result = provider.GetPhasesByGauge(id);
            valueSetter(_scenarioDataStore, result);
        }

        [Then(@"The provider calls should return different results for different ids")]
        public void ThenTheProviderCallsShouldReturnDifferentResultsForDifferentIds()
        {
            var firstResult = _scenarioDataStore.FirstResult;
            var secondResult = _scenarioDataStore.SecondResult;
            secondResult.Should().NotBeEquivalentTo(firstResult);
        }
    }
}