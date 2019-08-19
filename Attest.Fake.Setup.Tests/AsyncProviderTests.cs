using System.Threading.Tasks;
using Attest.Fake.Core;
using Attest.Fake.Moq;
using FluentAssertions;
using Solid.Patterns.Builder;
using Xunit;

namespace Attest.Fake.Setup.Tests
{   
    public class AsyncProviderTests
    {
        static AsyncProviderTests()
        {
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
        }       

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithResultAndNoParametersReturnsCorrectValue()
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

            var provider = ((IBuilder<IWarehouseProvider>)builder).Build();
            var actualItems = await provider.GetWarehouseItems();

            actualItems.Should().BeEquivalentTo(items);           
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithResultAndOneParameterReturnsCorrectValue()
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

            var provider = ((IBuilder<IWarehouseProvider>)builder).Build();
            var actualItems = await provider.GetWarehouseItemsWithOneParameter("firstParameter");

            actualItems.Should().BeEquivalentTo(items);
        }

        [Fact]        
        public async Task AsyncProviderIsSetup_MethodCallWithResultAndTwoParametersReturnsCorrectValue()
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

            var provider = ((IBuilder<IWarehouseProvider>)builder).Build();
            var actualItems = await provider.GetWarehouseItemsWithTwoParameters("firstParameter", "secondParameter");

            actualItems.Should().BeEquivalentTo(items);
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithResultAndThreeParametersReturnsCorrectValue()
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

            var provider = ((IBuilder<IWarehouseProvider>)builder).Build();
            var actualItems =
                await
                    provider.GetWarehouseItemsWithThreeParameters("firstParameter", "secondParameter", "thirdParameter");

            actualItems.Should().BeEquivalentTo(items);
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithResultAndFourParametersReturnsCorrectValue()
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

            var provider = ((IBuilder<IWarehouseProvider>)builder).Build();
            var actualItems =
                await
                    provider.GetWarehouseItemsWithFourParameters("firstParameter", "secondParameter", "thirdParameter", "fourthParameter");

            actualItems.Should().BeEquivalentTo(items);
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithResultAndFiveParametersReturnsCorrectValue()
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

            var provider = ((IBuilder<IWarehouseProvider>)builder).Build();
            var actualItems =
                await
                    provider.GetWarehouseItemsWithFiveParameters("firstParameter", "secondParameter", "thirdParameter",
                        "fourthParameter", "fifthParameter");

            actualItems.Should().BeEquivalentTo(items);
        }

        [Fact]        
        public async Task AsyncProviderIsSetup_MethodCallWithoutResultAndNoParametersCompletesSuccessfully()
        {
            var builder = LoginProviderBuilder.CreateBuilder();            

            var provider = ((IBuilder<ILoginProvider>)builder).Build();
            await provider.Login();

            var isLoggedIn = provider.IsLoggedIn();
            isLoggedIn.Should().BeTrue();                     
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithoutResultAndOneParameterCompletesSuccessfully()
        {
            var builder = LoginProviderBuilder.CreateBuilder();

            var provider = ((IBuilder<ILoginProvider>)builder).Build();
            await provider.LoginWithOneParameter("parameter");

            var isLoggedIn = provider.IsLoggedIn();
            isLoggedIn.Should().BeTrue();            
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithoutResultAndTwoParametersCompletesSuccessfully()
        {
            var builder = LoginProviderBuilder.CreateBuilder();

            var provider = ((IBuilder<ILoginProvider>)builder).Build();
            await provider.LoginWithTwoParameters("firstParameter", "secondParameter");

            var isLoggedIn = provider.IsLoggedIn();
            isLoggedIn.Should().BeTrue();            
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithoutResultAndThreeParametersCompletesSuccessfully()
        {
            var builder = LoginProviderBuilder.CreateBuilder();

            var provider = ((IBuilder<ILoginProvider>)builder).Build();
            await provider.LoginWithThreeParameters("firstParameter", "secondParameter", "thirdParameter");

            var isLoggedIn = provider.IsLoggedIn();
            isLoggedIn.Should().BeTrue();
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithoutResultAndFourParametersCompletesSuccessfully()
        {
            var builder = LoginProviderBuilder.CreateBuilder();

            var provider = ((IBuilder<ILoginProvider>)builder).Build();
            await provider.LoginWithFourParameters("firstParameter", "secondParameter", "thirdParameter", "fourthParameter");

            var isLoggedIn = provider.IsLoggedIn();
            isLoggedIn.Should().BeTrue();
        }

        [Fact]
        public async Task AsyncProviderIsSetup_MethodCallWithoutResultAndFiveParametersCompletesSuccessfully()
        {
            var builder = LoginProviderBuilder.CreateBuilder();

            var provider = ((IBuilder<ILoginProvider>)builder).Build();
            await
                provider.LoginWithFiveParameters("firstParameter", "secondParameter", "thirdParameter",
                    "fourthParameter", "fifthParameter");

            var isLoggedIn = provider.IsLoggedIn();
            isLoggedIn.Should().BeTrue();
        }
    }
}
