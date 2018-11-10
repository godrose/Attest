namespace Attest.Testing.Contracts
{
    /// <summary>
    /// This interface represents a local application that
    /// can be uniquely identified and executed
    /// </summary>
    public interface IApplicationModule
    {
        /// <summary>
        /// Application id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Application's relative path.
        /// </summary>
        string RelativePath { get; }       
    }
}