namespace ExpressionReflect
{
	using System;

    /// <summary>
    /// Represents an exception that occurs during expression execution.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ExpressionExecutionException : Exception
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionExecutionException"/> class.
        /// </summary>
        public ExpressionExecutionException()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionExecutionException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExpressionExecutionException(string message)
			: base(message)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionExecutionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ExpressionExecutionException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}