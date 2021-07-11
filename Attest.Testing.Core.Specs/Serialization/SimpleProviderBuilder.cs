using System.Collections.Generic;
using Attest.Fake.Builders;
using Attest.Fake.Setup.Contracts;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Serialization.Specs
{
    class SimpleProviderBuilder : FakeBuilderBase<ISimpleProvider>.WithInitialSetup
    {
        private readonly List<SimpleItemDto> _warehouseItemsStorage = new List<SimpleItemDto>();

        private SimpleProviderBuilder()
        {

        }

        public static SimpleProviderBuilder CreateBuilder()
        {
            return new SimpleProviderBuilder();
        }

        public void WithWarehouseItems(IEnumerable<SimpleItemDto> warehouseItems)
        {
            _warehouseItemsStorage.Clear();
            _warehouseItemsStorage.AddRange(warehouseItems);
        }       

        protected override IServiceCall<ISimpleProvider> CreateServiceCall(IHaveNoMethods<ISimpleProvider> serviceCallTemplate)
        {
            var setup = serviceCallTemplate
               .AddMethodCallWithResult(t => t.GetSimpleItems(), r => r.Complete(GetSimpleItems));
            return setup;
        }

        private IEnumerable<SimpleItemDto> GetSimpleItems()
        {
            return _warehouseItemsStorage;
        }
    }
}
