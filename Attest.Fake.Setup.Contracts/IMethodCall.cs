using System;
using System.Linq.Expressions;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallInitialTemplate<TService, TCallback> where TService : class
    {
        IMethodCall<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback>, IHaveCallbacks<TCallback>> buildCallbacks);        
    }

    public interface IMethodCall<TService> : IAcceptor<IMethodCallVisitor<TService>> where TService : class
    {
        Expression<Action<TService>> RunMethod { get; }     
    }

    public interface IMethodCall<TService, TCallback> : 
        IMethodCallbacksContainer<TCallback>, 
        IMethodCall<TService> where TService : class
    {        
    }
}