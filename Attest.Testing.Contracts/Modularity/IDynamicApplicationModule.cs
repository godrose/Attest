namespace Attest.Testing.Modularity
{
    /// <summary>
    /// This interface represents an application module that
    /// is started and stopped for each scenario/test.
    /// </summary>
    public interface IDynamicApplicationModule : IApplicationModule
    {        
        /// <summary>
        /// Starts the application module.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the application module.
        /// </summary>
        void Stop();
    }
}