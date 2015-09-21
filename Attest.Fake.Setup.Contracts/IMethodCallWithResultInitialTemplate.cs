using System;

namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, TResult> where TService : class
    {
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<TCallback, TResult>, IHaveCallbacks<TCallback>> buildCallbacks);        
    }

    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T, TResult> where TService : class
    {
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<TCallback, T, TResult>, IHaveCallbacks<TCallback>> buildCallbacks);
    }

    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T1, T2, TResult> where TService : class
    {
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<TCallback, T1, T2, TResult>, IHaveCallbacks<TCallback>> buildCallbacks);
    }

    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T1, T2, T3, TResult> where TService : class
    {
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, TResult>, IHaveCallbacks<TCallback>> buildCallbacks);
    }

    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T1, T2, T3, T4, TResult> where TService : class
    {
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, T4, TResult>, IHaveCallbacks<TCallback>> buildCallbacks);
    }

    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T1, T2, T3, T4, T5, TResult> where TService : class
    {
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, T4, T5, TResult>, IHaveCallbacks<TCallback>> buildCallbacks);
    }
}