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

    /// <summary>
    /// Represents initial template for async method call with one parameter.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T">The type of the parameter.</typeparam>    
    public interface IMethodCallInitialTemplateAsync<TService, TCallback, T> :
        IMethodCallInitialTemplateBaseAsync<TService, TCallback, IHaveNoCallbacks<TCallback, T>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="callbacksProducer">The build callbacks.</param>        
        /// <returns></returns>
        IMethodCallAsync<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback, T>, T, IHaveCallbacks<TCallback>> callbacksProducer);
    }

    /// <summary>
    /// Represents initial template for async method call with two parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    public interface IMethodCallInitialTemplateAsync<TService, TCallback, T1, T2> :
        IMethodCallInitialTemplateBaseAsync<TService, TCallback, IHaveNoCallbacks<TCallback, T1, T2>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value using specified callbacks producer.
        /// </summary>
        /// <param name="callbacksProducer">The callbacks producer.</param>                
        /// <returns></returns>
        IMethodCallAsync<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback, T1, T2>, T1, T2, IHaveCallbacks<TCallback>> callbacksProducer);
    }

    /// <summary>
    /// Represents initial template for method call with 3 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    public interface IMethodCallInitialTemplateAsync<TService, TCallback, T1, T2, T3> :
        IMethodCallInitialTemplateBaseAsync<TService, TCallback, IHaveNoCallbacks<TCallback, T1, T2, T3>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value using specified callbacks producer.
        /// </summary>
        /// <param name="callbacksProducer">The callbacks producer.</param>                
        /// <returns></returns>
        IMethodCallAsync<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback, T1, T2, T3>, T1, T2, T3, IHaveCallbacks<TCallback>> callbacksProducer);
    }
}