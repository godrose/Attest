using System;
using System.Linq.Expressions;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents method call with return value
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IMethodCallWithResult<TService>
        : IAcceptor<IMethodCallWithResultVisitor<TService>> where TService : class
    {
        
    }

    /// <summary>
    /// Represents method call with return value and specific callback.
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IMethodCallWithResult<TService, TCallback, TResult> : 
        IMethodCallbacksContainer<TCallback>,
        IMethodCallWithResult<TService> where TService : class
    {
        /// <summary>
        /// Method to be called.
        /// </summary>
        Expression<Func<TService, TResult>> RunMethod { get; }
    }   
}