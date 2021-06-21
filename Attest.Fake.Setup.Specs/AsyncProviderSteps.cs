using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Solid.Patterns.Builder;
using TechTalk.SpecFlow;

namespace Attest.Fake.Setup.Specs
{
    [Binding]
    internal sealed class AsyncProviderSteps
    {
        private readonly AsyncProviderScenarioDataStore _scenarioDataStore;
        
        public AsyncProviderSteps(ScenarioContext scenarioContext)
        {
            _scenarioDataStore = new AsyncProviderScenarioDataStore(scenarioContext);
        }

        [Given(@"There is provider builder with a collection of items")]
        public void GivenThereIsProviderBuilderWithACollectionOfItems()
        {
            var originalItems = new[]
            {
                new WarehouseItemDto
                {
                    Kind = "Top",
                    Price = 5,
                    Quantity = 1
                }
            };
            var builder = WarehouseProviderBuilder.CreateBuilder();
            builder.WithWarehouseItems(originalItems);
            _scenarioDataStore.WarehouseProviderBuilder = builder;
            _scenarioDataStore.OriginalItems = originalItems;
        }

        [When(@"The provider for return value case is created")]
        public void WhenTheProviderForReturnValueCaseIsCreated()
        {
            var builder = _scenarioDataStore.WarehouseProviderBuilder;
            var provider = ((IBuilder<IWarehouseProvider>) builder).Build();
            _scenarioDataStore.WarehouseProvider = provider;
        }

        [When(@"The provider for no return value case is created")]
        public void WhenTheProviderForNoReturnValueCaseIsCreated()
        {
            var builder = LoginProviderBuilder.CreateBuilder();
            var provider = ((IBuilder<ILoginProvider>) builder).Build();
            _scenarioDataStore.LoginProvider = provider;
        }

        [When(@"The provider is passed no parameters and asked to return a collection of items")]
        public async Task WhenTheProviderIsPassedNoParametersAndAskedToReturnACollectionOfItems()
        {
            await ReturnCollectionOfItems(p => p.GetWarehouseItems());
        }

        [When(@"The provider is passed one parameter and asked to return a collection of items")]
        public async Task WhenTheProviderIsPassedOneParameterAndAskedToReturnACollectionOfItems()
        {
            await ReturnCollectionOfItems(p => p.GetWarehouseItemsWithOneParameter("firstParameter"));
        }

        [When(@"The provider is passed two parameters and asked to return a collection of items")]
        public async Task WhenTheProviderIsPassedTwoParametersAndAskedToReturnACollectionOfItems()
        {
            await ReturnCollectionOfItems(
                p => p.GetWarehouseItemsWithTwoParameters("firstParameter", "secondParameter"));
        }

        [When(@"The provider is passed three parameters and asked to return a collection of items")]
        public async Task WhenTheProviderIsPassedThreeParametersAndAskedToReturnACollectionOfItems()
        {
            await ReturnCollectionOfItems(p =>
                p.GetWarehouseItemsWithThreeParameters("firstParameter", "secondParameter", "thirdParameter"));
        }

        [When(@"The provider is passed four parameters and asked to return a collection of items")]
        public async Task WhenTheProviderIsPassedFourParametersAndAskedToReturnACollectionOfItems()
        {
            await ReturnCollectionOfItems(p =>
                p.GetWarehouseItemsWithFourParameters("firstParameter", "secondParameter", "thirdParameter",
                    "fourthParameter"));
        }

        [When(@"The provider is passed five parameters and asked to return a collection of items")]
        public async Task WhenTheProviderIsPassedFiveParametersAndAskedToReturnACollectionOfItems()
        {
            await ReturnCollectionOfItems(p => p.GetWarehouseItemsWithFiveParameters("firstParameter",
                "secondParameter", "thirdParameter", "fourthParameter", "fifthParameter"));
        }

        private async Task ReturnCollectionOfItems(
            Func<IWarehouseProvider, Task<IEnumerable<WarehouseItemDto>>> itemsTask)
        {
            var provider = _scenarioDataStore.WarehouseProvider;
            var actualItems = await itemsTask(provider);
            _scenarioDataStore.ActualItems = actualItems;
        }

        [Then(@"The returned collection should be identical to the original one")]
        public void ThenTheReturnedCollectionShouldBeIdenticalToTheOriginalOne()
        {
            var actualItems = _scenarioDataStore.ActualItems;
            var originalItems = _scenarioDataStore.OriginalItems;
            actualItems.Should().BeEquivalentTo(originalItems);
        }

        [Given(@"There is provider builder with expected functionality")]
        public void GivenThereIsProviderBuilderWithExpectedFunctionality()
        {
            var builder = LoginProviderBuilder.CreateBuilder();
            _scenarioDataStore.LoginProviderBuilder = builder;
        }

        [When(@"The provider is passed no parameters and asked to execute specific functionality")]
        public async Task WhenTheProviderIsPassedNoParametersAndAskedToExecuteSpecificFunctionality()
        {
            await ExecuteFunctionality(p => p.Login());
        }

        [When(@"The provider is passed one parameter and asked to execute specific functionality")]
        public async Task WhenTheProviderIsPassedOneParameterAndAskedToExecuteSpecificFunctionality()
        {
            await ExecuteFunctionality(p => p.LoginWithOneParameter("parameter"));
        }

        [When(@"The provider is passed two parameters and asked to execute specific functionality")]
        public async Task WhenTheProviderIsPassedTwoParametersAndAskedToExecuteSpecificFunctionality()
        {
            await ExecuteFunctionality(p => p.LoginWithTwoParameters("firstParameter", "secondParameter"));
        }

        [When(@"The provider is passed three parameters and asked to execute specific functionality")]
        public async Task WhenTheProviderIsPassedThreeParametersAndAskedToExecuteSpecificFunctionality()
        {
            await ExecuteFunctionality(p =>
                p.LoginWithThreeParameters("firstParameter", "secondParameter", "thirdParameter"));
        }

        [When(@"The provider is passed four parameters and asked to execute specific functionality")]
        public async Task WhenTheProviderIsPassedFourParametersAndAskedToExecuteSpecificFunctionality()
        {
            await ExecuteFunctionality(p =>
                p.LoginWithFourParameters("firstParameter", "secondParameter", "thirdParameter", "fourthParameter"));
        }

        [When(@"The provider is passed five parameters and asked to execute specific functionality")]
        public async Task WhenTheProviderIsPassedFiveParametersAndAskedToExecuteSpecificFunctionality()
        {
            await ExecuteFunctionality(p => p.LoginWithFiveParameters("firstParameter", "secondParameter",
                "thirdParameter", "fourthParameter", "fifthParameter"));
        }

        private Task ExecuteFunctionality(Func<ILoginProvider, Task> functionalityTask)
        {
            var provider = _scenarioDataStore.LoginProvider;
            return functionalityTask(provider);
        }

        [Then(@"The actual functionality is executed as expected")]
        public void ThenTheActualFunctionalityIsExecutedAsExpected()
        {
            var provider = _scenarioDataStore.LoginProvider;
            var isLoggedIn = provider.IsLoggedIn();
            isLoggedIn.Should().BeTrue();
        }
    }
}
