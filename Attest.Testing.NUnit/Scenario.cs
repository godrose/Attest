using System.Collections;
using Attest.Testing.Core;
using NUnit.Framework;

namespace Attest.Testing.NUnit
{
    class Scenario : IScenario
    {
        public void Add(string key, object value)
        {
            Properties.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return Properties.Contains(key);
        }

        public void Clear()
        {
            Properties.Clear();
        }

        public object this[string key]
        {
            get { return Properties[key]; }
            set { Properties[key] = value; }
        }

        private IDictionary Properties
        {
            get { return TestContext.CurrentContext.Test.Properties; }
        }
    }
}