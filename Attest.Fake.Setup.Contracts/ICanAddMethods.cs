namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Used to add new method calls to the existing service call
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    public interface ICanAddMethods<TService> where TService : class
    {
        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>
        /// <typeparam name="TCallback">Type of callback</typeparam>
        /// <param name="methodCall">Method call</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<TCallback>(IMethodCall<TService, TCallback> methodCall);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <typeparam name="TCallback">Type of callback</typeparam>
        /// <typeparam name="TResult">Type of return value</typeparam>
        /// <param name="methodCall">Method call</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<TCallback, TResult>(
            IMethodCallWithResult<TService, TCallback, TResult> methodCall);            
    }
}