namespace Attest.Fake.Core
{
    /// <summary>
    /// Ambient context for <see cref="IConstraintFactory"/>
    /// </summary>
    public static class ConstraintFactoryContext
    {
        /// <summary>
        /// Gets or sets the current value of <see cref="IConstraintFactory"/>.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static IConstraintFactory Current { get; set; }
    }
}
