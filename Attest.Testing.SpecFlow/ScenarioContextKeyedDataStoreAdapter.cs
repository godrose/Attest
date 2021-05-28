using Attest.Testing.Core;
using ScenarioContext = TechTalk.SpecFlow.ScenarioContext;

namespace Attest.Testing.SpecFlow
{
    public class ScenarioContextKeyedDataStoreAdapter : IKeyedDataStore
    {
        private readonly ScenarioContext _scenarioContext;

        public ScenarioContextKeyedDataStoreAdapter(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public bool ContainsKey(string key)
        {
            return _scenarioContext.ContainsKey(key);
        }

        public T GetValueByKey<T>(string key)
        {
            return (T)_scenarioContext[key];
        }

        public void SetValueByKey<T>(T value, string key)
        {
            _scenarioContext[key] = value;
        }
    }
}