namespace Attest.Testing.Contracts
{
    /// <summary>
    /// This interface represents an application that
    /// is started and stopped for each test.
    /// </summary>
    public interface IDynamicApplicationModule : IApplicationModule
    {        
        /// <summary>
        /// Starts the application.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the application.
        /// </summary>
        void Stop();
    }
}