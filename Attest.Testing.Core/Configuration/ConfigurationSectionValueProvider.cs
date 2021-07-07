using System.Linq;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration
{
    /// <inheritdoc />
    public class ConfigurationSectionValueProvider : IConfigurationSectionValueProvider
    {
        private readonly IConfigurationSectionKeySplitter _configurationSectionKeySplitter;

        public ConfigurationSectionValueProvider(IConfigurationSectionKeySplitter configurationSectionKeySplitter)
        {
            _configurationSectionKeySplitter = configurationSectionKeySplitter;
        }

        /// <inheritdoc />
        public string GetValue(IConfiguration configuration, string key)
        {
            var sections = //key.Split(new[] {"__"}, StringSplitOptions.None)
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
