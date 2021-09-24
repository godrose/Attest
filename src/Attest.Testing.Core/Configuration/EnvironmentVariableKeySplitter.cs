using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration
{
    /// <summary>
    /// Represents key splitter which uses convention for environment variables support.
    /// </summary>
    public sealed class EnvironmentVariableKeySplitter : IConfigurationSectionKeySplitter
    {
        /// <inheritdoc />
        public IEnumerable<string> Split(string key)
        {
            return key.Split(new[] {"__"}, StringSplitOptions.None);
        }
    }
}
