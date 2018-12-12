namespace Attest.Fake.Data.Shared
{
    /// <summary>
    /// Ambient context for <see cref="IBuildersCollectionConverter"/>
    /// </summary>
    public static class BuildersCollectionConverterContext
    {
        private static IBuildersCollectionConverter _buildersCollectionConverter = new JsonConverter();

        /// <summary>
        /// Gets or sets the current value of <see cref="IBuildersCollectionConverter"/>.
        /// </summary>
        /// <value>
        /// The current value.
        /// </value>
        public static IBuildersCollectionConverter Current
        {
            get => _buildersCollectionConverter;
            set => _buildersCollectionConverter = value;
        }
    }
}