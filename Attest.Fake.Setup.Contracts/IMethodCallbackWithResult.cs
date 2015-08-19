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

    public interface IMethodCallbackWithResult<T1, T2, T3, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<TResult>, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T1, T2, T3, T4, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<TResult>, TResult>
    {
    }

    public interface IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<TResult>, TResult>
    {
    }

    public interface IMethodCallbackWithResultVisitor<TResult>
    {
        TResult Visit(OnErrorCallbackWithResult<TResult> onErrorCallback);
        TResult Visit<T>(OnErrorCallbackWithResult<T, TResult> onErrorCallback);
        TResult Visit<T1, T2>(OnErrorCallbackWithResult<T1, T2, TResult> onErrorCallback);
        TResult Visit<T1, T2, T3>(OnErrorCallbackWithResult<T1, T2, T3, TResult> onErrorCallback);
        TResult Visit<T1, T2, T3, T4>(OnErrorCallbackWithResult<T1, T2, T3, T4, TResult> onErrorCallback);
        TResult Visit<T1, T2, T3, T4, T5>(OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult> onErrorCallback);
        TResult Visit(OnCancelCallbackWithResult<TResult> onCancelCallback);
        TResult Visit<T>(OnCancelCallbackWithResult<T, TResult> onCancelCallback);
        TResult Visit<T1, T2>(OnCancelCallbackWithResult<T1, T2, TResult> onCancelCallback);
        TResult Visit<T1, T2, T3>(OnCancelCallbackWithResult<T1, T2, T3, TResult> onCancelCallback);
        TResult Visit<T1, T2, T3, T4>(OnCancelCallbackWithResult<T1, T2, T3,T4, TResult> onCancelCallback);
        TResult Visit<T1, T2, T3, T4, T5>(OnCancelCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCancelCallback);
        TResult Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult);
        TResult Visit<T>(OnCompleteCallbackWithResult<T, TResult> onCompleteCallbackWithResult);
        TResult Visit<T1, T2>(OnCompleteCallbackWithResult<T1, T2, TResult> onCompleteCallbackWithResult);
        TResult Visit<T1, T2, T3>(OnCompleteCallbackWithResult<T1, T2, T3, TResult> onCompleteCallbackWithResult);
        TResult Visit<T1, T2, T3, T4>(OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult> onCompleteCallbackWithResult);
        TResult Visit<T1, T2, T3, T4, T5>(OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCompleteCallbackWithResult);
        TResult Visit(ProgressCallbackWithResult<TResult> progressCallback);
        TResult Visit<T>(ProgressCallbackWithResult<T, TResult> progressCallback);
        TResult Visit<T1, T2>(ProgressCallbackWithResult<T1, T2, TResult> progressCallback);
        TResult Visit<T1, T2, T3>(ProgressCallbackWithResult<T1, T2, T3, TResult> progressCallback);
        TResult Visit<T1, T2, T3, T4>(ProgressCallbackWithResult<T1, T2, T3, T4,TResult> progressCallback);
        TResult Visit<T1, T2, T3, T4, T5>(ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult> progressCallback);
        TResult Visit(OnWithoutCallbackWithResult<TResult> withoutCallback);
        TResult Visit<T>(OnWithoutCallbackWithResult<T, TResult> withoutCallback);
        TResult Visit<T1, T2>(OnWithoutCallbackWithResult<T1, T2, TResult> withoutCallback);
        TResult Visit<T1, T2, T3>(OnWithoutCallbackWithResult<T1, T2, T3, TResult> withoutCallback);
        TResult Visit<T1, T2, T3, T4>(OnWithoutCallbackWithResult<T1, T2, T3, T4, TResult> withoutCallback);
        TResult Visit<T1, T2, T3, T4, T5>(OnWithoutCallbackWithResult<T1, T2, T3, T4, T5, TResult> withoutCallback);
    }
}