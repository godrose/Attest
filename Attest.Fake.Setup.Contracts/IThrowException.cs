using System;

namespace Attest.Fake.Setup.Contracts
{
    public interface IThrowException
    {
        Exception Exception { get; }
    }
}