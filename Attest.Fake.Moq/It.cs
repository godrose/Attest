using System;
using System.Linq.Expressions;

namespace Attest.Fake.Moq
{
    public static class It
    {
        /// <summary>
        /// Matches any value of the given type
        /// </summary>
        /// <typeparam name="TValue">Type of value to be matched</typeparam>
        /// <returns>Value match</returns>
        public static TValue IsAny<TValue>()
        {
            return global::Moq.It.IsAny<TValue>();
        }

        /// <summary>
        /// Matches any value that satisifies the given predicate
        /// </summary>
        /// <typeparam name="TValue">Type of value to be matched</typeparam>
        /// <param name="testExpression">Predicate to be satisfied</param>
        /// <returns>Value match</returns>
        public static TValue Is<TValue>(Expression<Func<TValue, bool>> testExpression)
        {
            return global::Moq.It.Is(testExpression);
        }
    }
}
