using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Configuration
{
    /// <summary>
    /// Provides facilities for interacting with configuration sections.
    /// </summary>
    public class ConfigurationSectionValueProvider : IConfigurationSectionValueProvider
    {
        private readonly IConfigurationSectionKeySplitter _configurationSectionKeySplitter;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigurationSectionValueProvider"/>
        /// </summary>
        /// <param name="configurationSectionKeySplitter">The configuration section key splitter.</param>
        public ConfigurationSectionValueProvider(
            IConfigurationSectionKeySplitter configurationSectionKeySplitter)
        {
            _configurationSectionKeySplitter = configurationSectionKeySplitter;
        }

        /// <inheritdoc />
        public string GetValue(IConfiguration configuration, string key)
        {
            var sections = 
                _configurationSectionKeySplitter.Split(key)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
            IConfigurationSection section = null;
            foreach (var sectionName in sections)
            {
                section = section == null ? configuration.GetSection(sectionName) : section.GetSection(sectionName);
            }

            var value = section?.Value;
            return value;
        }
    }
}
