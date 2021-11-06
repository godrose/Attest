using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
{
    /// <summary>
    /// Implementation of <see cref="IKeyValueDataStore" /> using <see cref="ScenarioContext"/>.
    /// </summary>
    public class ScenarioContextKeyValueDataStoreAdapter : KeyValueDataStoreAdapterBase<ScenarioContext>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ScenarioContextKeyValueDataStoreAdapter"/>
        /// </summary>
        /// <param name="scenarioContext"></param>
        public ScenarioContextKeyValueDataStoreAdapter(ScenarioContext scenarioContext)
        :base(scenarioContext)
        {}
    }
}