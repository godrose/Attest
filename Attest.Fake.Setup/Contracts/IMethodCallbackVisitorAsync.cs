using System.Threading.Tasks;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents visitor for different async callbacks without return value and no parameters.
    /// </summary>
    public interface IMethodCallbackVisitorAsync
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        Task Visit(OnErrorCallback onErrorCallback);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        Task Visit(OnCompleteCallback onCompleteCallback);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        Task Visit(ProgressCallback progressCallback);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        Task Visit(OnCancelCallback onCancelCallback);

        /// <summary>
        /// Visits never-ending callback.
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        Task Visit(OnWithoutCallback withoutCallback);
    }

    /// <summary>
    /// Represents visitor for different async callbacks without return value and one parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    public interface IMethodCallbackVisitorAsync<T>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        Task Visit(OnErrorCallback<T> onErrorCallback, T arg);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        Task Visit(OnCompleteCallback<T> onCompleteCallback, T arg);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg">Parameter.</param>
        Task Visit(ProgressCallback<T> progressCallback, T arg);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg">Parameter.</param>
        Task Visit(OnCancelCallback<T> onCancelCallback, T arg);

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg">Parameter.</param>
        Task Visit(OnWithoutCallback<T> withoutCallback, T arg);
    }

    /// <summary>
    /// Represents visitor for different async callbacks without return value and two parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    public interface IMethodCallbackVisitorAsync<T1, T2>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        Task Visit(OnErrorCallback<T1, T2> onErrorCallback, T1 arg1, T2 arg2);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        Task Visit(OnCompleteCallback<T1, T2> onCompleteCallback, T1 arg1, T2 arg2);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        Task Visit(ProgressCallback<T1, T2> progressCallback, T1 arg1, T2 arg2);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        Task Visit(OnCancelCallback<T1, T2> onCancelCallback, T1 arg1, T2 arg2);

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        Task Visit(OnWithoutCallback<T1, T2> withoutCallback, T1 arg1, T2 arg2);
    }

    /// <summary>
    /// Represents visitor for different async callbacks without return value and three parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    public interface IMethodCallbackVisitorAsync<T1, T2, T3>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        Task Visit(OnErrorCallback<T1, T2, T3> onErrorCallback, T1 arg1, T2 arg2, T3 arg3);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        Task Visit(OnCompleteCallback<T1, T2, T3> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        Task Visit(ProgressCallback<T1, T2, T3> progressCallback, T1 arg1, T2 arg2, T3 arg3);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        Task Visit(OnCancelCallback<T1, T2, T3> onCancelCallback, T1 arg1, T2 arg2, T3 arg3);

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        Task Visit(OnWithoutCallback<T1, T2, T3> withoutCallback, T1 arg1, T2 arg2, T3 arg3);
    }

    /// <summary>
    /// Represents visitor for different async callbacks without return value and four parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    public interface IMethodCallbackVisitorAsync<T1, T2, T3, T4>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        Task Visit(OnErrorCallback<T1, T2, T3, T4> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        Task Visit(OnCompleteCallback<T1, T2, T3, T4> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        Task Visit(ProgressCallback<T1, T2, T3, T4> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        Task Visit(OnCancelCallback<T1, T2, T3, T4> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        Task Visit(OnWithoutCallback<T1, T2, T3, T4> withoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    /// <summary>
    /// Represents visitor for different async callbacks without return value and five parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    public interface IMethodCallbackVisitorAsync<T1, T2, T3, T4, T5>
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
        Task Visit(OnErrorCallback<T1, T2, T3, T4, T5> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        Task Visit(OnCompleteCallback<T1, T2, T3, T4, T5> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        Task Visit(ProgressCallback<T1, T2, T3, T4, T5> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        Task Visit(OnCancelCallback<T1, T2, T3, T4, T5> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        Task Visit(OnWithoutCallback<T1, T2, T3, T4, T5> withoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
}