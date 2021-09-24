using System;
using System.Collections.Generic;
using Attest.Fake.Builders;
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
        /// <param name="buildersCollectionContext">The builders collection context.</param>
        /// <param name="buildersTypes">The builders types.</param>
        /// <param name="builderFactory">The builder factory method.</param>
        /// <returns></returns>
        public static IBuilder[] FillMissingBuilders(
            BuildersCollectionContext buildersCollectionContext,
            IEnumerable<Type> buildersTypes, 
            Func<Type, object> builderFactory)
        {
            return BuildersCollectionFactory.PatchBuilders(buildersCollectionContext.GetAllBuilders(),
                buildersTypes, builderFactory);
        }
    }
}