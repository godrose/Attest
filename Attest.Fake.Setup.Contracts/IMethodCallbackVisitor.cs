namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents visitor for different callbacks without return value and no parameters
    /// </summary>
    public interface IMethodCallbackVisitor
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        void Visit(OnErrorCallback onErrorCallback);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        void Visit(OnCompleteCallback onCompleteCallback);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressableCallback">Callback</param>
        void Visit(ProgressableCallback progressableCallback);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        void Visit(OnCancelCallback onCancelCallback);
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and one parameter
    /// </summary>
    public interface IMethodCallbackVisitor<T>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        void Visit(OnErrorCallback<T> onErrorCallback, T arg);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        void Visit(OnCompleteCallback<T> onCompleteCallback, T arg);
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and two parameters
    /// </summary>
    public interface IMethodCallbackVisitor<T1, T2>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        void Visit(OnErrorCallback<T1, T2> onErrorCallback, T1 arg1, T2 arg2);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        void Visit(OnCompleteCallback<T1, T2> onCompleteCallback, T1 arg1, T2 arg2);
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and three parameters
    /// </summary>
    public interface IMethodCallbackVisitor<T1, T2, T3>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        void Visit(OnErrorCallback<T1, T2, T3> onErrorCallback, T1 arg1, T2 arg2, T3 arg3);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        void Visit(OnCompleteCallback<T1, T2, T3> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3);
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and four parameters
    /// </summary>
    public interface IMethodCallbackVisitor<T1, T2, T3, T4>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        void Visit(OnErrorCallback<T1, T2, T3, T4> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        void Visit(OnCompleteCallback<T1, T2, T3, T4> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and five parameters
    /// </summary>
    public interface IMethodCallbackVisitor<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        void Visit(OnErrorCallback<T1, T2, T3, T4, T5> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        void Visit(OnCompleteCallback<T1, T2, T3, T4, T5> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
}