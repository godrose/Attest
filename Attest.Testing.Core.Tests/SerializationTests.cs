using System;
using System.Linq;
using Attest.Fake.Core;
using Attest.Fake.Data;
using Attest.Fake.Moq;
using Attest.Testing.Contracts;
using Attest.Testing.Core.FakeData;
using FluentAssertions;
using Solid.Common;
using Solid.Patterns.Builder;
using Xunit;

namespace Attest.Testing.Core.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void ItemsAreSerializedAndDeserialized_ItemsCollectionIsCorrect()
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
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
            PlatformProvider.Current = new NetStandardPlatformProvider();
            var simpleBuilder = SimpleProviderBuilder.CreateBuilder();
            simpleBuilder.WithWarehouseItems(items);

            BuildersCollectionContext.AddBuilder(simpleBuilder);
            BuildersCollectionContext.SerializeBuilders();
            BuildersCollectionContext.DeserializeBuilders();
            var builders = BuildersCollectionContext.GetBuilders<ISimpleProvider>();
            IBuilder<ISimpleProvider> actualBuilder = builders.First();

            var actualItems = actualBuilder.Build().GetSimpleItems().ToArray();
            for (int i = 0; i < Math.Max(items.Length, actualItems.Length); i++)
            {
                var item = items[i];
                var actualItem = actualItems[i];
                actualItem.Quantity.Should().Be(item.Quantity);
                actualItem.Price.Should().Be(item.Price);
                actualItem.Name.Should().Be(item.Name);
            }
        }

        [Fact]
        public void TwoBuildersAreSerializedAndDeserialized_ItemsCollectionIsCorrectForBothBuilders()
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
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
            PlatformProvider.Current = new NetStandardPlatformProvider();
            var simpleBuilder = SimpleProviderBuilder.CreateBuilder();
            simpleBuilder.WithWarehouseItems(items);
            var anotherProviderBuilder = AnotherProviderBuilder.CreateBuilder();
            anotherProviderBuilder.WithUser("User", "pass");

            IBuilderRegistrationService builderRegistrationService = new BuilderRegistrationService();
            builderRegistrationService.RegisterBuilder(simpleBuilder);
            builderRegistrationService.RegisterBuilder(anotherProviderBuilder);
            BuildersCollectionContext.SerializeBuilders();
            BuildersCollectionContext.DeserializeBuilders();
            var simpleBuilders = BuildersCollectionContext.GetBuilders<ISimpleProvider>();
            IBuilder<ISimpleProvider> actualSimpleBuilder = simpleBuilders.First();
            var actualItems = actualSimpleBuilder.Build().GetSimpleItems().ToArray();
            for (int i = 0; i < Math.Max(items.Length, actualItems.Length); i++)
            {
                var item = items[i];
                var actualItem = actualItems[i];
                actualItem.Quantity.Should().Be(item.Quantity);
                actualItem.Price.Should().Be(item.Price);
                actualItem.Name.Should().Be(item.Name);
            }
            var anotherBuilders = BuildersCollectionContext.GetBuilders<IAnotherProvider>();
            IBuilder<IAnotherProvider> actualAnotherBuilder = anotherBuilders.First();
            var actualUsers = actualAnotherBuilder.Build().GetUsers();
            var actualUser = actualUsers.Single();
            actualUser.Should().Be("User");
        }

        [Fact]
        public void BuilderWithInheritedDtoIsSerializedAndDeserialized_InheritedDtoPropertiesAreCorrect()
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
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
            PlatformProvider.Current = new NetStandardPlatformProvider();
            var simpleBuilder = InheritanceProviderBuilder.CreateBuilder();
            simpleBuilder.WithObjects(items);

            BuildersCollectionContext.AddBuilder(simpleBuilder);
            BuildersCollectionContext.SerializeBuilders();
            BuildersCollectionContext.DeserializeBuilders();
            var builders = BuildersCollectionContext.GetBuilders<IInheritanceProvider>();
            IBuilder<IInheritanceProvider> actualBuilder = builders.First();

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
