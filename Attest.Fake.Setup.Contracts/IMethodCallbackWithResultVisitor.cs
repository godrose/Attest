namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallbackWithResultVisitor<TResult>
    {
        TResult Visit(OnErrorCallbackWithResult<TResult> onErrorCallback);       
        TResult Visit(OnCancelCallbackWithResult<TResult> onCancelCallback);        
        TResult Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult);       
        TResult Visit(ProgressCallbackWithResult<TResult> progressCallback);        
        TResult Visit(OnWithoutCallbackWithResult<TResult> withoutCallback);        
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

    public interface IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult>
    {
        TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        TResult Visit(ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, T4, T5, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
}