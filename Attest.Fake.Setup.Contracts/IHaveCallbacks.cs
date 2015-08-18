using System;
using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{   
    public interface IHaveCallbacks<out TCallback>
    {
        IEnumerable<TCallback> Callbacks { get; } 
    }

    public interface IAddCallback<TCallback>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);
        IMethodCallbacksContainer<TCallback> Complete();
        IMethodCallbacksContainer<TCallback> Throw(Exception exception);
    }

    public interface IAddCallbackWithResult<TCallback, in TResult>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);
        IMethodCallbacksContainer<TCallback> Complete(TResult result);
        IMethodCallbacksContainer<TCallback> Throw(Exception exception);
        IMethodCallbacksContainer<TCallback> WithoutCallback();
    }

    public interface IHaveNoCallbacks<TCallback> : IAddCallback<TCallback>
    {

    }

    public interface IHaveNoCallbacksWithResult<TCallback, in TResult> : IAddCallbackWithResult<TCallback, TResult>
    {

    }
}