using System.Threading.Tasks;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup.Extensions
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
        void Visit<TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<TResult>, Task<TResult>> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall);

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

        public void Visit<TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<TResult>, Task<TResult>> methodCall)
        {
            var methodCallbackWithResultVisitor = new MethodCallbackWithResultVisitorAsync<TResult>();

            _fake.Setup(methodCall.RunMethod).Callback(() =>
            {
                var methodCallback = methodCall.YieldCallback();
                return methodCallback.Accept(methodCallbackWithResultVisitor);
            });
        }

        public void Visit<T, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall)
        {
            throw new System.NotImplementedException();
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
}