using System.Threading.Tasks;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents callback without return value and no parameters
    /// </summary>    
    public interface IMethodCallback : 
        IAcceptor<IMethodCallbackVisitor>,
        IAcceptor<IMethodCallbackVisitorAsync, Task>
    {

    }

    /// <summary>
    /// Represents callback without return value and one parameter
    /// </summary>
    /// <typeparam name="T">Type of parameter</typeparam>
    public interface IMethodCallback<T> : 
        IAcceptorWithParameters<IMethodCallbackVisitor<T>, T>,
        IAcceptorWithParametersResult<IMethodCallbackVisitorAsync<T>, T, Task>
    {
    }

    /// <summary>
    /// Represents callback without return value and two parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public interface IMethodCallback<T1, T2> : 
        IAcceptorWithParameters<IMethodCallbackVisitor<T1, T2>, T1, T2>,
        IAcceptorWithParametersResult<IMethodCallbackVisitorAsync<T1, T2>, T1, T2, Task>
    {
    }

    /// <summary>
    /// Represents callback without return value and three parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public interface IMethodCallback<T1, T2, T3> : 
        IAcceptorWithParameters<IMethodCallbackVisitor<T1, T2, T3>, T1, T2, T3>,
        IAcceptorWithParametersResult<IMethodCallbackVisitorAsync<T1, T2, T3>, T1, T2, T3, Task>
    {
    }

    /// <summary>
    /// Represents callback without return value and four parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    public interface IMethodCallback<T1, T2, T3, T4> : 
        IAcceptorWithParameters<IMethodCallbackVisitor<T1, T2, T3, T4>, T1, T2, T3, T4>,
        IAcceptorWithParametersResult<IMethodCallbackVisitorAsync<T1, T2, T3, T4>, T1, T2, T3, T4, Task>
    {
    }

    /// <summary>
    /// Represents callback without return value and five parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>    
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    public interface IMethodCallback<T1, T2, T3, T4, T5> : 
        IAcceptorWithParameters<IMethodCallbackVisitor<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>,
        IAcceptorWithParametersResult<IMethodCallbackVisitorAsync<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5, Task>
    {
    }
}