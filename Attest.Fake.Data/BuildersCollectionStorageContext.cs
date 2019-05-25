namespace Attest.Fake.Data
{
    /// <summary>
    /// Ambient context for <see cref="IDataStorage{T}"/>
    /// </summary>
    public static class BuildersCollectionStorageContext
    {
        /// <summary>
        /// Gets or sets the current value of <see cref="IBuildersCollectionConverter"/>.
        /// </summary>
        /// <value>
        /// The current value.
        /// </value>
        public static IDataStorage<string> Current { get; set; } = new LocalFileSystemDataStorage();
    }
}