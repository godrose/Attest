using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{   
    public interface IHaveCallbacks<out TCallback>
    {
        IEnumerable<TCallback> Callbacks { get; } 
    }
}