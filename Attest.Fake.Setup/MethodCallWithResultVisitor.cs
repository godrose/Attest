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
                if (methodCall is IGenerateMethodCallbackWithResult<T>)
                {
                    (methodCall as IGenerateMethodCallbackWithResult<T>).EvaluateArguments(arg);
                }
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, arg);
            });
        }

        public void Visit<T1, T2, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitor<T1, T2, TResult>();

            _fake.Setup(methodCall.RunMethod).Callback((T1 arg1, T2 arg2) =>
            {
                if (methodCall is IGenerateMethodCallbackWithResult<T1, T2>)
                {
                    (methodCall as IGenerateMethodCallbackWithResult<T1, T2>).EvaluateArguments(arg1, arg2);
                }
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, arg1, arg2);
            });
        }

        public void Visit<T1, T2, T3, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitor<T1, T2, T3, TResult>();

            _fake.Setup(methodCall.RunMethod).Callback((T1 arg1, T2 arg2, T3 arg3) =>
            {
                if (methodCall is IGenerateMethodCallbackWithResult<T1, T2, T3>)
                {
                    (methodCall as IGenerateMethodCallbackWithResult<T1, T2, T3>).EvaluateArguments(arg1, arg2, arg3);
                }
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, arg1, arg2, arg3);
            });
        }

        public void Visit<T1, T2, T3, T4, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult>();

            _fake.Setup(methodCall.RunMethod).Callback((T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
            {
                if (methodCall is IGenerateMethodCallbackWithResult<T1, T2, T3, T4>)
                {
                    (methodCall as IGenerateMethodCallbackWithResult<T1, T2, T3, T4>).EvaluateArguments(arg1, arg2, arg3, arg4);
                }
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, arg1, arg2, arg3, arg4);
            });
        }

        public void Visit<T1, T2, T3, T4, T5, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult>();

            _fake.Setup(methodCall.RunMethod).Callback((T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
            {
                if (methodCall is IGenerateMethodCallbackWithResult<T1, T2, T3, T4, T5>)
                {
                    (methodCall as IGenerateMethodCallbackWithResult<T1, T2, T3, T4, T5>).EvaluateArguments(arg1, arg2,
                        arg3, arg4, arg5);
                }
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor, arg1, arg2, arg3, arg4, arg5);
            });
        }
    }

    class MethodCallWithResultAppendCallsVisitor<TService> : IMethodCallWithResultVisitor<TService> where TService : class
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