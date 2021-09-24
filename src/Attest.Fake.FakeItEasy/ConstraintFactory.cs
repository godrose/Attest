using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using FakeItEasy;

namespace Attest.Fake.FakeItEasy
{
    /// <summary>
    /// Implementation of <see cref="IConstraintFactory"/>.
    /// </summary>
    /// <seealso cref="Attest.Fake.Core.IConstraintFactory" />
    public class ConstraintFactory : IConstraintFactory
    {
        /// <summary>
        /// Creates a constraint that accepts any argument value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <returns></returns>
        public TValue IsAny<TValue>()
        {
            return A<TValue>.Ignored;
        }

        /// <summary>
        /// Creates a constraint that accepts only argument that matches the specified predicate.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public TValue Matches<TValue>(Expression<Func<TValue, bool>> predicate)
        {
            return A<TValue>.That.Matches(predicate);
        }
    }
}
