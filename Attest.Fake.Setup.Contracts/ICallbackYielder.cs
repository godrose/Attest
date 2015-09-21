namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Yields the next callback
    /// </summary>
    /// <typeparam name="TCallback"></typeparam>
    public interface ICallbackYielder<out TCallback>
    {
        TCallback YieldCallback();
    }
}