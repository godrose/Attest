using Attest.Testing.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

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
            return Properties.ContainsKey(key);
        }

        public void Clear()
        {
            Properties.Keys.Clear();
        }

        public object this[string key]
        {
            get => Properties.Get(key);
            set => Properties.Set(key, value);
        }

        private IPropertyBag Properties => TestContext.CurrentContext.Test.Properties as IPropertyBag;
    }
}