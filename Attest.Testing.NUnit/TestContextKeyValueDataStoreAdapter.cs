using Attest.Testing.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Attest.Testing.NUnit
{
    class TestContextKeyValueDataStoreAdapter : IKeyValueDataStore
    {
        private IPropertyBag Properties => TestContext.CurrentContext.Test.Properties as IPropertyBag;

        public bool ContainsKey(string key)
        {
            return Properties.ContainsKey(key);
        }

        public T GetValueByKey<T>(string key)
        {
            return (T) Properties.Get(key);
        }

        public void SetValueByKey<T>(T value, string key)
        {
            Properties.Set(key, value);
        }
    }
}
