using System;
using System.Linq.Expressions;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a service's method call with return value
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IMethodCallWithResult<TService, TResult> :
        IAcceptor<IMethodCallWithResultVisitor<TService>> where TService : class
    {
        Expression<Func<TService, TResult>> RunMethod { get; }
    }

    /// <summary>
    /// Represents a service's method call with return value
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IMethodCallWithResult<TService, TCallback, TResult> : 
        IMethodCallbacksContainer<TCallback>,        
        IMethodCallWithResult<TService, TResult> where TService : class
    {
        
    }
}