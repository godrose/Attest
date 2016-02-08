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
}