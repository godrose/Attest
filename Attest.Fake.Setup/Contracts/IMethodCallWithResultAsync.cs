using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents async method call with return value
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IMethodCallWithResultAsync<TService>
        : IAcceptor<IMethodCallWithResultVisitorAsync<TService>> where TService : class
    {

    }

    /// <summary>
    /// Represents async method call with return value and specific callback.
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IMethodCallWithResultAsync<TService, TCallback, TResult> :
        IMethodCallbacksContainer<TCallback>,
        IMethodCallWithResultAsync<TService> where TService : class
    {
        /// <summary>
        /// Method to be called.
        /// </summary>
        Expression<Func<TService, Task<TResult>>> RunMethod { get; }
    }
}