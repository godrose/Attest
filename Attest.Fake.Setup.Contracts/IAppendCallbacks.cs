namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Provides ability to append collection of callbacks
    /// </summary>
    /// <typeparam name="TCallback"></typeparam>
    public interface IAppendCallbacks<in TCallback>
    {
        void AppendCallbacks(IHaveCallbacks<TCallback> haveCallbacks);
    }
}