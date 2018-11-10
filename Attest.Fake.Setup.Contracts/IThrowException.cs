using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that throws exception
    /// </summary>
    public interface IThrowException
    {
        /// <summary>
        /// Exception to be thrown
        /// </summary>
        Exception Exception { get; }
    }
}