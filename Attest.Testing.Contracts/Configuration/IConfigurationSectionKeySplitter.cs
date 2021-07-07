using System.Collections.Generic;

namespace Attest.Testing.Configuration
{
    public interface IConfigurationSectionKeySplitter
    {
        IEnumerable<string> Split(string key);
    }
}
