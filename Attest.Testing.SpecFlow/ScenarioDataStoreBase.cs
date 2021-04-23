using System.Runtime.CompilerServices;
using ScenarioContext = TechTalk.SpecFlow.ScenarioContext;

namespace Attest.Testing.SpecFlow
{
    /// <summary>
    /// Base class for scenario data stores. It allows storing and retrieving values dynamically.
    /// </summary>
    public abstract class ScenarioDataStoreBase
    {
        private readonly ScenarioContext _scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioDataStoreBase"/> class.
        /// </summary>
        /// <param name="scenarioContext"></param>
        protected ScenarioDataStoreBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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
            return _scenarioContext.ContainsKey(Coerce(key)) ? (T) _scenarioContext[Coerce(key)] : defaultValue;
        }

        /// <summary>
        /// Sets value using the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        protected void SetValueImpl<T>(T value, [CallerMemberName] string key = default)
        {
            _scenarioContext[Coerce(key)] = value;
        }

        private static string Coerce(string key)
        {
            return key ?? string.Empty;
        }
    }
}
