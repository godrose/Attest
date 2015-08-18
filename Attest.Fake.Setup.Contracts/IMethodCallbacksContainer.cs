namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallbacksContainer<TCallback> : IHaveCallbacks<TCallback>, IAppendCallbacks<TCallback>, ICallbackYielder<TCallback>, IMethodCallMetaData
    {
    }
}