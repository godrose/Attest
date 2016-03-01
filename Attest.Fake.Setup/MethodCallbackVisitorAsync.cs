using System.Threading.Tasks;
using Attest.Fake.Setup.Contracts;
using Solid.Practices.Scheduling;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Represents visitor for different async callbacks without return value and no parameters.
    /// </summary>
    class MethodCallbackVisitorAsync : IMethodCallbackVisitorAsync
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        public Task Visit(OnErrorCallback onErrorCallback)
        {
            return MethodCallbackVisitorHelperAsync.VisitError(onErrorCallback);
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        public Task Visit(OnCompleteCallback onCompleteCallback)
        {
            return TaskRunner.RunAsync(() => onCompleteCallback.Callback());
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        public Task Visit(ProgressCallback progressCallback)
        {
            return MethodCallbackVisitorHelperAsync.VisitProgress(progressCallback, c => c.Accept(this));
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        public Task Visit(OnCancelCallback onCancelCallback)
        {
            return MethodCallbackVisitorHelperAsync.VisitCancel();
        }

        /// <summary>
        /// Visits never-ending callback.
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        public Task Visit(OnWithoutCallback withoutCallback)
        {
            return MethodCallbackVisitorHelperAsync.VisitWithout();
        }
    }

    /// <summary>
    /// Represents visitor for different async callbacks without return value and one parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    public class MethodCallbackVisitorAsync<T> : IMethodCallbackVisitorAsync<T>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        public Task Visit(OnErrorCallback<T> onErrorCallback, T arg)
        {
            return MethodCallbackVisitorHelperAsync.VisitError(onErrorCallback);
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        public Task Visit(OnCompleteCallback<T> onCompleteCallback, T arg)
        {
            return TaskRunner.RunAsync(() => onCompleteCallback.Callback(arg));
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg">Parameter.</param>
        public Task Visit(ProgressCallback<T> progressCallback, T arg)
        {
            return MethodCallbackVisitorHelperAsync.VisitProgress(progressCallback, c => c.Accept(this, arg));
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg">Parameter.</param>
        public Task Visit(OnCancelCallback<T> onCancelCallback, T arg)
        {
            return MethodCallbackVisitorHelperAsync.VisitCancel();
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg">Parameter.</param>
        public Task Visit(OnWithoutCallback<T> withoutCallback, T arg)
        {
            return MethodCallbackVisitorHelperAsync.VisitWithout();
        }
    }
}