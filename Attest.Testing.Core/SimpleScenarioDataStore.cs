using System.Collections;
using System.Collections.Generic;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Simple implementation of <see cref="ScenarioDataStoreBase"/> using <see cref="Dictionary{TKey,TValue}"/>.
    /// </summary>
    public class SimpleScenarioDataStore : ScenarioDataStoreBase
    {
        private IDictionary Properties { get; } = new Dictionary<string, object>();

        /// <inheritdoc />
        protected override bool ContainsKey(string key)
        {
            return Properties.Contains(key);
        }

        /// <inheritdoc />
        protected override T GetValueByKey<T>(string key)
        {
            return (T) Properties[key];
        }

        /// <inheritdoc />
        protected override void SetValueByKey<T>(T value, string key)
        {
            Properties[key] = value;
        }
    }
}