using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{   
    /// <summary>
    /// Represents collection of callbacks.
    /// </summary>
    /// <typeparam name="TCallback"></typeparam>
    public interface IHaveCallbacks<out TCallback>
    {
        /// <summary>
        /// Collection of callbacks.
        /// </summary>
        IEnumerable<TCallback> Callbacks { get; } 
    }
}