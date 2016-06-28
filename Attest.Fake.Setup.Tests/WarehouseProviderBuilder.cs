using System.Collections.Generic;
using Attest.Fake.Builders;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup.Tests
{
    public class WarehouseProviderBuilder : FakeBuilderBase<IWarehouseProvider>
    {
        private readonly List<WarehouseItemDto> _warehouseItemsStorage = new List<WarehouseItemDto>();        

        private WarehouseProviderBuilder()
        {

        }

        public static WarehouseProviderBuilder CreateBuilder()
        {
            return new WarehouseProviderBuilder();
        }

        public void WithWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {
            _warehouseItemsStorage.Clear();
            _warehouseItemsStorage.AddRange(warehouseItems);
        }

        private IHaveNoMethods<IWarehouseProvider> CreateInitialSetup()
        {
            return ServiceCallFactory.CreateServiceCall(FakeService);
        }

        protected override void SetupFake()
        {
            var initialSetup = CreateInitialSetup();            

            var setup = initialSetup
                .AddMethodCallWithResultAsync(t => t.GetWarehouseItems(),
                    r => r.Complete(GetWarehouseItems));

            setup.AddMethodCallWithResultAsync<string, IEnumerable<WarehouseItemDto>>(
                t => t.GetWarehouseItemsWithOneParameter(ConstraintFactoryWrapper.It.IsAny<string>()),
                r => r.Complete(c => GetWarehouseItems()));

            setup.AddMethodCallWithResultAsync<string, string, IEnumerable<WarehouseItemDto>>(
               t => t.GetWarehouseItemsWithTwoParameters(ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>()),
               r => r.Complete((c1, c2) => GetWarehouseItems()));

            setup.AddMethodCallWithResultAsync<string, string, string, IEnumerable<WarehouseItemDto>>(
               t => t.GetWarehouseItemsWithThreeParameters(ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>()),
               r => r.Complete((c1, c2, c3) => GetWarehouseItems()));

            setup.AddMethodCallWithResultAsync<string, string, string, string, IEnumerable<WarehouseItemDto>>(
               t => t.GetWarehouseItemsWithFourParameters(ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>()),
               r => r.Complete((c1, c2, c3, c4) => GetWarehouseItems()));

            setup.AddMethodCallWithResultAsync<string, string, string, string, string, IEnumerable<WarehouseItemDto>>(
               t => t.GetWarehouseItemsWithFiveParameters(ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>()),
               r => r.Complete((c1, c2, c3, c4, c5) => GetWarehouseItems()));

            setup.Build();
        }

        private IEnumerable<WarehouseItemDto> GetWarehouseItems()
        {
            return _warehouseItemsStorage;
        }
    }
}