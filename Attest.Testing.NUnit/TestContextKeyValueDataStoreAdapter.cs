using Attest.Testing.Context;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Attest.Testing.NUnit
{
    /// <summary>
    /// Implementation of <see cref="IKeyValueDataStore" /> using <see cref="TestContext.CurrentContext"/>.
    /// </summary>
    public class TestContextKeyValueDataStoreAdapter : IKeyValueDataStore
    {
        private IPropertyBag Properties => TestContext.CurrentContext.Test.Properties as IPropertyBag;

        /// <inheritdoc />
        public bool ContainsKey(string key)
        {
            return Properties.ContainsKey(key);
        }

        /// <inheritdoc />
        public T GetValueByKey<T>(string key)
        {
            return (T) Properties.Get(key);
        }

        /// <inheritdoc />
        public void SetValueByKey<T>(T value, string key)
        {
            Properties.Set(key, value);
        }
    }
}
