namespace Attest.Fake.Setup.Contracts
{
    //public interface IReturnResult<out TResult>
    //{
    //    TResult Result { get; }
    //}

    public interface IMethodCallbackWithResult<TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<TResult>, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T, TResult>, T, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T1, T2, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T1, T2, TResult>, T1, T2, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T1, T2, T3, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T1, T2, T3, TResult>, T1, T2, T3, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T1, T2, T3, T4, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>
    {
    }
}