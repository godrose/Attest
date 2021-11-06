using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
{
    public abstract class KeyValueDataStoreAdapterBase<TPropertyBag> : IKeyValueDataStore
        where TPropertyBag : Dictionary<string, object>
    {
        private readonly TPropertyBag _propertyBag;

        protected KeyValueDataStoreAdapterBase(TPropertyBag propertyBag)
        {
            _propertyBag = propertyBag;
        }

        /// <inheritdoc />
        public bool ContainsKey(string key)
        {
            return _propertyBag.ContainsKey(key);
        }

        /// <inheritdoc />
        public TValue GetValueByKey<TValue>(string key)
        {
            return (TValue) _propertyBag[key];
        }

        /// <inheritdoc />
        public void SetValueByKey<TValue>(TValue value, string key)
        {
            _propertyBag[key] = value;
        }
    }
}