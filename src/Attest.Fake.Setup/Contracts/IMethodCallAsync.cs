using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents async method call without return value.
    /// </summary>
    /// <typeparam name="TService">Type of service.</typeparam>
    public interface IMethodCallAsync<TService> : IAcceptor<IMethodCallVisitorAsync<TService>> where TService : class
    {
        /// <summary>
        /// Method to be called.
        /// </summary>
        Expression<Func<TService, Task>> RunMethod { get; }
    }

    /// <summary>
    /// Represents async method call without return value and specific callback.
    /// </summary>
    /// <typeparam name="TService">Type of service.</typeparam>
    /// <typeparam name="TCallback">Type of callback.</typeparam>
    public interface IMethodCallAsync<TService, TCallback> :
        IMethodCallbacksContainer<TCallback>,
        IMethodCallAsync<TService> where TService : class
    {
    }
}