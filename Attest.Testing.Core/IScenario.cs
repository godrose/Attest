namespace Attest.Testing.Core
{
    /// <summary>
    /// Represents scenario's internal storage which is used to store values 
    /// per scenario's context.
    /// </summary>
    public interface IScenario
    {
        /// <summary>
        /// Adds the object to the internal storage.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Add(string key, object value);

        /// <summary>
        /// Determines whether the internal storage contains the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Clears the internal storage.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="System.Object"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        object this[string key] { get; set; }        
    }
}
