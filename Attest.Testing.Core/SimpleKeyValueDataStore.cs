using System.Collections;
using System.Collections.Generic;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Simple implementation of <see cref="IKeyValueDataStore"/> using <see cref="Dictionary{TKey,TValue}"/>.
    /// </summary>
    public class SimpleKeyValueDataStore : IKeyValueDataStore
    {
        private IDictionary Properties { get; } = new Dictionary<string, object>();

        /// <inheritdoc />
        public bool ContainsKey(string key)
        {
            return Properties.Contains(key);
        }

        /// <inheritdoc />
        public T GetValueByKey<T>(string key)
        {
            return (T) Properties[key];
        }

        /// <inheritdoc />
        public void SetValueByKey<T>(T value, string key)
        {
            Properties[key] = value;
        }
    }
}