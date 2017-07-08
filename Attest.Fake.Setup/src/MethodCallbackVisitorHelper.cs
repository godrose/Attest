using System;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Helper class for method callback visitors
    /// </summary>
    internal static class MethodCallbackVisitorHelper
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
}