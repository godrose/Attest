namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Used to append collection of method calls to the existing service call.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    public interface IAppendMethods<TService> where TService : class
    {
        /// <summary>
        /// Appends the method calls.
        /// </summary>
        /// <param name="otherMethods">The other methods.</param>
        void AppendMethods(IHaveMethods<TService> otherMethods);
    }
}