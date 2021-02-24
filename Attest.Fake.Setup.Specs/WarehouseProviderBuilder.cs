using System.Collections.Generic;
using System.Threading.Tasks;
using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup.Specs
{
    public sealed class WarehouseItemDto
    {
        public string Kind { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public interface IWarehouseProvider
    {
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItems();
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItemsWithOneParameter(string placeholder);
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItemsWithTwoParameters(string firstParameter, string secondParameter);
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItemsWithThreeParameters(
            string firstParameter, string secondParameter, string thirdParameter);

        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItemsWithFourParameters(
            string firstParameter, string secondParameter, string thirdParameter, string fourthParameter);

        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItemsWithFiveParameters(
            string firstParameter, string secondParameter, string thirdParameter, string fourthParameter, string fifthParameter);
    }

    public class WarehouseProviderBuilder : FakeBuilderBase<IWarehouseProvider>.WithInitialSetup
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

        protected override IServiceCall<IWarehouseProvider> CreateServiceCall(IHaveNoMethods<IWarehouseProvider> serviceCallTemplate)
        {
            var setup = serviceCallTemplate.AddMethodCallWithResultAsync(t => t.GetWarehouseItems(),
                r => r.Complete(GetWarehouseItems));

            setup.AddMethodCallWithResultAsync<string, IEnumerable<WarehouseItemDto>>(
                t => t.GetWarehouseItemsWithOneParameter(It.IsAny<string>()),
                r => r.Complete(c => GetWarehouseItems()));

            setup.AddMethodCallWithResultAsync<string, string, IEnumerable<WarehouseItemDto>>(
                t => t.GetWarehouseItemsWithTwoParameters(It.IsAny<string>(), It.IsAny<string>()),
                r => r.Complete((c1, c2) => GetWarehouseItems()));

            setup.AddMethodCallWithResultAsync<string, string, string, IEnumerable<WarehouseItemDto>>(
                t => t.GetWarehouseItemsWithThreeParameters(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                r => r.Complete((c1, c2, c3) => GetWarehouseItems()));

            setup.AddMethodCallWithResultAsync<string, string, string, string, IEnumerable<WarehouseItemDto>>(
                t => t.GetWarehouseItemsWithFourParameters(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                r => r.Complete((c1, c2, c3, c4) => GetWarehouseItems()));

            setup.AddMethodCallWithResultAsync<string, string, string, string, string, IEnumerable<WarehouseItemDto>>(
                t => t.GetWarehouseItemsWithFiveParameters(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                r => r.Complete((c1, c2, c3, c4, c5) => GetWarehouseItems()));

            return setup;
        }

        private IEnumerable<WarehouseItemDto> GetWarehouseItems()
        {
            return _warehouseItemsStorage;
        }
    }
}