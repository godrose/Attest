using Attest.Fake.Builders;
using Attest.Fake.Moq;
using NUnit.Framework;

namespace Attest.Fake.Setup.Tests
{
    [TestFixture]    
    class AsyncProviderTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            FakeFactoryContext.Current = new FakeFactory();
        }

        [Test]
        public async void AsyncProviderIsSetup_MethodCallWithResultAndNoParametersReturnsCorrectValue()
        {
            var items = new[]
            {
                new WarehouseItemDto
                {
                    Kind = "Top",
                    Price = 5,
                    Quantity = 1
                }
            };
            var builder = WarehouseProviderBuilder.CreateBuilder();
            builder.WithWarehouseItems(items);

            var provider = builder.GetService();
            var actualItems = await provider.GetWarehouseItems();

            CollectionAssert.AreEqual(items, actualItems);
        }

        [Test]
        public async void AsyncProviderIsSetup_MethodCallWithResultAndOneParameterReturnsCorrectValue()
        {
            var items = new[]
            {
                new WarehouseItemDto
                {
                    Kind = "Top",
                    Price = 5,
                    Quantity = 1
                }
            };
            var builder = WarehouseProviderBuilder.CreateBuilder();
            builder.WithWarehouseItems(items);

            var provider = builder.GetService();
            var actualItems = await provider.GetWarehouseItemsWithOneParameter("firstParameter");

            CollectionAssert.AreEqual(items, actualItems);
        }

        [Test]
        [Ignore("Not implemented yet")]
        public async void AsyncProviderIsSetup_MethodCallWithResultAndTwoParametersReturnsCorrectValue()
        {
            var items = new[]
            {
                new WarehouseItemDto
                {
                    Kind = "Top",
                    Price = 5,
                    Quantity = 1
                }
            };
            var builder = WarehouseProviderBuilder.CreateBuilder();
            builder.WithWarehouseItems(items);

            var provider = builder.GetService();
            var actualItems = await provider.GetWarehouseItemsWithTwoParameters("firstParameter", "secondParameter");

            CollectionAssert.AreEqual(items, actualItems);
        }       
    }
}
