namespace Attest.Testing.Configuration
{
    /// <summary>
    /// Represents a run guard information which is used to allow test/scenario execution for a particular key
    /// </summary>
    public interface IRunGuardInfo
    {
        /// <summary>
        /// Gets the configuration key.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Returns <see typeref="true"/> if a test/scenario can run depending on the provided input,
        /// <see typeref="false"/> otherwise.
        /// </summary>
        /// /// <param name="input">The provided input.</param>
        /// <returns></returns>
        bool CanRun(string input);
    }
}
