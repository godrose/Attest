namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents means for starting and stopping OS processes.
    /// </summary>
    public interface IProcessManagementService
    {
        /// <summary>
        /// Creates and starts a new process by launching the specified tool using provided args.
        /// </summary>
        /// <param name="tool">Tool name.</param>
        /// <param name="args">List of arguments.</param>
        /// <returns>The id of the new process.</returns>
        int Start(string tool, string args);

        /// <summary>
        /// Stops the process associated with the provided id.
        /// </summary>
        /// <param name="processId">The process id.</param>
        void Stop(int processId);
    }
}
