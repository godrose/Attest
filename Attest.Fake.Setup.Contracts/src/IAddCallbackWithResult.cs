using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    public interface IAddCallbackWithResultShared<TCallback> : IHaveCallbacks<TCallback>
    {
                 
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, in TResult> : IAddCallbackWithResultShared<TCallback>
    {
        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, TResult> AddCallback(TCallback methodCallback);

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, TResult> Throw(Exception exception);

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, TResult> WithoutCallback();

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, TResult> Complete(TResult result);

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, TResult> Complete(Func<TResult> valueFunction);        
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T">Type of first parameter</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, T, in TResult> : IAddCallbackWithResultShared<TCallback>
    {
        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T, TResult> AddCallback(TCallback methodCallback);

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T, TResult> Throw(Exception exception);

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T, TResult> WithoutCallback();

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T, TResult> Complete(TResult result);

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IAddCallbackWithResult<TCallback, T, TResult> Complete(Func<T, TResult> valueFunction);       
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>    
    public interface IAddCallbackWithResult<TCallback, T1, T2, in TResult> : IAddCallbackWithResultShared<TCallback>
    {
        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, TResult> AddCallback(TCallback methodCallback);

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, TResult> Throw(Exception exception);

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, TResult> WithoutCallback();

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, TResult> Complete(TResult result);

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IAddCallbackWithResult<TCallback, T1, T2, TResult> Complete(Func<T1, T2, TResult> valueFunction);
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, in TResult> : IAddCallbackWithResultShared<TCallback>
    {
        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, TResult> AddCallback(TCallback methodCallback);

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, TResult> Throw(Exception exception);

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, TResult> WithoutCallback();

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, TResult> Complete(TResult result);

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IAddCallbackWithResult<TCallback, T1, T2, T3, TResult> Complete(Func<T1, T2, T3, TResult> valueFunction);        
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>    
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, T4, in TResult> : IAddCallbackWithResultShared<TCallback>
    {
        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, TResult> AddCallback(TCallback methodCallback);

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, TResult> Throw(Exception exception);

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, TResult> WithoutCallback();

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, TResult> Complete(TResult result);

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, TResult> Complete(Func<T1, T2, T3, T4, TResult> valueFunction);
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
    public interface IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, in TResult> : IAddCallbackWithResultShared<TCallback>
    {
        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, TResult> AddCallback(TCallback methodCallback);

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, TResult> Throw(Exception exception);

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, TResult> WithoutCallback();

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, TResult> Complete(TResult result);

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, TResult> Complete(Func<T1, T2, T3, T4, T5, TResult> valueFunction);
    }
}