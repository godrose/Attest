using System;

namespace Attest.Fake.Setup.Contracts
{
    public interface IAddCallback<TCallback>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);
        IMethodCallbacksContainer<TCallback> Complete();
        IMethodCallbacksContainer<TCallback> Throw(Exception exception);
    }
}