namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Provides ability to append collection of callbacks
    /// </summary>
    /// <typeparam name="TCallback"></typeparam>
    public interface IAppendCallbacks<in TCallback>
    {
        /// <summary>
        /// Appends the callbacks.
        /// </summary>
        /// <param name="haveCallbacks">An object that has callbacks.</param>
        void AppendCallbacks(IHaveCallbacks<TCallback> haveCallbacks);
    }
}