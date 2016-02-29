using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents initial template for method call with return value.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <typeparam name="TInitialCallback">The type of the initial template callback.</typeparam>
    public interface IMethodCallWithResultInitialTemplateBaseAsync<TService, TCallback, TResult, TInitialCallback> 
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        IMethodCallWithResultAsync<TService, TCallback, TResult> BuildCallbacks(
            Func<TInitialCallback, IHaveCallbacks<TCallback>> buildCallbacks);
    }

    /// <summary>
    /// Represents initial template for method call with return value and no parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public interface IMethodCallWithResultInitialTemplateAsync<TService, TCallback, TResult> :
        IMethodCallWithResultInitialTemplateBaseAsync<TService, TCallback, TResult, IHaveNoCallbacksWithResult<TCallback, TResult>>
        where TService : class
    {
    }

    /// <summary>
    /// Represents initial template for method call with return value and 1 parameter.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public interface IMethodCallWithResultInitialTemplateAsync<TService, TCallback, T, TResult> :
        IMethodCallWithResultInitialTemplateBaseAsync<TService, TCallback, TResult, 
        IHaveNoCallbacksWithResult<TCallback, T, TResult>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value using specified callbacks producer.
        /// </summary>
        /// <param name="callbacksProducer">The callbacks producer.</param>                
        /// <returns></returns>
        IMethodCallWithResultAsync<TService, TCallback, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<TCallback, T, TResult>,
                T, IHaveCallbacks<TCallback>> callbacksProducer);
    }
}