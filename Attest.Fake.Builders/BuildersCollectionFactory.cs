using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Patterns.Builder;

namespace Attest.Fake.Builders
{
    /// <summary>
    /// This class is responsible for creation/patching of builders collection.
    /// </summary>
    public static class BuildersCollectionFactory
    {
        /// <summary>
        /// Patches the provided builders collection by filling the missing instances.
        /// </summary>
        /// <param name="builders">The original builders collection.</param>
        /// <param name="buildersTypes">The list of required builders' types.</param>
        /// <param name="builderFactory">The builder factory.</param>
        /// <returns></returns>
        public static IBuilder[] PatchBuilders(
            IEnumerable<IBuilder> builders,
            IEnumerable<Type> buildersTypes,
            Func<Type, object> builderFactory)
        {
            var buildersCollection = builders is List<IBuilder> list ? list : builders.ToList();
            foreach (var builderType in buildersTypes)
            {
                var typedBuilders = buildersCollection.Where(t => t.GetType() == builderType).ToArray();
                if (typedBuilders.Length == 0)
                {
                    var builderInstance = (IBuilder)builderFactory(builderType);
                    buildersCollection.Add(builderInstance);
                }
            }

            return buildersCollection.ToArray();
        }
    }
}
