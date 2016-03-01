using System;
using System.Threading.Tasks;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    class MethodCallVisitorAsync<TService> : IMethodCallVisitorAsync<TService> where TService : class
    {
        private readonly IFake<TService> _fake;

        public MethodCallVisitorAsync(IFake<TService> fake)
        {
            _fake = fake;
        }

        public void Visit(IMethodCallAsync<TService, IMethodCallback> methodCall)
        {
            var visitor = new MethodCallbackVisitorAsync();
            CreateSetup(methodCall).Callback(() =>
            {
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(visitor);
            });
        }

        public void Visit<T>(IMethodCallAsync<TService, IMethodCallback<T>> methodCall)
        {
            var visitor = new MethodCallbackVisitorAsync<T>();
            CreateSetup(methodCall).Callback((T arg) =>
            {
                MethodCallVisitorHelper.GenerateCallbacks<IGenerateMethodCallback<T>>(methodCall, r => r.GenerateCallback(arg));
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(visitor, arg);
            });
        }

        public void Visit<T1, T2>(IMethodCallAsync<TService, IMethodCallback<T1, T2>> methodCall)
        {
            throw new NotImplementedException();
        }

        public void Visit<T1, T2, T3>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3>> methodCall)
        {
            throw new NotImplementedException();
        }

        public void Visit<T1, T2, T3, T4>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3, T4>> methodCall)
        {
            throw new NotImplementedException();
        }

        public void Visit<T1, T2, T3, T4, T5>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3, T4, T5>> methodCall)
        {
            throw new NotImplementedException();
        }

        private IFakeCallbackWithResult<Task> CreateSetup(IMethodCallAsync<TService> methodCall)
        {
            return _fake.Setup(methodCall.RunMethod);
        }
    }

    class MethodCallAppendCallsVisitorAsync<TService> : IMethodCallVisitorAsync<TService> where TService : class
    {
        private readonly object _newMethodCall;

        public MethodCallAppendCallsVisitorAsync(object newMethodCall)
        {
            _newMethodCall = newMethodCall;
        }

        public void Visit(IMethodCallAsync<TService, IMethodCallback> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T>(IMethodCallAsync<TService, IMethodCallback<T>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T1, T2>(IMethodCallAsync<TService, IMethodCallback<T1, T2>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T1, T2, T3>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T1, T2, T3, T4>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3, T4>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T1, T2, T3, T4, T5>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3, T4, T5>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }
    }
}