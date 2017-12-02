namespace ExpressionReflect
{
	using System.Linq.Expressions;

    /// <summary>
    /// Extension methods for <see cref="Expression"/>
    /// </summary>
    public static class ExpressionExtensions
	{
        /// <summary>
        /// Executes the specified values onto the expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static object Execute(this Expression expression, params object[] values)
		{
			ExpressionReflectionExecutor visitor = new ExpressionReflectionExecutor(expression);
			object result = visitor.Execute(values);
			return result;
		}
	}
}