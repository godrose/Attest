namespace Attest.Fake.Core
{
    /// <summary>
    /// Ambient context for <see cref="IFakeFactory"/>
    /// </summary>
    public static class FakeFactoryContext
    {
        /// <summary>
        /// Gets or sets the current value of <see cref="IFakeFactory"/>.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static IFakeFactory Current { get; set; }
    }
}
