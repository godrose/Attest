using System;
using System.Linq;
using System.Threading.Tasks;
using Attest.Fake.Setup.Contracts;
using Solid.Practices.Scheduling;

namespace Attest.Fake.Setup
{
    static class MethodCallbackWithResultVisitorHelperAsync
    {
        internal static Task<TResult> VisitErrorWithResult<TResult>(IThrowException onErrorCallback)
        {
            return VisitWithResult<TResult>(() => MethodCallbackVisitorHelper.VisitError(onErrorCallback));
        }

        internal static Task<TResult> VisitProgressWithResult<TCallback, TResult>(
            IProgressableProcessFinishedWithResult<TCallback, TResult> progressCallback, Func<TCallback, Task<TResult>> acceptor)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return acceptor(progressCallback.FinishCallback);
        }

        internal static Task<TResult> VisitCancelWithResult<TResult>()
        {
            return VisitWithResult<TResult>(MethodCallbackVisitorHelper.VisitCancel);
        }

        internal static Task<TResult> VisitWithoutWithResult<TResult>()
        {
            return VisitWithResult<TResult>(MethodCallbackVisitorHelper.VisitWithout);
        }

        private static Task<TResult> VisitWithResult<TResult>(Action visitMethod)
        {
            visitMethod();
            return TaskRunner.RunAsync(() => default(TResult));
        }
    }
}