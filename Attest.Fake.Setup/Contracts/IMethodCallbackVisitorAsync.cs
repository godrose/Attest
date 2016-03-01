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
}