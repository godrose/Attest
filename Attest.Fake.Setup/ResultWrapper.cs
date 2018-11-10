using System;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Represents an object that wraps return value of a method call.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso />
    public class ResultWrapper<TResult> : IResultWrapper<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultWrapper{TResult}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public ResultWrapper(TResult result)
        {
            Result = result;
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public TResult Result { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public MethodCallbackWithResultTemplate<TResult> Accept(IResultWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents an object that wraps return value of a method call with 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.IResultWrapper{T, TResult}" />
    public class ResultWrapper<T, TResult> : IResultWrapper<T, TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultWrapper{T, TResult}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public ResultWrapper(TResult result)
        {
            Result = result;
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public TResult Result { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public MethodCallbackWithResultTemplate<T, TResult> Accept(IResultWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents an object that wraps return value of a method call with 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.IResultWrapper{T1, T2, TResult}" />
    public class ResultWrapper<T1, T2, TResult> : IResultWrapper<T1, T2, TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultWrapper{T1, T2, TResult}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public ResultWrapper(TResult result)
        {
            Result = result;
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public TResult Result { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns></returns>
        public MethodCallbackWithResultTemplate<T1, T2, TResult> Accept(IResultWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    internal class ResultWrapperVisitor : IResultWrapperVisitor
    {
        public MethodCallbackWithResultTemplate<TResult> Visit<TResult>(IResultWrapper<TResult> resultWrapper)
        {
            return VisitImpl<MethodCallbackWithResultTemplate<TResult>>();
        }

        public MethodCallbackWithResultTemplate<T, TResult> Visit<T, TResult>(IResultWrapper<T, TResult> resultWrapper)
        {
            throw new NotImplementedException();
        }

        public MethodCallbackWithResultTemplate<T1, T2, TResult> Visit<T1, T2, TResult>(IResultWrapper<T1, T2, TResult> resultWrapper)
        {
            throw new NotImplementedException();
        }

        private TMethodCallbackTemplate VisitImpl<TMethodCallbackTemplate>() where TMethodCallbackTemplate : new()
        {            
            return new TMethodCallbackTemplate();
        }
    }
}