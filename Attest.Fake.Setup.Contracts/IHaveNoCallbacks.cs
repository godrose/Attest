namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a callbacks container without callbacks
    /// </summary>
    /// <typeparam name="TCallback"></typeparam>
    public interface IHaveNoCallbacks<TCallback> : IAddCallback<TCallback>
    {

    }
}