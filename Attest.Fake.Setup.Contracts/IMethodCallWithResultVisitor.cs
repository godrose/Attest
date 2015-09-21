namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallWithResultVisitor<TService> where TService : class
    {
        void Visit<TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<TResult>, TResult> methodCall);
        void Visit<T, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T, TResult>, TResult> methodCall);
        void Visit<T1, T2, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> methodCall);
        void Visit<T1, T2, T3, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> methodCall);
        void Visit<T1, T2, T3, T4, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> methodCall);
        void Visit<T1, T2, T3, T4, T5, TResult>(IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> methodCall);
    }
}