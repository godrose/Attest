using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{   
    /// <summary>
    /// Represents collection of callbacks
    /// </summary>
    /// <typeparam name="TCallback"></typeparam>
    public interface IHaveCallbacks<out TCallback>
    {
        IEnumerable<TCallback> Callbacks { get; } 
    }
}