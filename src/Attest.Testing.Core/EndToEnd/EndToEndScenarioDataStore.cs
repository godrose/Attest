using Attest.Testing.Context;
using Attest.Testing.FakeData;
using Attest.Testing.Lifecycle;

namespace Attest.Testing.EndToEnd
{
    /// <summary>
    /// Represents data store for end-to-end tests.
    /// </summary>
    public class EndToEndScenarioDataStore : ContextDataStoreBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EndToEndScenarioDataStore"/>
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
            get => GetValue<IStartApplicationService>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the builder registration service.
        /// </summary>
        public IBuilderRegistrationService BuilderRegistrationService
        {
            get => GetValue<IBuilderRegistrationService>();
            set => SetValue(value);
        }
    }
}
