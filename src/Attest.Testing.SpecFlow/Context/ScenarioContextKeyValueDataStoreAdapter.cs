#if REQNROLL
using Reqnroll;
#else
using TechTalk.SpecFlow;
#endif

// ReSharper disable once CheckNamespace
#if REQNROLL
namespace Attest.Testing.Context.Reqnroll
#else
namespace Attest.Testing.Context.SpecFlow
#endif
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