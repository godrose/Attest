using System;
using System.Linq.Expressions;

namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, TResult> where TService : class
    {
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<TCallback, TResult>, IHaveCallbacks<TCallback>> buildCallbacks);        
    }

    public interface IMethodCallWithResult<TService, TResult> :
        IAcceptorWithParameters<IMethodCallWithResultVisitor<TService>> where TService : class
    {
        Expression<Func<TService, TResult>> RunMethod { get; }
    }

    public interface IMethodCallWithResult<TService, TCallback, TResult> : 
        IMethodCallbacksContainer<TCallback>,
        IMethodCallWithResult<TService, TResult> where TService : class
    {
        
    }

    public interface IMethodCallWithResultVisitor<TService> where TService : class
    {
        void Visit<TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<TResult>, TResult> methodCall);
        void Visit<T, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall);
        void Visit<T1, T2, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall);
    }
}