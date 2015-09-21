using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    class MethodCallWithResultVisitor<TService> : IMethodCallWithResultVisitor<TService> where TService : class
    {
        private readonly IFake<TService> _fake;

        public MethodCallWithResultVisitor(IFake<TService> fake)
        {
            _fake = fake;
        }

        public void Visit<TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitor<TResult>();

            _fake.Setup(methodCall.RunMethod).Callback(() =>
            {
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor);
            });
        }        

        public void Visit<T, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitor<T, TResult>();

            _fake.Setup(methodCall.RunMethod).Callback((T arg) =>
            {
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, arg);
            });
        }

        public void Visit<T1, T2, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall)
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

        private void VisitImpl<TCallback, TResult>(IMethodCallWithResult<TService, TCallback, TResult> methodCall) where TCallback : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<TResult>, TResult>
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitor<TResult>();

            _fake.Setup(methodCall.RunMethod).Callback(() =>
            {
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, TODO);
            });
        }
    }

    public class MethodCallWithResultAppendCallsVisitor<TService> : IMethodCallWithResultVisitor<TService> where TService : class
    {
        private readonly object _newMethodCall;

        public MethodCallWithResultAppendCallsVisitor(object newMethodCall)
        {
            _newMethodCall = newMethodCall;
        }

        public void Visit<TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<TResult>, TResult> methodCall)
        {
            VisitImpl(methodCall);
        }

        public void Visit<T, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall)
        {
            VisitImpl(methodCall);
        }        

        public void Visit<T1, T2, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall)
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