namespace Attest.Testing.Core
{
    /// <summary>
    /// Ambient Context for <see cref="IScenario"/>.
    /// </summary>
    public static class ScenarioContext
    {
        private static IScenario _current;

        /// <summary>
        /// Gets or sets the current scenario.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static IScenario Current
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;                
            }
        }
    }
}
