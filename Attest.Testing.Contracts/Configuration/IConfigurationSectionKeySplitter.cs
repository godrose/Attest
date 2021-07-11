using System.Collections.Generic;

namespace Attest.Testing.Configuration
{
    /// <summary>
    /// Represents configuration section key splitter.
    /// Use for cases where a key adheres to a certain convention.
    /// </summary>
    public interface IConfigurationSectionKeySplitter
    {
        /// <summary>
        /// Splits key into the sections.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        IEnumerable<string> Split(string key);
    }
}
