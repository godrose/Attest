using System.Collections.Generic;
using System.Threading.Tasks;

namespace Attest.Fake.Setup.Tests
{
    public interface IWarehouseProvider
    {
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItems();
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItemsWithOneParameter(string placeholder);
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItemsWithTwoParameters(string firstParameter, string secondParameter);
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItemsWithThreeParameters(
            string firstParameter, string secondParameter, string thirdParameter);
    }
}
