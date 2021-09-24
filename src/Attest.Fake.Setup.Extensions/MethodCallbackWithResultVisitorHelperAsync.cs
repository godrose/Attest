using System;
using System.Linq;
using System.Threading.Tasks;
using Attest.Fake.Setup.Contracts;
using Solid.Practices.Scheduling;

namespace Attest.Fake.Setup.Extensions
{
    /// <summary>
    /// Helper class for method callback visitors
    /// </summary>
    static class MethodCallbackVisitorHelperAsync
    {
        internal static void VisitError(IThrowException onErrorCallback)
        {
            throw onErrorCallback.Exception;
        }

        internal static void VisitProgress<TCallback>(IProgressableProcessFinished<TCallback> progressCallback,
            Action<TCallback> callbackAcceptor)
        {
            throw new ProgressMessageException(progressCallback.ProgressMessages,
                () =>
                {
                    if (progressCallback.FinishCallback != null)
                    {
                        callbackAcceptor(progressCallback.FinishCallback);
                    }
                });
        }

        internal static void VisitCancel()
        {
            throw new CancelCallbackException();
        }

        internal static void VisitWithout()
        {
            throw new WithoutCallbackException();
        }
    }

    static class MethodCallbackWithResultVisitorHelperAsync
    {
        internal static Task<TResult> VisitErrorWithResult<TResult>(IThrowException onErrorCallback)
        {
            return VisitWithResult<TResult>(() => MethodCallbackVisitorHelperAsync.VisitError(onErrorCallback));
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
            return VisitWithResult<TResult>(MethodCallbackVisitorHelperAsync.VisitCancel);
        }

        internal static Task<TResult> VisitWithoutWithResult<TResult>()
        {
            return VisitWithResult<TResult>(MethodCallbackVisitorHelperAsync.VisitWithout);
        }

        private static Task<TResult> VisitWithResult<TResult>(Action visitMethod)
        {
            visitMethod();
            return TaskRunner.RunAsync(() => default(TResult));
        }
    }
}