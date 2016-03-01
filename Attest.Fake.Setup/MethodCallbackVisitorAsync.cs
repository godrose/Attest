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
}