using ScenarioContext = TechTalk.SpecFlow.ScenarioContext;

namespace Attest.Testing.SpecFlow
{
    /// <summary>
    /// Base class for scenario data stores in SpecFlow-based projects.
    /// It allows storing and retrieving values dynamically.
    /// </summary>
    public abstract class ScenarioDataStoreBase : Core.ScenarioDataStoreBase
    {
        private readonly ScenarioContext _scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioDataStoreBase"/> class.
        /// </summary>
        /// <param name="scenarioContext"></param>
        protected ScenarioDataStoreBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        protected override bool ContainsKey(string key)
        {
            return _scenarioContext.ContainsKey(key);
        }

        protected override T GetValueByKey<T>(string key)
        {
            return (T) _scenarioContext[key];
        }

        protected override void SetValueByKey<T>(T value, string key)
        {
            _scenarioContext[key] = value;
        }
    }
}
