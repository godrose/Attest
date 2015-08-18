using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    internal static class AppendCallsVisitorHelper
    {
        internal static void VisitMethodCall<TCallback>(IAppendCallbacks<TCallback> existingMethodCall, object newMethodCall)
        {
            //if we got here that means we've already checked two things:
            //first - the run methods are the same
            //second - the callback types are compatible
            //the casting part is inner knowledge that doesn't get exposed for now            
            var newCallbacks = (IHaveCallbacks<TCallback>)newMethodCall;
            existingMethodCall.AppendCallbacks(newCallbacks);           
        }        
    }
}