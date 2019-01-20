namespace Attest.Testing.Core
{
    /// <summary>
    /// Ambient Context for <see cref="IScenario"/>.
    /// </summary>
    public static class ScenarioContext
    {
        /// <summary>
        /// Gets or sets the current scenario.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static IScenario Current { get; set; }
    }
}
