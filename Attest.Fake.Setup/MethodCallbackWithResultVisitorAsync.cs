using System.Threading.Tasks;
using Attest.Fake.Setup.Contracts;
using Solid.Practices.Scheduling;

namespace Attest.Fake.Setup.Extensions
{   
    /// <summary>
    /// Represents visitor for different callbacks with return value and no parameters
    /// </summary>
    class MethodCallbackWithResultVisitorAsync<TResult> : IMethodCallbackWithResultVisitorAsync<TResult>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        public Task<TResult> Visit(OnErrorCallbackWithResult<TResult> onErrorCallback)
        {
            return MethodCallbackWithResultVisitorHelperAsync.VisitErrorWithResult<TResult>(onErrorCallback);
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="CancelCallbackException"></exception>
        public Task<TResult> Visit(OnCancelCallbackWithResult<TResult> onCancelCallback)
        {
            return MethodCallbackWithResultVisitorHelperAsync.VisitCancelWithResult<TResult>();
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        public Task<TResult> Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult)
        {
            return TaskRunner.RunAsync(() => onCompleteCallbackWithResult.ValueFunction());
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="System.NotSupportedException">Value-returning calls with progress messages are not supported</exception>
        public Task<TResult> Visit(ProgressCallbackWithResult<TResult> progressCallback)
        {
            return MethodCallbackWithResultVisitorHelperAsync.VisitProgressWithResult(progressCallback, c => c.Accept(this));
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="WithoutCallbackException"></exception>
        public Task<TResult> Visit(OnWithoutCallbackWithResult<TResult> withoutCallback)
        {
            return MethodCallbackWithResultVisitorHelperAsync.VisitWithoutWithResult<TResult>();
        }
    }
}
