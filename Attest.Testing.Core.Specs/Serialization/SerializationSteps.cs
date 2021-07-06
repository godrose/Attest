using System;
using System.Linq;
using Attest.Fake.Data;
using Attest.Testing.FakeData;
using FluentAssertions;
using Solid.Patterns.Builder;
using TechTalk.SpecFlow;

namespace Attest.Testing.Core.Specs
{
    [Binding]
    internal sealed class SerializationSteps
    {
        private readonly SerializationScenarioDataStore _serializationScenarioDataStore;

        public SerializationSteps(ScenarioContext scenarioContext)
        {
            _serializationScenarioDataStore = new SerializationScenarioDataStore(scenarioContext);
        }

        [Given(@"The builders collection context is initialized")]
        public void GivenTheBuildersCollectionContextIsInitialized()
        {
            var buildersCollectionContext = new BuildersCollectionContext();
            _serializationScenarioDataStore.BuildersCollectionContext = buildersCollectionContext;
            _serializationScenarioDataStore.BuilderRegistrationService =
                new BuilderRegistrationService(buildersCollectionContext);
        }


        [Given(@"The collection of items is created")]
        public void GivenTheCollectionOfItemsIsCreated()
        {
            var items = new[]
            {
                new SimpleItemDto
                {
                    Name = "KindOne",
                    Price = 54,
                    Quantity = 3
                },
                new SimpleItemDto
                {
                    Name = "KindTwo",
                    Price = 67,
                    Quantity = 4
                },
                new SimpleItemDto
                {
                    Name = "KindThree",
                    Price = 65,
                    Quantity = 6
                }
            };
            _serializationScenarioDataStore.Items = items;
        }

        [Given(@"The single item is created")]
        public void GivenSingleItemIsCreated()
        {
            var item = new UserDto
            {
                Username = "User",
                Password = "pass"
            };
            _serializationScenarioDataStore.Item = item;
        }

        [Given(@"The inherited object is created")]
        public void GivenTheInheritedObjectIsCreated()
        {
            var items = new[]
            {
                new InheritanceDto
                {
                    Kind = "Kind",
                    Name = "Name",
                    Score = 5,
                    Size = 8
                }
            };
            _serializationScenarioDataStore.Inherited = items;
        }

        [When(@"The items are added to the current context")]
        public void WhenTheItemsAreAddedToTheCurrentContext()
        {
            RegisterBuilder(r => r.Items, d =>
            {
                var builder = SimpleProviderBuilder.CreateBuilder();
                builder.WithWarehouseItems(d);
                return builder;
            });
        }

        [When(@"The single item is added to the current context")]
        public void WhenTheSingleItemIsAddedToTheCurrentContext()
        {
            RegisterBuilder(r => r.Item, d =>
            {
                var builder = AnotherProviderBuilder.CreateBuilder();
                builder.WithUser(d.Username, d.Password);
                return builder;
            });
        }

        [When(@"The inherited object is added to the current context")]
        public void WhenTheInheritedObjectIsAddedToTheCurrentContext()
        {
            RegisterBuilder(r => r.Inherited, d =>
            {
                var builder = InheritanceProviderBuilder.CreateBuilder();
                builder.WithObjects(d);
                return builder;
            });
        }

        private void RegisterBuilder<TData, TService>(
            Func<SerializationScenarioDataStore, TData> valueGetter,
            Func<TData, IBuilder<TService>> builderFactory) where TService : class
        {
            var value = valueGetter(_serializationScenarioDataStore);
            var builder = builderFactory(value);
            var builderRegistrationService = _serializationScenarioDataStore.BuilderRegistrationService;
            builderRegistrationService.RegisterBuilder(builder);
        }

        [When(@"The current context is serialized")]
        public void WhenTheCurrentContextIsSerialized()
        {
            var buildersCollectionContext = _serializationScenarioDataStore.BuildersCollectionContext;
            buildersCollectionContext.SerializeBuilders();
        }

        [When(@"The current context is deserialized")]
        public void WhenTheCurrentContextIsDeserialized()
        {
            var buildersCollectionContext = _serializationScenarioDataStore.BuildersCollectionContext;
            buildersCollectionContext.DeserializeBuilders();
        }

        [Then(@"The collection of items inside the current context is identical to the original one")]
        public void ThenTheCollectionOfItemsInsideTheCurrentContextIsIdenticalToTheOriginalOne()
        {
            var buildersCollectionContext = _serializationScenarioDataStore.BuildersCollectionContext;
            var builders = buildersCollectionContext.GetBuilders<ISimpleProvider>();
            var actualBuilder = builders.First();

            var actualItems = actualBuilder.Build().GetSimpleItems().ToArray();
            var items = _serializationScenarioDataStore.Items;
            for (int i = 0; i < Math.Max(items.Length, actualItems.Length); i++)
            {
                var item = items[i];
                var actualItem = actualItems[i];
                actualItem.Quantity.Should().Be(item.Quantity);
                actualItem.Price.Should().Be(item.Price);
                actualItem.Name.Should().Be(item.Name);
            }
        }

        [Then(@"The item inside the current context is identical to the original one")]
        public void ThenTheItemInsideTheCurrentContextIsIdenticalToTheOriginalOne()
        {
            var buildersCollectionContext = _serializationScenarioDataStore.BuildersCollectionContext;
            var anotherBuilders = buildersCollectionContext.GetBuilders<IAnotherProvider>();
            var actualAnotherBuilder = anotherBuilders.First();
            var actualUsers = actualAnotherBuilder.Build().GetUsers();
            var actualUser = actualUsers.Single();
            actualUser.Should().Be("User");
        }

        [Then(@"The inherited object inside the current context is identical to the original one")]
        public void ThenTheInheritedObjectInsideTheCurrentContextIsIdenticalToTheOriginalOne()
        {
            var buildersCollectionContext = _serializationScenarioDataStore.BuildersCollectionContext;
            var builders = buildersCollectionContext.GetBuilders<IInheritanceProvider>();
            var actualBuilder = builders.First();

            var actualItems = actualBuilder.Build().GetObjects().ToArray();
            actualItems.Length.Should().Be(1);
            var actualItem = actualItems[0];
            actualItem.Kind.Should().Be("Kind");
            actualItem.Score.Should().Be(5);
            actualItem.Size.Should().Be(8);
            actualItem.Name.Should().Be("Name");
        }
    }
}
