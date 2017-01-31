using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using LightMock;

namespace Attest.Fake.LightMock
{
    /// <summary>
    /// Represents a factory for creating argument constraints.
    /// </summary>
    /// <seealso cref="Attest.Fake.Core.IConstraintFactory" />
    public class ConstraintFactory : IConstraintFactory
    {
        /// <summary>
        /// Creates a constraint that accepts any argument value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TValue IsAny<TValue>()
        {
            return The<TValue>.IsAnyValue;
        }

        /// <summary>
        /// Creates a constraint that accepts only an argument that matches the specified predicate.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TValue Matches<TValue>(Expression<Func<TValue, bool>> predicate)
        {
            return The<TValue>.Is(predicate.Compile());
        }
    }
}
