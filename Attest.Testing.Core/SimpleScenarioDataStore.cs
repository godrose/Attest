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

        protected override bool ContainsKey(string key)
        {
            return Properties.Contains(key);
        }

        protected override T GetValueByKey<T>(string key)
        {
            return (T) Properties[key];
        }

        protected override void SetValueByKey<T>(T value, string key)
        {
            Properties[key] = value;
        }
    }
}