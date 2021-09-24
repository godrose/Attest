using System;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Wraps an action that has 0 parameters
    /// </summary>
    public interface IActionWrapper : IAcceptor<IActionWrapperVisitor, IMethodCallbackTemplate<IActionWrapper>>
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        Action Action { get; }
    }

    /// <summary>
    /// Wraps an action that has one parameter
    /// </summary>
    public interface IActionWrapper<T> : IAcceptor<IActionWrapperVisitor, IMethodCallbackTemplate<IActionWrapper<T>, T>>
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        Action<T> Action { get; }
    }

    /// <summary>
    /// Wraps an action that has two parameters
    /// </summary>
    public interface IActionWrapper<T1, T2> : IAcceptor<IActionWrapperVisitor, IMethodCallbackTemplate<IActionWrapper<T1, T2>, T1, T2>>
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        Action<T1, T2> Action { get; }
    }

    /// <summary>
    /// Wraps an action that has three parameters
    /// </summary>
    public interface IActionWrapper<T1, T2, T3> : IAcceptor<IActionWrapperVisitor,
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3>, T1, T2, T3>>
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        Action<T1, T2, T3> Action { get; }
    }

    /// <summary>
    /// Wraps an action that has four parameters
    /// </summary>
    public interface IActionWrapper<T1, T2, T3, T4> : IAcceptor<IActionWrapperVisitor, 
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4>, T1, T2, T3, T4>>
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        Action<T1, T2, T3, T4> Action { get; }
    }

    /// <summary>
    /// Wraps an action that has five parameters
    /// </summary>
    public interface IActionWrapper<T1, T2, T3, T4, T5> : IAcceptor<IActionWrapperVisitor, 
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>>
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        Action<T1, T2, T3, T4, T5> Action { get; }
    }     
}
