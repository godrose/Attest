namespace Attest.Testing.Contracts
{
    /// <summary>
    /// This service encapsulates functionality which is called when the test/scenario completes.
    /// </summary>
    public interface ITeardownService
    {
        /// <summary>
        /// Tears this instance down.
        /// </summary>
        void Teardown();
    }
}