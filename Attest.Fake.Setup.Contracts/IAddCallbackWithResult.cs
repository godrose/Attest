using System;

namespace Attest.Fake.Setup.Contracts
{
    public interface IAddCallbackWithResult<TCallback, in TResult>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);
        IMethodCallbacksContainer<TCallback> Complete(TResult result);
        IMethodCallbacksContainer<TCallback> Complete(Func<TResult> valueFunction);
        IMethodCallbacksContainer<TCallback> Throw(Exception exception);
        IMethodCallbacksContainer<TCallback> WithoutCallback();
    }
}