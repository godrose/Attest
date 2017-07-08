using System;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    static class MethodCallVisitorHelper
    {
        internal static void GenerateCallbacks<TCallbackGenerator>(
            object methodCall, 
            Action<TCallbackGenerator> generateCallbacks)
            where TCallbackGenerator : class, IGenerateMethodCallbackConditionChecker
        {
            var callbackGenerator = methodCall as TCallbackGenerator;
            if (callbackGenerator != null)
            {
                if (callbackGenerator.CanGenerateCallback)
                {
                    generateCallbacks(callbackGenerator);
                }
            }
        }
    }
}