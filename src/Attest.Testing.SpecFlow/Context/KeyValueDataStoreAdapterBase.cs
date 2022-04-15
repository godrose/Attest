using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
{
    /// <summary>
    /// Represents key-value wrapper around a property bag/map implementation.
    /// </summary>
    /// <typeparam name="TPropertyBag">The type of the property bag/map.</typeparam>
    public abstract class KeyValueDataStoreAdapterBase<TPropertyBag> : IKeyValueDataStore
        where TPropertyBag : Dictionary<string, object>
    {
        private readonly TPropertyBag _propertyBag;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValueDataStoreAdapterBase{TPropertyBag}"/> class.
        /// </summary>
        /// <param name="propertyBag">The property bag/map.</param>
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