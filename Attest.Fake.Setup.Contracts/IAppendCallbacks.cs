namespace Attest.Fake.Setup.Contracts
{
    public interface IAppendCallbacks<in TCallback>
    {
        void AppendCallbacks(IHaveCallbacks<TCallback> haveCallbacks);
    }
}