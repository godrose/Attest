namespace Attest.Fake.Data
{
    /// <summary>
    /// Ambient context for <see cref="IBuildersCollectionConverter"/>
    /// </summary>
    public static class BuildersCollectionConverterContext
    {
        /// <summary>
        /// Gets or sets the current value of <see cref="IBuildersCollectionConverter"/>.
        /// </summary>
        /// <value>
        /// The current value.
        /// </value>
        public static IBuildersCollectionConverter Current { get; set; } = new JsonConverter();
    }
}