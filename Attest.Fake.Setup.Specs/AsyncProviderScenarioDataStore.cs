using System.Collections.Generic;
using Attest.Testing.SpecFlow;
using TechTalk.SpecFlow;

namespace Attest.Fake.Setup.Specs
{
    internal sealed class AsyncProviderScenarioDataStore : ScenarioDataStoreBase
    {
        public AsyncProviderScenarioDataStore(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        public WarehouseProviderBuilder WarehouseProviderBuilder
        {
            get => GetValue<WarehouseProviderBuilder>();
            set => SetValue(value);
        }

        public LoginProviderBuilder LoginProviderBuilder
        {
            get => GetValue<LoginProviderBuilder>();
            set => SetValue(value);
        }

        public IWarehouseProvider WarehouseProvider
        {
            get => GetValue<IWarehouseProvider>();
            set => SetValue(value);
        }

        public ILoginProvider LoginProvider
        {
            get => GetValue<ILoginProvider>();
            set => SetValue(value);
        }

        public IEnumerable<WarehouseItemDto> OriginalItems
        {
            get => GetValue<IEnumerable<WarehouseItemDto>>();
            set => SetValue(value);
        }

        public IEnumerable<WarehouseItemDto> ActualItems
        {
            get => GetValue<IEnumerable<WarehouseItemDto>>();
            set => SetValue(value);
        }
    }
}
