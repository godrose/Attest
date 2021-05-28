using Attest.Testing.Contracts;

namespace Attest.Testing.Core
{
    public class EndToEndScenarioDataStore : ScenarioDataStoreBase
    {
        public EndToEndScenarioDataStore(IKeyValueDataStore keyValueDataStore) 
            : base(keyValueDataStore)
        {
        }

        public IStartApplicationService StartApplicationService
        {
            get => GetValueImpl<IStartApplicationService>();
            set => SetValueImpl(value);
        }

        public IBuilderRegistrationService BuilderRegistrationService
        {
            get => GetValueImpl<IBuilderRegistrationService>();
            set => SetValueImpl(value);
        }
    }
}
