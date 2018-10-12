namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents means of stopping the running application.
    /// </summary>
    public interface IStopApplicationService
    {
        /// <summary>
        /// Stops the running application.
        /// </summary>
        void StopApplication();
    }
}