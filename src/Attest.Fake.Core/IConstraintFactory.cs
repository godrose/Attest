using System;
using System.Linq.Expressions;

namespace Attest.Fake.Core
{
    /// <summary>
    /// Represents a factory for creating argument constraints.
    /// </summary>
    public interface IConstraintFactory
    {
        /// <summary>
        /// Creates a constraint that accepts any argument value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <returns></returns>
        TValue IsAny<TValue>();

        /// <summary>
        /// Creates a constraint that accepts only an argument that matches the specified predicate.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        TValue Matches<TValue>(Expression<Func<TValue, bool>> predicate);
    }
}