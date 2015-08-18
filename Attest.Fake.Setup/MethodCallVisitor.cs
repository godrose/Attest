using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    public class MethodCallVisitor<TService> : IMethodCallVisitor<TService> where TService : class
    {
        private readonly IFake<TService> _stubService;
        private readonly IMethodCallbackVisitor _methodCallbackVisitor = new MethodCallbackVisitor();

        public MethodCallVisitor(IFake<TService> stubService)
        {
            _stubService = stubService;
        }
       
        public void Visit(IMethodCall<TService, IMethodCallback> methodCall)
        {
            CreateSetup(methodCall).Callback(() =>
            {
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(_methodCallbackVisitor);
            });
        }

        public void Visit<T>(IMethodCall<TService, IMethodCallback<T>> methodCall)
        {
            CreateSetup(methodCall).Callback((T arg) =>
            {
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(_methodCallbackVisitor, arg);
            });
        }

        public void Visit<T1, T2>(IMethodCall<TService, IMethodCallback<T1, T2>> methodCall)
        {
            CreateSetup(methodCall).Callback((T1 arg1, T2 arg2) =>
            {
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(_methodCallbackVisitor, arg1, arg2);
            });
        }

        public void Visit<T1, T2, T3>(IMethodCall<TService, IMethodCallback<T1, T2, T3>> methodCall)
        {
            CreateSetup(methodCall).Callback((T1 arg1, T2 arg2, T3 arg3) =>
            {
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(_methodCallbackVisitor, arg1, arg2, arg3);
            });
        }

        public void Visit<T1, T2, T3, T4>(IMethodCall<TService, IMethodCallback<T1, T2, T3, T4>> methodCall)
        {
            CreateSetup(methodCall).Callback((T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
            {
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(_methodCallbackVisitor, arg1, arg2, arg3, arg4);
            });
        }

        public void Visit<T1, T2, T3, T4, T5>(IMethodCall<TService, IMethodCallback<T1, T2, T3, T4, T5>> methodCall)
        {
            CreateSetup(methodCall).Callback((T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
            {
                var methodCallback = methodCall.YieldCallback();
                methodCallback.Accept(_methodCallbackVisitor, arg1, arg2, arg3, arg4, arg5);
            });
        }

        private IFakeCallback CreateSetup(IMethodCall<TService> methodCall)
        {
            return _stubService.Setup(methodCall.RunMethod);
        }
    }

    public class MethodCallAppendCallsVisitor<TService> : IMethodCallVisitor<TService> where TService : class
    {
        private object _newMethodCall;

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