using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Patterns.Builder;

namespace Attest.Fake.Data
{
    /// <summary>
    /// Helper methods for <see cref="BuildersCollection"/>
    /// </summary>
    public static class BuildersCollectionHelper
    {
        /// <summary>
        /// Fills the builders missing from <see cref="BuildersCollectionContext"/>
        /// </summary>
        /// <param name="buildersTypes">The builders types.</param>
        /// <param name="builderFactory">The builder factory method.</param>
        /// <returns></returns>
        public static IBuilder[] FillMissingBuilders(
            IEnumerable<Type> buildersTypes, 
            Func<Type, object> builderFactory)
        {
            var builders = BuildersCollectionContext.GetAllBuilders().ToList();
            foreach (var builderType in buildersTypes)
            {                                
                var typedBuilders = builders.Where(t => t.GetType() == builderType).ToArray();
                if (typedBuilders.Length == 0)
                {
                    var builderInstance = (IBuilder)builderFactory(builderType);
                    builders.Add(builderInstance);
                }                
            }

            return builders.ToArray();
        }
    }
}