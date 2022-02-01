using System.Collections.Generic;
using System.Linq;
using Solid.Patterns.Builder;

namespace Attest.Fake.Data
{
    /// <summary>
    /// Represents builders collection.
    /// </summary>    
    public class BuildersCollection
    {
        private readonly List<object> _allBuilders = new List<object>();

        /// <summary>
        /// Gets builders of the specified type.
        /// </summary>
        /// <typeparam name="TService">The builder type.</typeparam>
        /// <returns></returns>
        public IEnumerable<IBuilder<TService>> GetBuilders<TService>() where TService : class
        {
            return _allBuilders.OfType<IBuilder<TService>>();
        }

        /// <summary>
        /// Gets all builders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetAllBuilders()
        {
            return _allBuilders;
        }

        /// <summary>
        /// Adds builder of the specified type.
        /// </summary>
        /// <typeparam name="TService">The builder type.</typeparam>
        /// <param name="builder">The builder.</param>
        public void AddBuilder<TService>(IBuilder<TService> builder) where TService : class
        {
            _allBuilders.Add(builder);
        }

        /// <summary>
        /// Resets the builders collection with the provided value.
        /// </summary>
        /// <param name="builders">The new builders collection.</param>
        public void ResetBuilders(IEnumerable<object> builders)
        {
            _allBuilders.Clear();
            _allBuilders.AddRange(builders);
        }
    }
}