namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents an application module that is started and stopped once
    /// during the whole test session.
    /// </summary>
    public interface IStaticApplicationModule : IApplicationModule
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <returns></returns>
        int Start();

        /// <summary>
        /// Stops the application.
        /// </summary>
        /// <param name="handle"></param>
        void Stop(int handle);
    }
}