using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Represents visitor for different method calls with return value
    /// </summary>
    public interface IMethodCallWithResultVisitorAsync<TService> where TService : class
    {
        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<TResult>(IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<TResult>, TResult> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T, TResult>(IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>       
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T1, T2, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>       
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T1, T2, T3, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T1, T2, T3, T4, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>        
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam> 
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T1, T2, T3, T4, T5, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> methodCall);
    }

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

        public void Visit<T1, T2, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall)
        {
            throw new System.NotImplementedException();
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