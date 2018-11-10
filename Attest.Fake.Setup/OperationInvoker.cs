using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    class OperationInvoker
    {
    }

    internal static class OperationStarter
    {
        internal static void StartOperation(IOperation operation)
        {
            operation.Start();
        }
    }
}
