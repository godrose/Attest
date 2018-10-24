namespace Attest.Testing.Contracts
{
    /// <summary>
    /// This interface represents an application that
    /// is started and stopped during test
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

        /// <summary>
        /// Starts the application.
        /// </summary>
        void StartApplication();

        /// <summary>
        /// Stops the application.
        /// </summary>
        void StopApplication();
    }
}