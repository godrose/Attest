using System;

namespace Attest.Fake.Setup.Contracts
{    
    /// <summary>
    /// Represents an object that allows creating new method call using callbacks mapping function
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="TInitialCallback">Type of the initial callback.</typeparam>
    public interface IMethodCallInitialTemplateBase<TService, TCallback, TInitialCallback> where TService : class
    {
        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        IMethodCall<TService, TCallback> BuildCallbacks(
            Func<TInitialCallback, IHaveCallbacks<TCallback>> buildCallbacks);
    }

    /// <summary>
    /// Represents initial template for method call with no parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>    
    public interface IMethodCallInitialTemplate<TService, TCallback> :
        IMethodCallInitialTemplateBase<TService, TCallback, IHaveNoCallbacks<TCallback>>
        where TService : class
    {        
    }

    /// <summary>
    /// Represents initial template for method call with one parameter.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T">The type of the parameter.</typeparam>    
    public interface IMethodCallInitialTemplate<TService, TCallback, T> :
        IMethodCallInitialTemplateBase<TService, TCallback, IHaveNoCallbacks<TCallback, T>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="callbacksProducer">The build callbacks.</param>        
        /// <returns></returns>
        IMethodCall<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback, T>, T, IHaveCallbacks<TCallback>> callbacksProducer);
    }

    /// <summary>
    /// Represents initial template for method call with two parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    public interface IMethodCallInitialTemplate<TService, TCallback, T1, T2> :
        IMethodCallInitialTemplateBase<TService, TCallback, IHaveNoCallbacks<TCallback, T1, T2>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value using specified callbacks producer.
        /// </summary>
        /// <param name="callbacksProducer">The callbacks producer.</param>                
        /// <returns></returns>
        IMethodCall<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback, T1, T2>, T1, T2, IHaveCallbacks<TCallback>> callbacksProducer);
    }

    /// <summary>
    /// Represents initial template for method call with three parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    public interface IMethodCallInitialTemplate<TService, TCallback, T1, T2, T3> :
        IMethodCallInitialTemplateBase<TService, TCallback, IHaveNoCallbacks<TCallback, T1, T2, T3>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value using specified callbacks producer.
        /// </summary>
        /// <param name="callbacksProducer">The callbacks producer.</param>                
        /// <returns></returns>
        IMethodCall<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback, T1, T2, T3>, T1, T2, T3, IHaveCallbacks<TCallback>> callbacksProducer);
    }

    /// <summary>
    /// Represents initial template for method call with four parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    public interface IMethodCallInitialTemplate<TService, TCallback, T1, T2, T3, T4> :
        IMethodCallInitialTemplateBase<TService, TCallback, IHaveNoCallbacks<TCallback, T1, T2, T3, T4>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value using specified callbacks producer.
        /// </summary>
        /// <param name="callbacksProducer">The callbacks producer.</param>                
        /// <returns></returns>
        IMethodCall<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback, T1, T2, T3, T4>, T1, T2, T3, T4, IHaveCallbacks<TCallback>> callbacksProducer);
    }

    /// <summary>
    /// Represents initial template for method call with five parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    public interface IMethodCallInitialTemplate<TService, TCallback, T1, T2, T3, T4, T5> :
        IMethodCallInitialTemplateBase<TService, TCallback, IHaveNoCallbacks<TCallback, T1, T2, T3, T4, T5>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value using specified callbacks producer.
        /// </summary>
        /// <param name="callbacksProducer">The callbacks producer.</param>                
        /// <returns></returns>
        IMethodCall<TService, TCallback> BuildCallbacks(
            Func<IHaveNoCallbacks<TCallback, T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5, IHaveCallbacks<TCallback>> callbacksProducer);
    }
}