using System;
using System.Linq.Expressions;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents method call without return value.
    /// </summary>
    /// <typeparam name="TService">Type of service.</typeparam>
    public interface IMethodCall<TService> : IAcceptor<IMethodCallVisitor<TService>> where TService : class
    {
        /// <summary>
        /// Method to be called.
        /// </summary>
        Expression<Action<TService>> RunMethod { get; }     
    }

    /// <summary>
    /// Represents method call without return value and specific callback.
    /// </summary>
    /// <typeparam name="TService">Type of service.</typeparam>
    /// <typeparam name="TCallback">Type of callback.</typeparam>
    public interface IMethodCall<TService, TCallback> : 
        IMethodCallbacksContainer<TCallback>, 
        IMethodCall<TService> where TService : class
    {        
    }    
}