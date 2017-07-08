using System;
using System.Threading.Tasks;
using Attest.Fake.Setup.Contracts;
using Solid.Practices.Scheduling;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Helper class for method callback visitors
    /// </summary>
    static class MethodCallbackVisitorHelperAsync
    {
        internal static Task VisitComplete(Action completeCallback)
        {
            return VisitInternal(completeCallback);
        }

        internal static Task VisitError(IThrowException onErrorCallback)
        {
            return VisitInternal(() =>
            {
                MethodCallbackVisitorHelper.VisitError(onErrorCallback);
            });
        }

        internal static Task VisitProgress<TCallback>(IProgressableProcessFinished<TCallback> progressCallback,
            Action<TCallback> callbackAcceptor)
        {
            return VisitInternal(() =>
            {
                MethodCallbackVisitorHelper.VisitProgress(progressCallback, callbackAcceptor);
            });            
        }

        internal static Task VisitCancel()
        {
            return VisitInternal(MethodCallbackVisitorHelper.VisitCancel);
        }

        internal static Task VisitWithout()
        {
            return VisitInternal(MethodCallbackVisitorHelper.VisitWithout);
        }

        private static Task VisitInternal(Action visitMethod)
        {            
            return TaskRunner.RunAsync(visitMethod);
        }
    }
}