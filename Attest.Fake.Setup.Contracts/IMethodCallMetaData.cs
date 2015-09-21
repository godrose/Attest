using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents method description, storing the callback type
    /// </summary>
    public interface IMethodCallMetaData
    {
        string RunMethodDescription { get; }
        Type CallbackType { get; }
    }
}