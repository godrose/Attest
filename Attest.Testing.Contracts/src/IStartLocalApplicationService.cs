namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents means of starting up the local application.
    /// </summary>
    public interface IStartLocalApplicationService
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        void StartApplication();
    }
}