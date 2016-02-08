using System;
using System.Linq.Expressions;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Base class for method calls.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <seealso cref="Attest.Fake.Setup.MethodCallbacksContainerBase{TCallback}" />
    /// <seealso cref="Attest.Fake.Setup.Contracts.IMethodCall{TService, TCallback}" />
    /// <seealso cref="Attest.Fake.Setup.Contracts.IMethodCallInitialTemplate{TService, TCallback}" />
    /// <seealso cref="Attest.Fake.Setup.Contracts.IHaveNoCallbacks{TCallback}" />
    public abstract class MethodCallBase<TService, TCallback> : 
        MethodCallbacksContainerBase<TCallback>, 
        IMethodCall<TService, TCallback>, 
        IMethodCallInitialTemplate<TService, TCallback>,        
        IHaveNoCallbacks<TCallback>
        where TService : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallBase{TService, TCallback}"/> class.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        protected MethodCallBase(Expression<Action<TService>> runMethod)
        {
            RunMethod = runMethod;
            RunMethodDescription = RunMethod.ToString();           
        }

        /// <summary>
        /// Gets the run method.
        /// </summary>
        /// <value>
        /// The run method.
        /// </value>
        public Expression<Action<TService>> RunMethod { get; private set; }

        /// <summary>
        /// Gets the run method description.
        /// </summary>
        /// <value>
        /// The run method description.
        /// </value>
        public override sealed string RunMethodDescription { get; protected set; }

        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        public IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback)
        {
            AddCallbackInternal(methodCallback);
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public abstract IMethodCallbacksContainer<TCallback> Complete();

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Callbacks container</returns>
        public abstract IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        ///// <summary>
        ///// Adds never-ending callback to the callbacks container
        ///// </summary>
        ///// <returns>Callbacks container</returns>
        //public abstract IMethodCallbacksContainer<TCallback> WithoutCallback();

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public abstract void Accept(IMethodCallVisitor<TService> visitor);

        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCall<TService, TCallback> BuildCallbacks(Func<IHaveNoCallbacks<TCallback>, IHaveCallbacks<TCallback>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }
    }

    /// <summary>
    /// Represents method call without return value.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>    
    public class MethodCall<TService> : MethodCallBase<TService, IMethodCallback> where TService : class
    {
        private MethodCall(Expression<Action<TService>> runMethod) : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall<TService>(runMethod);
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback> Complete()
        {
            Callbacks.Add(
                CallbackBuilder<ActionWrapper, MethodCallbackTemplate, IMethodCallback>.CreateCallbackBuilder()
                    .WithDefaultAction());
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallback(exception));
            return this;
        }

        ///// <summary>
        ///// Adds never-ending callback to the callbacks container
        ///// </summary>
        ///// <returns>Callbacks container</returns>
        //public override IMethodCallbacksContainer<IMethodCallback> WithoutCallback()
        //{
        //    Callbacks.Add(ProgressCallback.Create().WithoutCallback().AsMethodCallback());
        //    return this;
        //}

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents method call without return value and 1 parameter.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T">The type of the parameter</typeparam>    
    public class MethodCall<TService, T> : MethodCallBase<TService, IMethodCallback<T>> where TService : class
    {
        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall<TService, T>(runMethod);
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T>> Complete()
        {
            Callbacks.Add(
                CallbackBuilder<ActionWrapper<T>, MethodCallbackTemplate<T>, IMethodCallback<T>>.CreateCallbackBuilder()
                    .WithDefaultAction());
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallback<T>(exception));
            return this;
        }

        ///// <summary>
        ///// Adds never-ending callback to the callbacks container
        ///// </summary>
        ///// <returns>Callbacks container</returns>
        //public override IMethodCallbacksContainer<IMethodCallback<T>> WithoutCallback()
        //{
        //    Callbacks.Add(ProgressCallback<T>.Create().WithoutCallback().AsMethodCallback());
        //    return this;
        //}

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents method call without return value and 2 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    public class MethodCall<TService, T1, T2> : MethodCallBase<TService, IMethodCallback<T1, T2>> where TService : class
    {
        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T1, T2}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall<TService, T1, T2>(runMethod);
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2>> Complete()
        {
            Callbacks.Add(
              CallbackBuilder<ActionWrapper<T1, T2>, MethodCallbackTemplate<T1, T2>, IMethodCallback<T1, T2>>.CreateCallbackBuilder()
                  .WithDefaultAction());
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallback<T1, T2>(exception));
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents method call without return value and 3 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    public class MethodCall<TService, T1, T2, T3> : MethodCallBase<TService, IMethodCallback<T1, T2, T3>> where TService : class
    {
        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T1, T2, T3}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall<TService, T1, T2, T3>(runMethod);
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3>> Complete()
        {
            Callbacks.Add(
              CallbackBuilder<ActionWrapper<T1, T2, T3>, MethodCallbackTemplate<T1, T2, T3>, IMethodCallback<T1, T2, T3>>.CreateCallbackBuilder()
                  .WithDefaultAction());
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallback<T1, T2, T3>(exception));
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents method call without return value and 4 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter</typeparam>
    public class MethodCall<TService, T1, T2, T3, T4> : MethodCallBase<TService, IMethodCallback<T1, T2, T3, T4>> where TService : class
    {
        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T1, T2, T3, T4}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall<TService, T1, T2, T3, T4>(runMethod);
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4>> Complete()
        {
            Callbacks.Add(
              CallbackBuilder<ActionWrapper<T1, T2, T3, T4>, MethodCallbackTemplate<T1, T2, T3, T4>, IMethodCallback<T1, T2, T3, T4>>.CreateCallbackBuilder()
                  .WithDefaultAction());
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallback<T1, T2, T3, T4>(exception));
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents method call without return value and 5 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter</typeparam>
    public class MethodCall<TService, T1, T2, T3, T4, T5> : MethodCallBase<TService, IMethodCallback<T1, T2, T3, T4, T5>> where TService : class
    {
        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T1, T2, T3, T4, T5}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3, T4, T5>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall<TService, T1, T2, T3, T4, T5>(runMethod);
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4, T5>> Complete()
        {
            Callbacks.Add(
                CallbackBuilder
                    <ActionWrapper<T1, T2, T3, T4, T5>, MethodCallbackTemplate<T1, T2, T3, T4, T5>,
                        IMethodCallback<T1, T2, T3, T4, T5>>.CreateCallbackBuilder()
                    .WithDefaultAction());
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4, T5>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallback<T1, T2, T3, T4, T5>(exception));
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }
}