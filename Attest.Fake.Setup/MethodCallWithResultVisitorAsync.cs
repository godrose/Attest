﻿using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    class MethodCallWithResultVisitorAsync<TService> : IMethodCallWithResultVisitorAsync<TService> where TService : class
    {
        private readonly IFake<TService> _fake;

        public MethodCallWithResultVisitorAsync(IFake<TService> fake)
        {
            _fake = fake;
        }

        public void Visit<TResult>(IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitorAsync<TResult>();

            _fake.Setup(methodCall.RunMethod).Callback(() =>
            {
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor);
            });
        }

        public void Visit<T, TResult>(IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitorAsync<T, TResult>();

            _fake.Setup(methodCall.RunMethod).Callback((T arg) =>
            {
                MethodCallVisitorHelper.GenerateCallbacks<IGenerateMethodCallbackWithResult<T>>(methodCall, r => r.GenerateCallback(arg));
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, arg);
            });
        }

        public void Visit<T1, T2, TResult>(IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitorAsync<T1, T2, TResult>();

            _fake.Setup(methodCall.RunMethod).Callback((T1 arg1, T2 arg2) =>
            {
                MethodCallVisitorHelper.GenerateCallbacks<IGenerateMethodCallbackWithResult<T1, T2>>(methodCall,
                    r => r.GenerateCallback(arg1, arg2));
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, arg1, arg2);
            });
        }

        public void Visit<T1, T2, T3, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> methodCall)
        {
            throw new System.NotImplementedException();
        }

        public void Visit<T1, T2, T3, T4, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> methodCall)
        {
            throw new System.NotImplementedException();
        }

        public void Visit<T1, T2, T3, T4, T5, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> methodCall)
        {
            throw new System.NotImplementedException();
        }
    }

    class MethodCallWithResultAppendCallsVisitorAsync<TService> : IMethodCallWithResultVisitorAsync<TService> where TService : class
    {
        private readonly object _newMethodCall;

        public MethodCallWithResultAppendCallsVisitorAsync(object newMethodCall)
        {
            _newMethodCall = newMethodCall;
        }

        public void Visit<TResult>(IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<TResult>, TResult> methodCall)
        {
            VisitImpl(methodCall);
        }

        public void Visit<T, TResult>(IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall)
        {
            VisitImpl(methodCall);
        }

        public void Visit<T1, T2, TResult>(IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall)
        {
            VisitImpl(methodCall);
        }

        public void Visit<T1, T2, T3, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> methodCall)
        {
            VisitImpl(methodCall);
        }

        public void Visit<T1, T2, T3, T4, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> methodCall)
        {
            VisitImpl(methodCall);
        }

        public void Visit<T1, T2, T3, T4, T5, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> methodCall)
        {
            VisitImpl(methodCall);
        }

        private void VisitImpl<TCallback>(IAppendCallbacks<TCallback> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }
    }
}