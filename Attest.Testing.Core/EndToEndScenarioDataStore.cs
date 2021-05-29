using Attest.Testing.Contracts;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Represents data store for end-to-end tests.
    /// </summary>
    public class EndToEndScenarioDataStore : ScenarioDataStoreBase
    {
        /// <summary>
        /// Initializes a new instanc eof <see cref="EndToEndScenarioDataStore"/>
        /// </summary>
        /// <param name="keyValueDataStore"></param>
        public EndToEndScenarioDataStore(IKeyValueDataStore keyValueDataStore) 
            : base(keyValueDataStore)
        {
        }

        /// <summary>
        /// Gets or sets the starts application service.
        /// </summary>
        public IStartApplicationService StartApplicationService
        {
            get => GetValueImpl<IStartApplicationService>();
            set => SetValueImpl(value);
        }

        /// <summary>
        /// Gets or sets the builder registration service.
        /// </summary>
        public IBuilderRegistrationService BuilderRegistrationService
        {
            get => GetValueImpl<IBuilderRegistrationService>();
            set => SetValueImpl(value);
        }
    }
}
