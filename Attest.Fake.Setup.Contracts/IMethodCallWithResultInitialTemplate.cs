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
    public interface IMethodCallWithResultInitialTemplateBase<TService, TCallback, TResult, TInitialCallback> where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(
            Func<TInitialCallback, IHaveCallbacks<TCallback>> buildCallbacks);
    }


    /// <summary>
    /// Represents initial template for method call with return value and no parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, TResult> :
        IMethodCallWithResultInitialTemplateBase<TService, TCallback, TResult, IHaveNoCallbacksWithResult<TCallback, TResult>>
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
    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T, TResult> :
        IMethodCallWithResultInitialTemplateBase<TService, TCallback, TResult, IHaveNoCallbacksWithResult<TCallback, T, TResult>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <param name="arg">The parameter.</param>
        /// <returns></returns>
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<TCallback, T, TResult>, T, IHaveCallbacks<TCallback>> buildCallbacks, T arg);
    }

    /// <summary>
    /// Represents initial template for method call with return value and 2 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T1, T2, TResult> :
        IMethodCallWithResultInitialTemplateBase<TService, TCallback, TResult, IHaveNoCallbacksWithResult<TCallback, T1, T2, TResult>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>        
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <returns></returns>
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<TCallback, T1, T2, TResult>, T1, T2, IHaveCallbacks<TCallback>> buildCallbacks, T1 arg1, T2 arg2);
    }

    /// <summary>
    /// Represents initial template for method call with return value and 3 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T1, T2, T3, TResult> :
        IMethodCallWithResultInitialTemplateBase<TService, TCallback, TResult, IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, TResult>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>        
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <returns></returns>
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, TResult>, T1, T2, T3, IHaveCallbacks<TCallback>> buildCallbacks, T1 arg1, T2 arg2, T3 arg3);
    }

    /// <summary>
    /// Represents initial template for method call with return value and 4 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T1, T2, T3, T4, TResult> :
        IMethodCallWithResultInitialTemplateBase<TService, TCallback, TResult, IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, T4, TResult>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>        
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <returns></returns>
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, T4, TResult>, T1, T2, T3, T4, 
                IHaveCallbacks<TCallback>> buildCallbacks, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    /// <summary>
    /// Represents initial template for method call with return value and 5 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public interface IMethodCallWithResultInitialTemplate<TService, TCallback, T1, T2, T3, T4, T5, TResult> :
        IMethodCallWithResultInitialTemplateBase<TService, TCallback, TResult, IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, T4, T5, TResult>>
        where TService : class
    {
        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>        
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        /// <returns></returns>
        IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5,
                IHaveCallbacks<TCallback>> buildCallbacks, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
}