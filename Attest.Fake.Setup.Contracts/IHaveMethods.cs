using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Used to add new method calls to the existing service call
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    public interface ICanAddMethods<TService> where TService : class
    {
        /// <summary>
        /// Adds a new method call without return value
        /// </summary>
        /// <typeparam name="TCallback">Type of callback</typeparam>
        /// <param name="methodCall">Method call</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<TCallback>(IMethodCall<TService, TCallback> methodCall);

        /// <summary>
        /// Adds a new method call with return value
        /// </summary>
        /// <typeparam name="TCallback">Type of callback</typeparam>
        /// <typeparam name="TResult">Type of return value</typeparam>
        /// <param name="methodCall">Method call</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<TCallback, TResult>(
            IMethodCallWithResult<TService, TCallback, TResult> methodCall);            
    }

    /// <summary>
    /// Represents a service call which has no method calls yet
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IHaveNoMethods<TService> : ICanAddMethods<TService> where TService : class
    {
    }

    /// <summary>
    /// Used to append collection of method calls to the existing service call
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IAppendMethods<TService> where TService : class
    {
        void AppendMethods(IHaveMethods<TService> otherMethods);
    }

    /// <summary>
    /// Represents a method calls container
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IHaveMethods<TService> : ICanAddMethods<TService> where TService: class
    {
        /// <summary>
        /// Collection of method calls
        /// </summary>
        IEnumerable<IMethodCallMetaData> MethodCalls { get; }        
    }
}