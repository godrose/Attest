namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents visitor for different callbacks with return value and no parameters
    /// </summary>
    public interface IMethodCallbackWithResultVisitor<TResult>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <returns>Return value</returns>
        TResult Visit(OnErrorCallbackWithResult<TResult> onErrorCallback);       

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <returns>Return value</returns>
        TResult Visit(OnCancelCallbackWithResult<TResult> onCancelCallback);        

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">Callback</param>
        /// <returns>Return value</returns>
        TResult Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult); 
      
        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        /// <returns>Return value</returns>
        TResult Visit(ProgressCallbackWithResult<TResult> progressCallback); 

        /// <summary>
        /// Visits never-ending callback 
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <returns>Return value</returns>
        TResult Visit(OnWithoutCallbackWithResult<TResult> withoutCallback);        
    }

    /// <summary>
    /// Represents visitor for different callbacks with return value and one parameter
    /// </summary>
    public interface IMethodCallbackWithResultVisitor<T, TResult>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>Return value</returns>
        TResult Visit(OnErrorCallbackWithResult<T, TResult> onErrorCallback, T arg);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>Return value</returns>
        TResult Visit(OnCancelCallbackWithResult<T, TResult> onCancelCallback, T arg);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>Return value</returns>
        TResult Visit(OnCompleteCallbackWithResult<T, TResult> onCompleteCallbackWithResult, T arg);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>Return value</returns>
        TResult Visit(ProgressCallbackWithResult<T, TResult> progressCallback, T arg);

        /// <summary>
        /// Visits never-ending callback 
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>Return value</returns>
        TResult Visit(OnWithoutCallbackWithResult<T, TResult> withoutCallback, T arg);
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