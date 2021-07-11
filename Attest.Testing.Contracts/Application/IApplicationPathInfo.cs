namespace  Attest.Testing.Application
{
    /// <summary>
    /// Represents the application path information.
    /// </summary>
    public interface IApplicationPathInfo
    {
        /// <summary>
        /// The app entry point.
        /// </summary>
        string Executable { get; }

        /// <summary>
        /// The path of the app folder relatively to the test folder.
        /// </summary>
        string RelativePath { get; }
    }
}
