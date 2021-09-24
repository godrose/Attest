using Attest.Testing.Core;
using ScenarioContext = TechTalk.SpecFlow.ScenarioContext;

namespace Attest.Testing.SpecFlow
{
    class ScenarioContextWrapper : IScenario
    {
        private readonly ScenarioContext _scenarioContext;

        public ScenarioContextWrapper(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void Add(string key, object value)
        {
            _scenarioContext.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _scenarioContext.ContainsKey(key);
        }

        public void Clear()
        {
            _scenarioContext.Clear();
        }

        public object this[string key]
        {
            get => _scenarioContext[key];
            set => _scenarioContext[key] = value;
        }
    }
}
