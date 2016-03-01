using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

    /// <summary>
    /// Used to add new method calls to the existing service call using explicit lambda expression API
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    public interface ICanAddMethodsEx<TService> where TService : class
    {
        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback>, IHaveCallbacks<IMethodCallback>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T>, T>, IHaveCallbacks<IMethodCallback<T>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T>, T>, T, IHaveCallbacks<IMethodCallback<T>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T1, T2>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2>, T1, T2>, IHaveCallbacks<IMethodCallback<T1, T2>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T1, T2>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2>, T1, T2>, T1, T2, IHaveCallbacks<IMethodCallback<T1, T2>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T1, T2, T3>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3>, T1, T2, T3>, IHaveCallbacks<IMethodCallback<T1, T2, T3>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T1, T2, T3>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3>, T1, T2, T3>, T1, T2, T3, IHaveCallbacks<IMethodCallback<T1, T2, T3>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T1, T2, T3, T4>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T1, T2, T3, T4>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>, T1, T2, T3, T4, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T1, T2, T3, T4, T5>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4, T5>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCall<T1, T2, T3, T4, T5>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4, T5>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<TResult>, TResult>, IHaveCallbacks<IMethodCallbackWithResult<TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<TResult>(Expression<Func<TService, Task<TResult>>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<TResult>, TResult>, 
                IHaveCallbacks<IMethodCallbackWithResult<TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>>
                callbacksProducer);        

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>, T,
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new async method call with return value.
        /// </summary>        
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>        
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<T, TResult>(
            Expression<Func<TService, Task<TResult>>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new async method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<T, TResult>(
            Expression<Func<TService, Task<TResult>>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>, T,
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T1, T2, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T1, T2, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>,
                T1, T2,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new async method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<T1, T2, TResult>(Expression<Func<TService, Task<TResult>>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new async method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<T1, T2, TResult>(Expression<Func<TService, Task<TResult>>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>,
                T1, T2,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T1, T2, T3, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T1, T2, T3, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>,
                T1, T2, T3,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new async method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<T1, T2, T3, TResult>(Expression<Func<TService, Task<TResult>>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new async method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<T1, T2, T3, TResult>(Expression<Func<TService, Task<TResult>>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>,
                T1, T2, T3,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T1, T2, T3, T4, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T1, T2, T3, T4, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>,
                T1, T2, T3, T4,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new async method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<T1, T2, T3, T4, TResult>(
            Expression<Func<TService, Task<TResult>>> runMethod,
            Func
                <IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>,
                    IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new async method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResultAsync<T1, T2, T3, T4, TResult>(
            Expression<Func<TService, Task<TResult>>> runMethod,
            Func
                <IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>,
                    T1, T2, T3, T4,
                    IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T1, T2, T3, T4, T5, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>>
                callbacksProducer);

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <param name="runMethod">The method to be set up.</param>
        /// <param name="callbacksProducer">The callbacks producer function.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> AddMethodCallWithResult<T1, T2, T3, T4, T5, TResult>(Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>,
                T1, T2, T3, T4, T5,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>>
                callbacksProducer);
    }
}