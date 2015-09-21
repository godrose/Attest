namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallbackWithResultVisitor<TResult>
    {
        TResult Visit(OnErrorCallbackWithResult<TResult> onErrorCallback);
        TResult Visit<T>(OnErrorCallbackWithResult<T, TResult> onErrorCallback, T arg);
        TResult Visit<T1, T2>(OnErrorCallbackWithResult<T1, T2, TResult> onErrorCallback);
        TResult Visit<T1, T2, T3>(OnErrorCallbackWithResult<T1, T2, T3, TResult> onErrorCallback);
        TResult Visit<T1, T2, T3, T4>(OnErrorCallbackWithResult<T1, T2, T3, T4, TResult> onErrorCallback);
        TResult Visit<T1, T2, T3, T4, T5>(OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult> onErrorCallback);
        TResult Visit(OnCancelCallbackWithResult<TResult> onCancelCallback);
        TResult Visit<T>(OnCancelCallbackWithResult<T, TResult> onCancelCallback, T arg);
        TResult Visit<T1, T2>(OnCancelCallbackWithResult<T1, T2, TResult> onCancelCallback);
        TResult Visit<T1, T2, T3>(OnCancelCallbackWithResult<T1, T2, T3, TResult> onCancelCallback);
        TResult Visit<T1, T2, T3, T4>(OnCancelCallbackWithResult<T1, T2, T3,T4, TResult> onCancelCallback);
        TResult Visit<T1, T2, T3, T4, T5>(OnCancelCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCancelCallback);
        TResult Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult);
        TResult Visit<T>(OnCompleteCallbackWithResult<T, TResult> onCompleteCallbackWithResult, T arg);
        TResult Visit<T1, T2>(OnCompleteCallbackWithResult<T1, T2, TResult> onCompleteCallbackWithResult);
        TResult Visit<T1, T2, T3>(OnCompleteCallbackWithResult<T1, T2, T3, TResult> onCompleteCallbackWithResult);
        TResult Visit<T1, T2, T3, T4>(OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult> onCompleteCallbackWithResult);
        TResult Visit<T1, T2, T3, T4, T5>(OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCompleteCallbackWithResult);
        TResult Visit(ProgressCallbackWithResult<TResult> progressCallback);
        TResult Visit<T>(ProgressCallbackWithResult<T, TResult> progressCallback, T arg);
        TResult Visit<T1, T2>(ProgressCallbackWithResult<T1, T2, TResult> progressCallback);
        TResult Visit<T1, T2, T3>(ProgressCallbackWithResult<T1, T2, T3, TResult> progressCallback);
        TResult Visit<T1, T2, T3, T4>(ProgressCallbackWithResult<T1, T2, T3, T4,TResult> progressCallback);
        TResult Visit<T1, T2, T3, T4, T5>(ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult> progressCallback);
        TResult Visit(OnWithoutCallbackWithResult<TResult> withoutCallback);
        TResult Visit<T>(OnWithoutCallbackWithResult<T, TResult> withoutCallback, T arg);
        TResult Visit<T1, T2>(OnWithoutCallbackWithResult<T1, T2, TResult> withoutCallback);
        TResult Visit<T1, T2, T3>(OnWithoutCallbackWithResult<T1, T2, T3, TResult> withoutCallback);
        TResult Visit<T1, T2, T3, T4>(OnWithoutCallbackWithResult<T1, T2, T3, T4, TResult> withoutCallback);
        TResult Visit<T1, T2, T3, T4, T5>(OnWithoutCallbackWithResult<T1, T2, T3, T4, T5, TResult> withoutCallback);
    }

    public interface IMethodCallbackWithResultVisitor<T, TResult>
    {
        TResult Visit(OnErrorCallbackWithResult<T, TResult> onErrorCallback, T arg);

        TResult Visit(OnCancelCallbackWithResult<T, TResult> onCancelCallback, T arg);

        TResult Visit(OnCompleteCallbackWithResult<T, TResult> onCompleteCallbackWithResult, T arg);

        TResult Visit(ProgressCallbackWithResult<T, TResult> progressCallback, T arg);

        TResult Visit(OnWithoutCallbackWithResult<T, TResult> onWithoutCallback, T arg);
    }

    public interface IMethodCallbackWithResultVisitor<T1, T2, TResult>
    {
        TResult Visit(OnErrorCallbackWithResult<T1, T2, TResult> onErrorCallback, T1 arg1, T2 arg2);

        TResult Visit(OnCancelCallbackWithResult<T1, T2, TResult> onCancelCallback, T1 arg1, T2 arg2);

        TResult Visit(OnCompleteCallbackWithResult<T1, T2, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2);

        TResult Visit(ProgressCallbackWithResult<T1, T2, TResult> progressCallback, T1 arg1, T2 arg2);

        TResult Visit(OnWithoutCallbackWithResult<T1, T2, TResult> onWithoutCallback, T1 arg1, T2 arg2);
    }

    public interface IMethodCallbackWithResultVisitor<T1, T2, T3, TResult>
    {
        TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3);

        TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3);

        TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3);

        TResult Visit(ProgressCallbackWithResult<T1, T2, T3, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3);

        TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3);
    }

    public interface IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult>
    {
        TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, T4, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, T4, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        TResult Visit(ProgressCallbackWithResult<T1, T2, T3, T4, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, T4, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }
}