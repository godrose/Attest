using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration
{
    public interface IConfigurationSectionKeySplitter
    {
        IEnumerable<string> Split(string key);
    }
}
