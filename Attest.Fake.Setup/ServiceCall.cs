using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Represents a list of method calls on a specific type of service.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <seealso cref="Contracts.IServiceCall{TService}" />
    /// <seealso cref="Contracts.IHaveNoMethods{TService}" />
    public class ServiceCall<TService> : IServiceCall<TService>, IHaveNoMethods<TService> where TService : class
    {
        private readonly IFake<TService> _fake;
        private readonly IServiceSetupFactory<TService> _serviceSetupFactory = new ServiceSetupFactory<TService>();

        internal ServiceCall(IFake<TService> fake)
        {
            _fake = fake;
        }

        private readonly List<IMethodCallMetaData> _methodCalls = new List<IMethodCallMetaData>();

        private IEnumerable<IMethodCallMetaData> MethodCalls
        {
            get { return _methodCalls; }
        }
        IEnumerable<IMethodCallMetaData> IHaveMethods<TService>.MethodCalls 
        {
            get { return MethodCalls; }
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServiceCall{TService}"/> without method calls.
        /// </summary>
        /// <param name="fake">The initial fake.</param>
        /// <returns></returns>
        public static IHaveNoMethods<TService> CreateServiceCall(IFake<TService> fake)
        {
            return new ServiceCall<TService>(fake);
        }

        private void AddMethodCall(IMethodCallMetaData methodCallMetaData)
        {
            var newMethodInfo = methodCallMetaData as IMethodCall<TService>;
            if (newMethodInfo != null)
            {
                AddMethodCallImpl(methodCallMetaData, newMethodInfo);
            }
            else
            {
                var newMethodWithResultInfo = methodCallMetaData as IMethodCallWithResult<TService>;
                if (newMethodWithResultInfo == null)
                {
                    throw new ArgumentException(
                        "Only method calls that implement acceptor for either MethodCall or MethodCallWithResult visitors are allowed",
                        "methodCallMetaData");
                }
                AddMethodCallWithResultImpl(methodCallMetaData, newMethodWithResultInfo);
            }
        }

        /// <summary>
        /// Adds a new method call without return value.
        /// </summary>
        /// <typeparam name="TCallback">Type of callback.</typeparam>
        /// <param name="methodCall">Method call.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> ICanAddMethods<TService>.AddMethodCall<TCallback>(IMethodCall<TService,TCallback> methodCall)
        {
            AddMethodCallImpl(methodCall, methodCall);   
            return this;
        }

        /// <summary>
        /// Adds a new method call with return value.
        /// </summary>
        /// <typeparam name="TCallback">Type of callback.</typeparam>
        /// <typeparam name="TResult">Type of return value.</typeparam>
        /// <param name="methodCall">Method call.</param>
        /// <returns>Service call</returns>
        IServiceCall<TService> ICanAddMethods<TService>.AddMethodCall<TCallback, TResult>(IMethodCallWithResult<TService, TCallback, TResult> methodCall)
        {
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T>, T>, T, IHaveCallbacks<IMethodCallback<T>>>
                callbacksProducer)
        {
            var methodCall = MethodCall<TService, T>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall(Expression<Action<TService>> runMethod, 
            Func<IHaveNoCallbacks<IMethodCallback>, IHaveCallbacks<IMethodCallback>> callbacksProducer)
        {
            var methodCall = MethodCall<TService>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T>(
            Expression<Action<TService>> runMethod, Func<IHaveNoCallbacks<IMethodCallback<T>, T>,
                IHaveCallbacks<IMethodCallback<T>>> callbacksProducer)
        {
            var methodCall = MethodCall<TService, T>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T1, T2>(Expression<Action<TService>> runMethod, Func<IHaveNoCallbacks<IMethodCallback<T1, T2>, T1, T2>, IHaveCallbacks<IMethodCallback<T1, T2>>> callbacksProducer)
        {
            var methodCall = MethodCall<TService, T1, T2>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }        

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T1, T2>(Expression<Action<TService>> runMethod,
            Func<IHaveNoCallbacks<IMethodCallback<T1, T2>, T1, T2>, T1, T2, IHaveCallbacks<IMethodCallback<T1, T2>>>
                callbacksProducer)
        {
            var methodCall = MethodCall<TService, T1, T2>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T1, T2, T3>(Expression<Action<TService>> runMethod, Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3>, T1, T2, T3>, IHaveCallbacks<IMethodCallback<T1, T2, T3>>> callbacksProducer)
        {
            var methodCall = MethodCall<TService, T1, T2, T3>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T1, T2, T3>(Expression<Action<TService>> runMethod, Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3>, T1, T2, T3>, T1, T2, T3, IHaveCallbacks<IMethodCallback<T1, T2, T3>>> callbacksProducer)
        {
            var methodCall = MethodCall<TService, T1, T2, T3>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T1, T2, T3, T4>(Expression<Action<TService>> runMethod, Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4>>> callbacksProducer)
        {
            var methodCall = MethodCall<TService, T1, T2, T3, T4>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T1, T2, T3, T4>(Expression<Action<TService>> runMethod, Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>, T1, T2, T3, T4, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4>>> callbacksProducer)
        {
            var methodCall = MethodCall<TService, T1, T2, T3, T4>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T1, T2, T3, T4, T5>(Expression<Action<TService>> runMethod, Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4, T5>>> callbacksProducer)
        {
            var methodCall = MethodCall<TService, T1, T2, T3, T4, T5>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCall<T1, T2, T3, T4, T5>(Expression<Action<TService>> runMethod, Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4, T5>>> callbacksProducer)
        {
            var methodCall = MethodCall<TService, T1, T2, T3, T4, T5>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<TResult>(
            Expression<Func<TService, TResult>> runMethod, 
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<TResult>, TResult>, IHaveCallbacks<IMethodCallbackWithResult<TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<TResult>(Expression<Func<TService, Task<TResult>>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<TResult>, TResult>, IHaveCallbacks<IMethodCallbackWithResult<TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T, TResult>(
            Expression<Func<TService, TResult>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService,T, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }        

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T, TResult>(
            Expression<Func<TService, TResult>> runMethod, 
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>, T, 
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T, TResult>(
            Expression<Func<TService, Task<TResult>>> runMethod,
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T, TResult>(
            Expression<Func<TService, Task<TResult>>> runMethod, 
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>, T, 
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T, TResult>
               .CreateMethodCall(runMethod)
               .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T1, T2, TResult>(Expression<Func<TService, TResult>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T1, T2, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T1, T2, TResult>(Expression<Func<TService, TResult>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, T1, T2, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T1, T2, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T1, T2, TResult>(Expression<Func<TService, Task<TResult>>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T1, T2, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T1, T2, TResult>(Expression<Func<TService, Task<TResult>>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, T1, T2, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T1, T2, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T1, T2, T3, TResult>(Expression<Func<TService, TResult>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T1, T2, T3, TResult>
                .CreateMethodCall(runMethod)
                .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T1, T2, T3, TResult>(Expression<Func<TService, TResult>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, T1, T2, T3, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T1, T2, T3, TResult>
               .CreateMethodCall(runMethod)
               .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T1, T2, T3, TResult>(Expression<Func<TService, Task<TResult>>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T1, T2, T3, TResult>
               .CreateMethodCall(runMethod)
               .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T1, T2, T3, TResult>(Expression<Func<TService, Task<TResult>>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, T1, T2, T3, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T1, T2, T3, TResult>
               .CreateMethodCall(runMethod)
               .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T1, T2, T3, T4, TResult>(Expression<Func<TService, TResult>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T1, T2, T3, T4, TResult>
               .CreateMethodCall(runMethod)
               .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T1, T2, T3, T4, TResult>(Expression<Func<TService, TResult>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>, T1, T2, T3, T4, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T1, T2, T3, T4, TResult>
               .CreateMethodCall(runMethod)
               .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T1, T2, T3, T4, TResult>(
            Expression<Func<TService, Task<TResult>>> runMethod, 
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, 
                T1, T2, T3, T4, TResult>, 
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T1, T2, T3, T4, TResult>
              .CreateMethodCall(runMethod)
              .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T1, T2, T3, T4, TResult>(
            Expression<Func<TService, Task<TResult>>> runMethod, 
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>,
                T1, T2, T3, T4, TResult>, 
                T1, T2, T3, T4, 
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T1, T2, T3, T4, TResult>
              .CreateMethodCall(runMethod)
              .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T1, T2, T3, T4, T5, TResult>(Expression<Func<TService, TResult>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T1, T2, T3, T4, T5, TResult>
               .CreateMethodCall(runMethod)
               .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsEx<TService>.AddMethodCallWithResult<T1, T2, T3, T4, T5, TResult>(Expression<Func<TService, TResult>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResult<TService, T1, T2, T3, T4, T5, TResult>
              .CreateMethodCall(runMethod)
              .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T1, T2, T3, T4, T5, TResult>(Expression<Func<TService, Task<TResult>>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T1, T2, T3, T4, T5, TResult>
              .CreateMethodCall(runMethod)
              .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        IServiceCall<TService> ICanAddMethodsAsync<TService>.AddMethodCallWithResultAsync<T1, T2, T3, T4, T5, TResult>(Expression<Func<TService, Task<TResult>>> runMethod, Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>> callbacksProducer)
        {
            var methodCall = MethodCallWithResultAsync<TService, T1, T2, T3, T4, T5, TResult>
              .CreateMethodCall(runMethod)
              .BuildCallbacks(callbacksProducer);
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        private void AddMethodCallImpl(IMethodCallMetaData methodCallMetaData, IAcceptor<IMethodCallVisitor<TService>> acceptor)
        {
            var existingMethodCallMetaData = FindExistingMethodCallMetaData(methodCallMetaData);
            if (existingMethodCallMetaData == null)
            {
                _methodCalls.Add(methodCallMetaData);
            }
            else
            {
                AssertCallbackType(methodCallMetaData, existingMethodCallMetaData);                
                AcceptExistingMethodCall(
                    acceptor,
                    new MethodCallAppendCallsVisitor<TService>(methodCallMetaData));
            }
        }

        private void AddMethodCallWithResultImpl(IMethodCallMetaData methodCallMetaData, 
            IAcceptor<IMethodCallWithResultVisitor<TService>> acceptor)
        {
            var existingMethodCallMetaData = FindExistingMethodCallMetaData(methodCallMetaData);
            if (existingMethodCallMetaData == null)
            {
                _methodCalls.Add(methodCallMetaData);
            }
            else
            {
                AssertCallbackType(methodCallMetaData, existingMethodCallMetaData);                
                AcceptExistingMethodCall(
                        acceptor,
                        new MethodCallWithResultAppendCallsVisitor<TService>(methodCallMetaData));
            }
        }

        private void AddMethodCallWithResultImpl(IMethodCallMetaData methodCallMetaData,
            IAcceptor<IMethodCallWithResultVisitorAsync<TService>> acceptor)
        {
            var existingMethodCallMetaData = FindExistingMethodCallMetaData(methodCallMetaData);
            if (existingMethodCallMetaData == null)
            {
                _methodCalls.Add(methodCallMetaData);
            }
            else
            {
                AssertCallbackType(methodCallMetaData, existingMethodCallMetaData);
                AcceptExistingMethodCall(
                        acceptor,
                        new MethodCallWithResultAppendCallsVisitorAsync<TService>(methodCallMetaData));
            }
        }

        private static void AcceptExistingMethodCall<TAppendCallsVisitor,TMethodCallVisitor>(
            IAcceptor<TMethodCallVisitor> existingMethodInfoMetaData,
            TAppendCallsVisitor appendCallsVisitor
            ) where TAppendCallsVisitor : TMethodCallVisitor
        {
            existingMethodInfoMetaData.Accept(appendCallsVisitor);
        }

        private static void AssertCallbackType(IMethodCallMetaData newMethodCallMetaData,
            IMethodCallMetaData existingMethodCallMetaData)
        {
            var newCallbackType = newMethodCallMetaData.CallbackType;
            var existingCallbackType = existingMethodCallMetaData.CallbackType;
            if (newCallbackType != existingCallbackType)
            {
                throw new NotSupportedException("Callback type may not be changed");
            }
        }

        private IMethodCallMetaData FindExistingMethodCallMetaData(IMethodCallMetaData methodCallMetaData)
        {
            var newRunMethodDescription = methodCallMetaData.RunMethodDescription;
            var existingMethodInfoMetaData =
                _methodCalls.FirstOrDefault(t => t.RunMethodDescription == newRunMethodDescription);
            return existingMethodInfoMetaData;
        }

        /// <summary>
        /// Sets the service calls and returns the fake object as its proxy.
        /// </summary>
        /// <returns></returns>
        IFake<TService> IServiceCall<TService>.Build()
        {
            return _serviceSetupFactory.SetupFakeService(_fake, 
                MethodCalls.OfType<IMethodCall<TService>>(),
                MethodCalls.OfType<IMethodCallWithResult<TService>>(),
                MethodCalls.OfType<IMethodCallWithResultAsync<TService>>());
        }

        /// <summary>
        /// Appends the method calls.
        /// </summary>
        /// <param name="otherMethods">The other methods.</param>
        void IAppendMethods<TService>.AppendMethods(IHaveMethods<TService> otherMethods)
        {
            foreach (var otherMethod in otherMethods.MethodCalls)
            {
                AddMethodCall(otherMethod);
            }
        }
    }
}