using System.Collections.Generic;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Base class for all callbacks collections' objects
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    public abstract class HaveCallbacksBase<TCallback> : IHaveCallbacks<TCallback>
    {
        protected readonly List<TCallback> Callbacks = new List<TCallback>();
        IEnumerable<TCallback> IHaveCallbacks<TCallback>.Callbacks
        {
            get { return Callbacks; }
        }
    }
}