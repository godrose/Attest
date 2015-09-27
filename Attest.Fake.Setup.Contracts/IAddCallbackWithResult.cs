using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResultShared<TCallback, in TResult>
    {
        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback);

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        IMethodCallbacksContainer<TCallback> Complete(TResult result);        

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        IMethodCallbacksContainer<TCallback> WithoutCallback();   
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, in TResult> : IAddCallbackWithResultShared<TCallback, TResult>
    {        
        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        /// <returns>Callbacks container</returns>
        IMethodCallbacksContainer<TCallback> Complete(Func<TResult> valueFunction);       
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T">Type of first parameter</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, T, in TResult> : IAddCallbackWithResultShared<TCallback, TResult>
    {                
        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IMethodCallbacksContainer<TCallback> Complete(Func<T, TResult> valueFunction);
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>    
    public interface IAddCallbackWithResult<TCallback, T1, T2, in TResult> : IAddCallbackWithResultShared<TCallback, TResult>
    {
        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IMethodCallbacksContainer<TCallback> Complete(Func<T1, T2, TResult> valueFunction);
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, in TResult> : IAddCallbackWithResultShared<TCallback, TResult>
    {
        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IMethodCallbacksContainer<TCallback> Complete(Func<T1, T2, T3, TResult> valueFunction);        
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, T4, in TResult> : IAddCallbackWithResultShared<TCallback, TResult>
    {
        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IMethodCallbacksContainer<TCallback> Complete(Func<T1, T2, T3, T4, TResult> valueFunction);
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, in TResult> : IAddCallbackWithResultShared<TCallback, TResult>
    {
        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IMethodCallbacksContainer<TCallback> Complete(Func<T1, T2, T3, T4, T5, TResult> valueFunction);
    }
}