namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">The type of the method callback.</typeparam>
    public interface IHaveNoCallbacks<TCallback> : IAddCallbackShared<TCallback>
    {

    }
}