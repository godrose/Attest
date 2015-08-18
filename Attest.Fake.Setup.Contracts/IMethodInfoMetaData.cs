using System;

namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodInfoMetaData
    {
        string RunMethodDescription { get; }
        Type CallbackType { get; }
        bool HasDefaultCallback { get; }
    }
}