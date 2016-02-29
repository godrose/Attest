using System.Threading.Tasks;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents callback with return value and no parameters
    /// </summary>
    /// <typeparam name="TResult">Type of return value</typeparam>
    public interface IMethodCallbackWithResult<TResult> : 
        IAcceptor<IMethodCallbackWithResultVisitor<TResult>, TResult>, 
        IAcceptor<IMethodCallbackWithResultVisitorAsync<TResult>, Task<TResult>>
    {
    }

    /// <summary>
    /// Represents callback with return value and one parameter
    /// </summary>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T">Type of parameter</typeparam>
    public interface IMethodCallbackWithResult<T, TResult> : 
        IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T, TResult>, T, TResult>,
        IAcceptorWithParametersResult<IMethodCallbackWithResultVisitorAsync<T, TResult>, T, Task<TResult>>
    {
    }

    /// <summary>
    /// Represents callback with return value and two parameters
    /// </summary>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public interface IMethodCallbackWithResult<T1, T2, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T1, T2, TResult>, T1, T2, TResult>
    {
    }

    /// <summary>
    /// Represents callback with return value and three parameters
    /// </summary>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public interface IMethodCallbackWithResult<T1, T2, T3, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T1, T2, T3, TResult>, T1, T2, T3, TResult>
    {
    }

    /// <summary>
    /// Represents callback with return value and four parameters
    /// </summary>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    public interface IMethodCallbackWithResult<T1, T2, T3, T4, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>
    {
    }

    /// <summary>
    /// Represents callback with return value and five parameters
    /// </summary>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    public interface IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult> : IAcceptorWithParametersResult<IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>
    {
    }
}