namespace Attest.Fake.Data
{    
    /// <summary>
    /// Enables storing and loading builders collection.
    /// </summary>
    /// <seealso cref="IDataStorage{T}" />
    public class BuildersCollectionStorage : IDataStorage<BuildersCollection>
    {
        private readonly IBuildersCollectionConverter _converter;
        private readonly IDataStorage<string> _dataStorage;

        /// <summary>
        /// Creates and initializes an instance of <see cref="BuildersCollectionStorage"/>
        /// </summary>
        /// <param name="converter"></param>
        /// <param name="dataStorage"></param>
        public BuildersCollectionStorage(
            IBuildersCollectionConverter converter,
            IDataStorage<string> dataStorage)
        {
            _converter = converter;
            _dataStorage = dataStorage;
        }

        /// <inheritdoc />       
        public void Store(string id, BuildersCollection buildersCollection)
        {            
            var str = _converter.Serialize(buildersCollection);
            _dataStorage.Store(id, str);
        }

        /// <inheritdoc />        
        public BuildersCollection Load(string id)
        {                        
            var str = _dataStorage.Load(id);
            return _converter.Deserialize(str);
        }        
    }    
}
