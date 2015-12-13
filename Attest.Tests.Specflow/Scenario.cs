using Attest.Tests.Core;

namespace Attest.Tests.SpecFlow
{
    class Scenario : IScenario
    {
        public void Add(string key, object value)
        {
            TechTalk.SpecFlow.ScenarioContext.Current.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return TechTalk.SpecFlow.ScenarioContext.Current.ContainsKey(key);
        }

        public void Clear()
        {
            TechTalk.SpecFlow.ScenarioContext.Current.Clear();
        }

        public object this[string key]
        {
            get { return TechTalk.SpecFlow.ScenarioContext.Current[key]; }
            set { TechTalk.SpecFlow.ScenarioContext.Current[key] = value; }
        }
    }
}
