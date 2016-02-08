using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Wraps a return value
    /// </summary>
    public interface IResultWrapper<TResult> : IAcceptor<IResultWrapperVisitor, MethodCallbackWithResultTemplate<TResult>>        
    {
       
    }

    /// <summary>
    /// Wraps a return value with 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>    
    public interface IResultWrapper<T, TResult> : IAcceptor<IResultWrapperVisitor, MethodCallbackWithResultTemplate<T, TResult>>
    {
    }

    /// <summary>
    /// Wraps a return value with 2 parameters
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>    
    public interface IResultWrapper<T1, T2, TResult> : IAcceptor<IResultWrapperVisitor, MethodCallbackWithResultTemplate<T1, T2, TResult>>
    {
    }

    /// <summary>
    /// Visitor for all result wrappers
    /// </summary>
    public interface IResultWrapperVisitor
    {
        /// <summary>
        /// Visits the specified result wrapper resulting in method callback with return value template.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="resultWrapper">The result wrapper.</param>
        /// <returns></returns>
        MethodCallbackWithResultTemplate<TResult> Visit<TResult>(IResultWrapper<TResult> resultWrapper);

        /// <summary>
        /// Visits the specified result wrapper resulting in method callback with return value template.
        /// </summary>
        /// <typeparam name="T">The type of the parameter</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="resultWrapper">The result wrapper.</param>
        /// <returns></returns>
        MethodCallbackWithResultTemplate<T, TResult> Visit<T, TResult>(IResultWrapper<T, TResult> resultWrapper);

        /// <summary>
        /// Visits the specified result wrapper resulting in method callback with return value template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="resultWrapper">The result wrapper.</param>
        /// <returns></returns>
        MethodCallbackWithResultTemplate<T1, T2, TResult> Visit<T1, T2, TResult>(IResultWrapper<T1, T2, TResult> resultWrapper);
    }
}