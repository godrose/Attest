using System;
using System.Linq.Expressions;
using LightMock;

namespace Attest.Fake.LightMock
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
            return The<TValue>.IsAnyValue;
        }

        /// <summary>
        /// Matches any value that satisifies the given predicate
        /// </summary>
        /// <typeparam name="TValue">Type of value to be matched</typeparam>
        /// <param name="testExpression">Predicate to be satisfied</param>
        /// <returns>Value match</returns>
        public static TValue Is<TValue>(Expression<Func<TValue, bool>> testExpression)
        {
            return The<TValue>.Is(testExpression.Compile());
        }
    }
}