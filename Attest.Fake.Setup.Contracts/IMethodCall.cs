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
}