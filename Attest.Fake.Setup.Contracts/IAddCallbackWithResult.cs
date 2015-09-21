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

    public interface IAddCallbackWithResult<TCallback, T, in TResult>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);

        IMethodCallbacksContainer<TCallback> Complete(TResult result);

        IMethodCallbacksContainer<TCallback> Complete(Func<T, TResult> result);

        IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        IMethodCallbacksContainer<TCallback> WithoutCallback();
    }

    public interface IAddCallbackWithResult<TCallback, T1, T2, in TResult>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);

        IMethodCallbacksContainer<TCallback> Complete(TResult result);

        IMethodCallbacksContainer<TCallback> Complete(Func<T1, T2, TResult> result);

        IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        IMethodCallbacksContainer<TCallback> WithoutCallback();
    }

    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, in TResult>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);

        IMethodCallbacksContainer<TCallback> Complete(TResult result);

        IMethodCallbacksContainer<TCallback> Complete(Func<T1, T2, T3, TResult> result);

        IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        IMethodCallbacksContainer<TCallback> WithoutCallback();
    }

    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, T4, in TResult>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);

        IMethodCallbacksContainer<TCallback> Complete(TResult result);

        IMethodCallbacksContainer<TCallback> Complete(Func<T1, T2, T3, T4, TResult> valueFunction);

        IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        IMethodCallbacksContainer<TCallback> WithoutCallback();
    }

    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, in TResult>
    {
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);

        IMethodCallbacksContainer<TCallback> Complete(TResult result);

        IMethodCallbacksContainer<TCallback> Complete(Func<T1, T2, T3, T4, T5, TResult> valueFunction);

        IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        IMethodCallbacksContainer<TCallback> WithoutCallback();
    }
}