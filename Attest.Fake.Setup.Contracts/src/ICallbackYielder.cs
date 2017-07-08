namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Yields the next callback
    /// </summary>
    /// <typeparam name="TCallback"></typeparam>
    public interface ICallbackYielder<out TCallback>
    {
        /// <summary>
        /// Call this method to yield the next callback from the collection of callbacks.
        /// </summary>
        /// <returns>Next callback.</returns>
        TCallback YieldCallback();
    }
}