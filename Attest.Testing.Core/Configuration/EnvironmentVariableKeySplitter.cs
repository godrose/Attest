using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration
{
    public sealed class EnvironmentVariableKeySplitter : IConfigurationSectionKeySplitter
    {
        /// <inheritdoc />
        public IEnumerable<string> Split(string key)
        {
            return key.Split(new[] {"__"}, StringSplitOptions.None);
        }
    }
}
