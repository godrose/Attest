using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that allows creating new method call using callbacks mapping function
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="TInitialCallback">Type of the initial callback.</typeparam>
    public interface IMethodCallInitialTemplateBaseAsync<TService, TCallback, TInitialCallback> where TService : class
    {
        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        IMethodCallAsync<TService, TCallback> BuildCallbacks(
            Func<TInitialCallback, IHaveCallbacks<TCallback>> buildCallbacks);
    }

    /// <summary>
    /// Represents initial template for method call with no parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>    
    public interface IMethodCallInitialTemplateAsync<TService, TCallback> :
        IMethodCallInitialTemplateBaseAsync<TService, TCallback, IHaveNoCallbacks<TCallback>>
        where TService : class
    {
    }
}