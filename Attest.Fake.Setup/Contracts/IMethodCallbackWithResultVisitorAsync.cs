using System.Threading.Tasks;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents visitor for different async callbacks with return value and no parameters
    /// </summary>
    public interface IMethodCallbackWithResultVisitorAsync<TResult>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <returns>Return value</returns>
        Task<TResult> Visit(OnErrorCallbackWithResult<TResult> onErrorCallback);

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <returns>Return value</returns>
        Task<TResult> Visit(OnCancelCallbackWithResult<TResult> onCancelCallback);

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">Callback</param>
        /// <returns>Return value</returns>
        Task<TResult> Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult);

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        /// <returns>Return value</returns>
        Task<TResult> Visit(ProgressCallbackWithResult<TResult> progressCallback);

        /// <summary>
        /// Visits never-ending callback 
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <returns>Return value</returns>
        Task<TResult> Visit(OnWithoutCallbackWithResult<TResult> withoutCallback);
    }
}