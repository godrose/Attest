namespace Attest.Testing.Modularity
{
    /// <summary>
    /// Allows to specify various options for starting application modules via CLI.
    /// </summary>
    public class StartCliApplicationModuleOptions
    {
        /// <summary>
        /// Gets or sets the profile to be used during application module start.
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Gets or sets the environment to be used during application module start.
        /// </summary>
        public string Environment { get; set; }
    }
}
