namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that allows to manage and retrieve callbacks for the given callback type.
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    public interface IMethodCallbacksContainer<TCallback> : 
        IHaveCallbacks<TCallback>, 
        IAppendCallbacks<TCallback>, 
        ICallbackYielder<TCallback>, 
        IMethodCallMetaData
    {
    }
}