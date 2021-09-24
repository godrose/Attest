using System;
using System.Linq.Expressions;
using FakeItEasy;

namespace Attest.Fake.FakeItEasy
{
    /// <summary>
    /// Wrapper class for specifying value constraints.
    /// </summary>
    public static class It
    {
        /// <summary>
        /// Matches any value of the given type
        /// </summary>
        /// <typeparam name="TValue">Type of value to be matched</typeparam>
        /// <returns>Value match</returns>
        public static TValue IsAny<TValue>()
        {
            return A<TValue>.Ignored;
        }

        /// <summary>
        /// Matches any value that satisifies the given predicate
        /// </summary>
        /// <typeparam name="TValue">Type of value to be matched</typeparam>
        /// <param name="testExpression">Predicate to be satisfied</param>
        /// <returns>Value match</returns>
        public static TValue Is<TValue>(Expression<Func<TValue, bool>> testExpression)
        {
            return A<TValue>.That.Matches(testExpression);
        }
    }
}
