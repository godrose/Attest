namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents application under test.
    /// </summary>
    public interface IApplicationFacade
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="startupPath">The startup path.</param>
        void Start(string startupPath);

        /// <summary>
        /// Stops the application.
        /// </summary>
        void Stop();
    }
}