using System;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents callback without return value and no parameters
    /// </summary>    
    public interface IMethodCallback : IAcceptor<IMethodCallbackVisitor>
    {

    }

    /// <summary>
    /// Represents callback without return value and one parameter
    /// </summary>
    /// <typeparam name="T">Type of parameter</typeparam>
    public interface IMethodCallback<T> : IAcceptorWithParameters<IMethodCallbackVisitor<T>, T>
    {
        Action<T> Callback { get; }
    }

    /// <summary>
    /// Represents callback without return value and two parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public interface IMethodCallback<T1, T2> : IAcceptorWithParameters<IMethodCallbackVisitor<T1, T2>, T1, T2>
    {
        Action<T1, T2> Callback { get; }
    }

    /// <summary>
    /// Represents callback without return value and three parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public interface IMethodCallback<T1, T2, T3> : IAcceptorWithParameters<IMethodCallbackVisitor<T1, T2, T3>, T1, T2, T3>
    {
        Action<T1, T2, T3> Callback { get; }
    }

    /// <summary>
    /// Represents callback without return value and four parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    public interface IMethodCallback<T1, T2, T3, T4> : IAcceptorWithParameters<IMethodCallbackVisitor<T1, T2, T3, T4>, T1, T2, T3, T4>
    {
        Action<T1, T2, T3, T4> Callback { get; }
    }

    /// <summary>
    /// Represents callback without return value and five parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>    
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    public interface IMethodCallback<T1, T2, T3, T4, T5> : IAcceptorWithParameters<IMethodCallbackVisitor<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>
    {
        Action<T1, T2, T3, T4, T5> Callback { get; }
    }
}