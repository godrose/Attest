﻿using System;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.DataStore
{
    /// <summary>
    /// Base class for scenario data stores.
    /// It allows storing and retrieving values dynamically.
    /// </summary>
    public abstract class ScenarioDataStoreBase
    {
        private readonly IKeyValueDataStore _keyValueDataStore;

        /// <summary>
        /// Creates an instance of <see cref="ScenarioDataStoreBase"/>
        /// </summary>
        /// <param name="keyValueDataStore"></param>
        protected ScenarioDataStoreBase(IKeyValueDataStore keyValueDataStore)
        {
            _keyValueDataStore = keyValueDataStore;
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
        protected T GetValue<T>(T defaultValue = default, [CallerMemberName] string key = default)
        {
            return GetValueImpl(defaultValue, key);
        }

        /// <summary>
        /// Gets stored value by the specified key.
        /// Returns the specified default value if the value cannot be found using the specified key.
        /// If no default value is specified then the default value for the type is returned.
        /// This method is deprecated and will be removed in the next major release.
        /// Use <see cref="GetValue{T}"/> instead.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        [Obsolete]
        protected T GetValueImpl<T>(T defaultValue = default, [CallerMemberName] string key = default)
        {
            var coercedKey = Coerce(key);
            return _keyValueDataStore.ContainsKey(coercedKey) ? _keyValueDataStore.GetValueByKey<T>(coercedKey) : defaultValue;
        }

        /// <summary>
        /// Sets value using the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        protected void SetValue<T>(T value, [CallerMemberName] string key = default)
        {
            var coercedKey = Coerce(key);
            _keyValueDataStore.SetValueByKey(value, coercedKey);
        }

        /// <summary>
        /// Sets value using the specified key.
        /// This method is deprecated and will be removed in the next major release.
        /// Use <see cref="SetValue{T}"/> instead.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        [Obsolete]
        protected void SetValueImpl<T>(T value, [CallerMemberName] string key = default)
        {
            var coercedKey = Coerce(key);
            _keyValueDataStore.SetValueByKey(value, coercedKey);
        }

        private static string Coerce(string key)
        {
            return key ?? string.Empty;
        }
    }
}
