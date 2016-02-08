using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    public interface IAddCallbackShared<TCallback>
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
        /// <returns>Callbacks container</returns>
        IMethodCallbacksContainer<TCallback> Complete();

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Callbacks container</returns>
        IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        ///// <summary>
        ///// Adds never-ending callback to the callbacks container
        ///// </summary>
        ///// <returns>Callbacks container</returns>
        //IMethodCallbacksContainer<TCallback> WithoutCallback();
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>    
    public interface IAddCallback<TCallback> : IAddCallbackShared<TCallback>
    {
        
    }

    /// <summary>
    /// Represents an object that allows to add callbacks to the callbacks container
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    /// <typeparam name="T">The type of the parameter.</typeparam>    
    public interface IAddCallback<TCallback, T> : IAddCallbackShared<TCallback>
    {
        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="callback">Successful completion callback</param>
        IMethodCallbacksContainer<TCallback> Complete(Action<T> callback);
    }
}