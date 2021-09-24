using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Configuration
{
    /// <summary>
    /// Provides facilities for interacting with configuration sections.
    /// </summary>
    public interface IConfigurationSectionValueProvider
    {
        /// <summary>
        /// Gets the value for the configuration section by its key.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="key">The section key.</param>
        /// <returns></returns>
        string GetValue(IConfiguration configuration, string key);
    }
}
