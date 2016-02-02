using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Base class for method callback templates with return value.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class MethodCallbackWithResultTemplateBase<TResult>
    {
        internal void SetReturnValueInternal(TResult result)
        {
            Result = result;
        }

        /// <summary>
        /// Gets the return value.
        /// </summary>
        /// <value>
        /// The return value.
        /// </value>
        public TResult Result { get; private set; }
    }

    /// <summary>
    /// Represents a template for method callback with return value.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value.</typeparam>    
    /// <seealso cref="Contracts.IReturnResult{TResult}" />
    public class MethodCallbackWithResultTemplate<TResult> :
        MethodCallbackWithResultTemplateBase<TResult>,
        IAcceptor<IMethodCallbackWithResultTemplateVisitor, IMethodCallbackWithResult<TResult>>, IReturnResult<TResult>
    {
        /// <summary>
        /// Sets the expected return value.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public MethodCallbackWithResultTemplate<TResult> WithResult(TResult result)
        {
            SetReturnValueInternal(result);
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackWithResult<TResult> Accept(IMethodCallbackWithResultTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }        
    }

    /// <summary>
    /// Represents a template for method callback with return value and 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.IReturnResult{TResult}" />
    public class MethodCallbackWithResultTemplate<T, TResult> :
        MethodCallbackWithResultTemplateBase<TResult>,
        IAcceptor<IMethodCallbackWithResultTemplateVisitor, IMethodCallbackWithResult<T, TResult>>, IReturnResult<TResult>
    {
        /// <summary>
        /// Sets the expected return value.
        /// </summary>
        /// <param name="result">The expected return value.</param>
        /// <returns></returns>
        public MethodCallbackWithResultTemplate<T, TResult> WithResult(TResult result)
        {
            SetReturnValueInternal(result);
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackWithResult<T, TResult> Accept(IMethodCallbackWithResultTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }       
    }

    /// <summary>
    /// Represents a template for method callback with return value and 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.IReturnResult{TResult}" />
    public class MethodCallbackWithResultTemplate<T1, T2, TResult> :
        MethodCallbackWithResultTemplateBase<TResult>,
        IAcceptor<IMethodCallbackWithResultTemplateVisitor, IMethodCallbackWithResult<T1, T2, TResult>>, IReturnResult<TResult>
    {
        /// <summary>
        /// Sets the expected return value.
        /// </summary>
        /// <param name="result">The expected return value.</param>
        /// <returns></returns>
        public MethodCallbackWithResultTemplate<T1, T2, TResult> WithResult(TResult result)
        {
            SetReturnValueInternal(result);
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackWithResult<T1, T2, TResult> Accept(IMethodCallbackWithResultTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }       
    }

    /// <summary>
    /// Represents visitor for method callback tempaltes with return value.
    /// </summary>
    public interface IMethodCallbackWithResultTemplateVisitor
    {
        /// <summary>
        /// Visits the specified method callback template with return value.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallbackWithResult<TResult> Visit<TResult>(MethodCallbackWithResultTemplate<TResult> methodCallbackTemplate);

        /// <summary>
        /// Visits the specified method callback template with return value and 1 parameter.
        /// </summary>
        /// <typeparam name="T">The ype of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallbackWithResult<T, TResult> Visit<T, TResult>(MethodCallbackWithResultTemplate<T, TResult> methodCallbackTemplate);

        /// <summary>
        /// Visits the specified method callback template with return value and 2 parameters.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallbackWithResult<T1, T2, TResult> Visit<T1, T2, TResult>(MethodCallbackWithResultTemplate<T1, T2, TResult> methodCallbackTemplate);
    }

    /// <summary>
    /// Represents an implementation of <see cref="IMethodCallbackWithResultTemplateVisitor" /> for successful completion callbacks.
    /// </summary>
    /// <seealso cref="IMethodCallbackWithResultTemplateVisitor" />
    public class OnCompleteCallbackWithResultVisitor : IMethodCallbackWithResultTemplateVisitor
    {
        /// <summary>
        /// Visits the specified method callback template with return value.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        public IMethodCallbackWithResult<TResult> Visit<TResult>(MethodCallbackWithResultTemplate<TResult> methodCallbackTemplate)
        {
            return new OnCompleteCallbackWithResult<TResult>(methodCallbackTemplate.Result);
        }

        /// <summary>
        /// Visits the specified method callback template with return value and 1 parameter.
        /// </summary>
        /// <typeparam name="T">The type of the parameter</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        public IMethodCallbackWithResult<T, TResult> Visit<T, TResult>(MethodCallbackWithResultTemplate<T, TResult> methodCallbackTemplate)
        {
            return new OnCompleteCallbackWithResult<T, TResult>(methodCallbackTemplate.Result);
        }

        /// <summary>
        /// Visits the specified method callback template with return value and 2 parameters.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        public IMethodCallbackWithResult<T1, T2, TResult> Visit<T1, T2, TResult>(MethodCallbackWithResultTemplate<T1, T2, TResult> methodCallbackTemplate)
        {
            return new OnCompleteCallbackWithResult<T1, T2, TResult>(methodCallbackTemplate.Result);
        }
    }
}