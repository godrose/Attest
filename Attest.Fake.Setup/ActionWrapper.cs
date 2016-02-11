using System;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Wraps an action that has 0 parameters
    /// </summary>
    public class ActionWrapper : IActionWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper"/> class.
        /// </summary>
        public ActionWrapper()
            :this(() => { })
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionWrapper(Action action)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Action Action { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackTemplate<IActionWrapper> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Wraps an action that has 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <seealso cref="Contracts.IActionWrapper{TParameter1}" />
    public class ActionWrapper<T> : IActionWrapper<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T}"/> class.
        /// </summary>
        public ActionWrapper() :this(T => { })
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T}"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionWrapper(Action<T> action)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Action<T> Action { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackTemplate<IActionWrapper<T>, T> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Wraps an action that has 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <seealso cref="Contracts.IActionWrapper{TParameter1, TParameter2}" />
    public class ActionWrapper<T1,T2> : IActionWrapper<T1, T2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T1, T2}"/> class.
        /// </summary>
        public ActionWrapper()
            :this((arg1, arg2) => { })
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T1, T2}"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionWrapper(Action<T1, T2> action)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Action<T1, T2> Action { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackTemplate<IActionWrapper<T1, T2>, T1, T2> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Wraps an action that has 3 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <seealso cref="Contracts.IActionWrapper{TParameter1, TParameter2, TParameter3}" />
    public class ActionWrapper<T1, T2, T3> : IActionWrapper<T1, T2, T3>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T1, T2, T3}"/> class.
        /// </summary>
        public ActionWrapper()
            : this((arg1, arg2, arg3) => { })
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T1, T2, T3}"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionWrapper(Action<T1, T2, T3> action)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Action<T1, T2, T3> Action { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackTemplate<IActionWrapper<T1, T2, T3>, T1, T2, T3> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Wraps an action that has 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <seealso cref="Contracts.IActionWrapper{TParameter1, TParameter2, TParameter3, TParameter4}" />
    public class ActionWrapper<T1, T2, T3, T4> : IActionWrapper<T1, T2, T3, T4>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T1, T2, T3, T4}"/> class.
        /// </summary>
        public ActionWrapper()
            : this((arg1, arg2, arg3, arg4) => { })
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T1, T2, T3, T4}"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionWrapper(Action<T1, T2, T3, T4> action)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Action<T1, T2, T3, T4> Action { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4>, T1, T2, T3, T4> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Wraps an action that has 5 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <seealso cref="Contracts.IActionWrapper{TParameter1, TParameter2, TParameter3, TParameter4, TParameter5}" />
    public class ActionWrapper<T1, T2, T3, T4, T5> : IActionWrapper<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T1, T2, T3, T4, T5}"/> class.
        /// </summary>
        public ActionWrapper()
            : this((arg1, arg2, arg3, arg4, arg5) => { })
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWrapper{T1, T2, T3, T4, T5}"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionWrapper(Action<T1, T2, T3, T4, T5> action)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Action<T1, T2, T3, T4, T5> Action { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}