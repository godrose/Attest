namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents means of starting up the application from its path.
    /// </summary>
    public interface IStartApplicationService
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="startupPath">The startup path. In the integration tests case, it may be left empty.</param>
        void StartApplication(string startupPath);
    }
}