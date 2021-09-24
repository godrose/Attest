using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    class MethodCallVisitor<TService> : IMethodCallVisitor<TService> where TService : class
    {
        private readonly IFake<TService> _fake;

        public MethodCallVisitor(IFake<TService> fake)
        {
            _fake = fake;
        }
       
        public void Visit(IMethodCall<TService, IMethodCallback> methodCall)
        {
            var visitor = new MethodCallbackVisitor();
            CreateSetup(methodCall).Callback(() =>
            {
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(visitor);
            });
        }

        public void Visit<T>(IMethodCall<TService, IMethodCallback<T>> methodCall)
        {
            var visitor = new MethodCallbackVisitor<T>();
            CreateSetup(methodCall).Callback((T arg) =>
            {
                MethodCallVisitorHelper.GenerateCallbacks<IGenerateMethodCallback<T>>(methodCall, r => r.GenerateCallback(arg));
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(visitor, arg);
            });
        }        

        public void Visit<T1, T2>(IMethodCall<TService, IMethodCallback<T1, T2>> methodCall)
        {
            var visitor = new MethodCallbackVisitor<T1, T2>();
            CreateSetup(methodCall).Callback((T1 arg1, T2 arg2) =>
            {
                MethodCallVisitorHelper.GenerateCallbacks<IGenerateMethodCallback<T1, T2>>(methodCall, r => r.GenerateCallback(arg1, arg2));
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(visitor, arg1, arg2);
            });
        }

        public void Visit<T1, T2, T3>(IMethodCall<TService, IMethodCallback<T1, T2, T3>> methodCall)
        {
            var visitor = new MethodCallbackVisitor<T1, T2, T3>();
            CreateSetup(methodCall).Callback((T1 arg1, T2 arg2, T3 arg3) =>
            {
                MethodCallVisitorHelper.GenerateCallbacks<IGenerateMethodCallback<T1, T2, T3>>(methodCall, r => r.GenerateCallback(arg1, arg2, arg3));
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(visitor, arg1, arg2, arg3);
            });
        }

        public void Visit<T1, T2, T3, T4>(IMethodCall<TService, IMethodCallback<T1, T2, T3, T4>> methodCall)
        {
            var visitor = new MethodCallbackVisitor<T1, T2, T3, T4>();
            CreateSetup(methodCall).Callback((T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
            {
                MethodCallVisitorHelper.GenerateCallbacks<IGenerateMethodCallback<T1, T2, T3, T4>>(methodCall, r => r.GenerateCallback(arg1, arg2, arg3, arg4));
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(visitor, arg1, arg2, arg3, arg4);
            });
        }

        public void Visit<T1, T2, T3, T4, T5>(IMethodCall<TService, IMethodCallback<T1, T2, T3, T4, T5>> methodCall)
        {
            var visitor = new MethodCallbackVisitor<T1, T2, T3, T4, T5>();
            CreateSetup(methodCall).Callback((T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
            {
                MethodCallVisitorHelper.GenerateCallbacks<IGenerateMethodCallback<T1, T2, T3, T4, T5>>(methodCall, r => r.GenerateCallback(arg1, arg2, arg3, arg4, arg5));
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(visitor, arg1, arg2, arg3, arg4, arg5);
            });
        }

        private IFakeCallback CreateSetup(IMethodCall<TService> methodCall)
        {
            return _fake.Setup(methodCall.RunMethod);
        }
    }

    class MethodCallAppendCallsVisitor<TService> : IMethodCallVisitor<TService> where TService : class
    {
        private readonly object _newMethodCall;

        public MethodCallAppendCallsVisitor(object newMethodCall)
        {
            _newMethodCall = newMethodCall;
        }

        public void Visit(IMethodCall<TService, IMethodCallback> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }        

        public void Visit<T>(IMethodCall<TService, IMethodCallback<T>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T1, T2>(IMethodCall<TService, IMethodCallback<T1, T2>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T1, T2, T3>(IMethodCall<TService, IMethodCallback<T1, T2, T3>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T1, T2, T3, T4>(IMethodCall<TService, IMethodCallback<T1, T2, T3, T4>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }

        public void Visit<T1, T2, T3, T4, T5>(IMethodCall<TService, IMethodCallback<T1, T2, T3, T4, T5>> methodCall)
        {
            AppendCallsVisitorHelper.VisitMethodCall(methodCall, _newMethodCall);
        }
    }    
}