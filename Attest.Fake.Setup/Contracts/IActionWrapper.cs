using System;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Wraps an action that has 0 parameters
    /// </summary>
    public interface IActionWrapper : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate>
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
    /// Wraps an action that has 1 parameter
    /// </summary>
    public interface IActionWrapper<T> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T>>
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
    /// Wraps an action that has 2 parameters
    /// </summary>
    public interface IActionWrapper<T1, T2> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2>>
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
    /// Wraps an action that has 3 parameters
    /// </summary>
    public interface IActionWrapper<T1, T2, T3> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2, T3>>
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
    /// Wraps an action that has 4 parameters
    /// </summary>
    public interface IActionWrapper<T1, T2, T3, T4> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2, T3, T4>>
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
    /// Wraps an action that has 5 parameters
    /// </summary>
    public interface IActionWrapper<T1, T2, T3, T4, T5> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2, T3, T4, T5>>
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
