﻿using System.Runtime.CompilerServices;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Base class for scenario data stores.
    /// It allows storing and retrieving values dynamically.
    /// </summary>
    public abstract class ScenarioDataStoreBase
    {
        private readonly IKeyedDataStore _keyedDataStore;

        /// <summary>
        /// Creates an instance of <see cref="ScenarioDataStoreBase"/>
        /// </summary>
        /// <param name="keyedDataStore"></param>
        protected ScenarioDataStoreBase(IKeyedDataStore keyedDataStore)
        {
            _keyedDataStore = keyedDataStore;
        }

        /// <summary>
        /// Gets stored value by the specified key.
        /// Returns the specified default value if the value cannot be found using the specified key.
        /// If no default value is specified then the default value for the type is returned.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected T GetValueImpl<T>(T defaultValue = default, [CallerMemberName] string key = default)
        {
            var coercedKey = Coerce(key);
            return _keyedDataStore.ContainsKey(coercedKey) ? _keyedDataStore.GetValueByKey<T>(coercedKey) : defaultValue;
        }

        /// <summary>
        /// Sets value using the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        protected void SetValueImpl<T>(T value, [CallerMemberName] string key = default)
        {
            var coercedKey = Coerce(key);
            _keyedDataStore.SetValueByKey(value, coercedKey);
        }

        private static string Coerce(string key)
        {
            return key ?? string.Empty;
        }
    }
}
