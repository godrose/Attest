namespace Attest.Fake.Setup.Contracts
{
    public interface IReturnResult<out TResult>
    {
        TResult Result { get; }
    }

    public interface IMethodCallbackWithResult<TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<TResult>, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<TResult>, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T1, T2, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<TResult>, TResult>
    {
    }

    public interface IMethodCallbackWithResultVisitor<TResult>
    {
        TResult Visit(OnErrorCallback<TResult> onErrorCallback);
        TResult Visit<T>(OnErrorCallback<T, TResult> onErrorCallback);
        TResult Visit<T1, T2>(OnErrorCallback<T1, T2, TResult> onErrorCallback);
        TResult Visit(OnCancelCallback<TResult> onCancelCallback);
        TResult Visit<T1, T2>(OnCancelCallback<T1, T2, TResult> onCancelCallback);
        TResult Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult);
        TResult Visit<T>(OnCompleteCallbackWithResult<T, TResult> onCompleteCallbackWithResult);
        TResult Visit<T1, T2>(OnCompleteCallbackWithResult<T1, T2, TResult> onCompleteCallbackWithResult);
        TResult Visit(ProgressCallbackWithResult0<TResult> progressCallback);
        TResult Visit<T1, T2>(ProgressCallbackWithResult2<T1, T2, TResult> progressCallback);
        TResult Visit<T1, T2>(OnWithoutCallback<T1, T2, TResult> withoutCallback);
    }
}