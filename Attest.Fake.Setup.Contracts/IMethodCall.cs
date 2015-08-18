using System;
using System.Linq.Expressions;

namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallInitialTemplate<TService, TCallback> where TService : class
    {
        IMethodCall<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback>, IHaveCallbacks<TCallback>> buildCallbacks);        
    }    

    public interface IMethodCall<TService> : IAcceptorWithParameters<IMethodCallVisitor<TService>> where TService : class
    {
        Expression<Action<TService>> RunMethod { get; }     
    }

    public interface IMethodCall<TService, TCallback> : 
        IMethodCallbacksContainer<TCallback>, 
        IMethodCall<TService> where TService : class
    {        
    }

    public interface IMethodCallVisitor<TService> where TService : class
    {
        void Visit(IMethodCall<TService, IMethodCallback> methodCall);
        void Visit<T>(IMethodCall<TService, IMethodCallback<T>> methodCall);
        void Visit<T1, T2>(IMethodCall<TService, IMethodCallback<T1, T2>> methodCall);
        void Visit<T1, T2, T3>(IMethodCall<TService, IMethodCallback<T1, T2, T3>> methodCall);
        void Visit<T1, T2, T3, T4>(IMethodCall<TService, IMethodCallback<T1, T2, T3, T4>> methodCall);
        void Visit<T1, T2, T3, T4, T5>(IMethodCall<TService, IMethodCallback<T1, T2, T3, T4, T5>> methodCall);
    }
}