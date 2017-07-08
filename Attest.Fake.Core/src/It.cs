using System;
using System.Linq.Expressions;

namespace Attest.Fake.Core
{
    /// <summary>
    /// Used for static access to the argument constraints.
    /// </summary>
    public static class It
    {
        /// <summary>
        /// Creates a constraint that accepts any argument value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <returns></returns>
        public static TValue IsAny<TValue>()
        {
            return ConstraintFactoryContext.Current.IsAny<TValue>();
        }

        /// <summary>
        /// Creates a constraint that accepts only an argument that matches the specified predicate.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static TValue Matches<TValue>(Expression<Func<TValue, bool>> predicate)
        {
            return ConstraintFactoryContext.Current.Matches(predicate);
        }
    }
}
