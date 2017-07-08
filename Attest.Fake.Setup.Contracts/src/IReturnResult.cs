namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that has return value
    /// </summary>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IReturnResult<out TResult>
    {
        /// <summary>
        /// The return value
        /// </summary>
        TResult Result { get; }
    }
}