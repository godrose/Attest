using System;
using System.Linq.Expressions;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a service's method call without return value.
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
    /// Represents a service's method call with provided callbacks.
    /// </summary>
    /// <typeparam name="TService">Type of service.</typeparam>
    /// <typeparam name="TCallback">Type of callback.</typeparam>
    public interface IMethodCall<TService, TCallback> : 
        IMethodCallbacksContainer<TCallback>, 
        IMethodCall<TService> where TService : class
    {        
    }

    public interface IGenerateMethodCallback<T>
    {
        void EvaluateArguments(T arg);
    }

    public interface IGenerateMethodCallback<T1, T2>
    {
        void EvaluateArguments(T1 arg1, T2 arg2);
    }
}