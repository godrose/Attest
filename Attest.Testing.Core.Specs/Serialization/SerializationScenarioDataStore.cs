using Attest.Fake.Data;
using Attest.Testing.Context.SpecFlow;
using Attest.Testing.FakeData;
using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Serialization.Specs
{
    internal sealed class SerializationScenarioDataStore : ScenarioDataStoreBase
    {
        public SerializationScenarioDataStore(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        public IBuilderRegistrationService BuilderRegistrationService
        {
            get => GetValue<IBuilderRegistrationService>();
            set => SetValue(value);
        }

        public BuildersCollectionContext BuildersCollectionContext
        {
            get => GetValue<BuildersCollectionContext>();
            set => SetValue(value);
        }

        public SimpleItemDto[] Items
        {
            get => GetValue<SimpleItemDto[]>();
            set => SetValue(value);
        }

        public UserDto Item
        {
            get => GetValue<UserDto>();
            set => SetValue(value);
        }

        public InheritanceDto[] Inherited
        {
            get => GetValue<InheritanceDto[]>();
            set => SetValue(value);
        }
    }
}
