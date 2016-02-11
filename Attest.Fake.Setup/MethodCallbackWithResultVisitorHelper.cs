using System;
using System.Linq;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    static class MethodCallbackWithResultVisitorHelper
    {
        internal static TResult VisitErrorWithResult<TResult>(IThrowException onErrorCallback)
        {
            return VisitWithResult<TResult>(() => MethodCallbackVisitorHelper.VisitError(onErrorCallback));
        }

        internal static TResult VisitProgressWithResult<TCallback, TResult>(
            IProgressableProcessFinishedWithResult<TCallback, TResult> progressCallback, Func<TCallback, TResult> acceptor)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return acceptor(progressCallback.FinishCallback);
        }

        internal static TResult VisitCancelWithResult<TResult>()
        {
            return VisitWithResult<TResult>(MethodCallbackVisitorHelper.VisitCancel);
        }

        internal static TResult VisitWithoutWithResult<TResult>()
        {
            return VisitWithResult<TResult>(MethodCallbackVisitorHelper.VisitWithout);
        }

        private static TResult VisitWithResult<TResult>(Action visitMethod)
        {
            visitMethod();
            return default(TResult);
        }
    }
}