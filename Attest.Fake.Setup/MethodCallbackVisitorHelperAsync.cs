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
        internal static Task VisitError(IThrowException onErrorCallback)
        {
            return Visit(() =>
            {
                MethodCallbackVisitorHelper.VisitError(onErrorCallback);
            });
        }

        internal static Task VisitProgress<TCallback>(IProgressableProcessFinished<TCallback> progressCallback,
            Action<TCallback> callbackAcceptor)
        {
            return Visit(() =>
            {
                MethodCallbackVisitorHelper.VisitProgress(progressCallback, callbackAcceptor);
            });            
        }

        internal static Task VisitCancel()
        {
            return Visit(MethodCallbackVisitorHelper.VisitCancel);
        }

        internal static Task VisitWithout()
        {
            return Visit(MethodCallbackVisitorHelper.VisitWithout);
        }

        private static Task Visit(Action visitMethod)
        {
            visitMethod();
            return TaskRunner.RunAsync(() => { });
        }
    }
}