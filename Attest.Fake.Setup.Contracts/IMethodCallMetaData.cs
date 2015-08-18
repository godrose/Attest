using System;

namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallMetaData
    {
        string RunMethodDescription { get; }
        Type CallbackType { get; }
    }
}