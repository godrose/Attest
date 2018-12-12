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

        internal IEnumerable<IBuilder<TService>> GetBuilders<TService>() where TService : class
        {
            return _allBuilders.OfType<IBuilder<TService>>();
        }

        internal IEnumerable<object> GetAllBuilders()
        {
            return _allBuilders;
        }

        internal void AddBuilder<TService>(IBuilder<TService> builder) where TService : class
        {
            _allBuilders.Add(builder);
        }

        internal void ResetBuilders(IEnumerable<object> builders)
        {
            _allBuilders.Clear();
            _allBuilders.AddRange(builders);
        }
    }
}