namespace Attest.Testing.Modularity
{
    /// <summary>
    /// Represents an application module that is started and stopped once
    /// during the whole scenarios/tests suite run.
    /// </summary>
    public interface IStaticApplicationModule : IApplicationModule
    {
        /// <summary>
        /// Starts the application module.
        /// </summary>
        /// <returns></returns>
        int Start();

        /// <summary>
        /// Stops the application module.
        /// </summary>
        /// <param name="handle"></param>
        void Stop(int handle);
    }
}