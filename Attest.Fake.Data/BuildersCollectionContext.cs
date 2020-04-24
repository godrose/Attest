using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Patterns.Builder;

namespace Attest.Fake.Data
{    
    /// <summary>
    /// Allows managing builders collection, including serialization/deserialization.
    /// </summary>
    public sealed class BuildersCollectionContext
    {
        //TODO: The file name should be scenario-specific in case of parallel tests. Should use some kind of session id here.        
        private const string SerializedBuildersId = "SerializedBuildersCollection.Data";

        private BuildersCollection _buildersCollection = new BuildersCollection();

        private readonly IDataStorage<BuildersCollection> _buildersCollectionStorage =
            new BuildersCollectionStorage(BuildersCollectionConverterContext.Current,
                BuildersCollectionStorageContext.Current);

        /// <summary>
        /// Gets the builders of the specified service type.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public IEnumerable<IBuilder<TService>> GetBuilders<TService>() where TService : class
        {
            return _buildersCollection.GetBuilders<TService>();
        }

        /// <summary>
        /// Gets the builders of the specified service type.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns></returns>
        public IEnumerable<object> GetBuilders(Type serviceType)
        {
            return _buildersCollection.GetAllBuilders().Where(t => t.GetType() == serviceType);
        }

        /// <summary>
        /// Gets all builders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBuilder> GetAllBuilders()
        {
            return _buildersCollection.GetAllBuilders().OfType<IBuilder>();
        }

        /// <summary>
        /// Adds the builder of the specified service type.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="builder">The builder.</param>
        public void AddBuilder<TService>(IBuilder<TService> builder) where TService : class
        {
            _buildersCollection.AddBuilder(builder);
        }

        /// <summary>
        /// Serializes the builders.
        /// </summary>
        public void SerializeBuilders(string id = null)
        {
            _buildersCollectionStorage.Store(id ?? SerializedBuildersId, _buildersCollection);
        }        

        /// <summary>
        /// Deserializes the builders.
        /// </summary>
        public void DeserializeBuilders(string id = null)
        {
            var data = _buildersCollectionStorage.Load(id ?? SerializedBuildersId);
            _buildersCollection.ResetBuilders(data.GetAllBuilders());            
        }

        /// <summary>
        /// Resets the builders collection with the provided value.
        /// </summary>
        /// <param name="buildersCollection">The builders collection</param>
        public void Reset(BuildersCollection buildersCollection)
        {
            _buildersCollection = buildersCollection;
        }
    }
}
