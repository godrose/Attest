using System;

namespace Attest.Fake.Setup.Contracts
{    
    /// <summary>
    /// Base class for method callbacks without return value and no parameters
    /// </summary>
    public abstract class MethodCallbackBase : IMethodCallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallbackBase"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        protected MethodCallbackBase(Action callback)
        {
            Callback = callback;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public abstract void Accept(IMethodCallbackVisitor visitor);

        /// <summary>
        /// Gets the callback.
        /// </summary>
        /// <value>
        /// The callback.
        /// </value>
        public Action Callback { get; private set; }
    }

    /// <summary>
    /// Base class for method callbacks without return value and one parameter
    /// </summary>
    /// <typeparam name="T">Type of parameter</typeparam>
    public abstract class MethodCallbackBase<T> : IMethodCallback<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallbackBase{T}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        protected MethodCallbackBase(Action<T> callback)
        {
            Callback = callback;
        }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        /// <value>
        /// The callback.
        /// </value>
        public Action<T> Callback { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg">The argument.</param>
        public abstract void Accept(IMethodCallbackVisitor<T> visitor, T arg);
    }

    /// <summary>
    /// Base class for method callbacks without return value and two parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public abstract class MethodCallbackBase<T1, T2> : IMethodCallback<T1, T2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallbackBase{T1, T2}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        protected MethodCallbackBase(Action<T1, T2> callback)
        {
            Callback = callback;
        }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        /// <value>
        /// The callback.
        /// </value>
        public Action<T1, T2> Callback { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param>
        public abstract void Accept(IMethodCallbackVisitor<T1, T2> visitor, T1 arg1, T2 arg2);
    }

    /// <summary>
    /// Base class for method callbacks without return value and three parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public abstract class MethodCallbackBase<T1, T2, T3> : IMethodCallback<T1, T2, T3>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallbackBase{T1, T2, T3}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        protected MethodCallbackBase(Action<T1, T2, T3> callback)
        {
            Callback = callback;
        }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        /// <value>
        /// The callback.
        /// </value>
        public Action<T1, T2, T3> Callback { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param>
        public abstract void Accept(IMethodCallbackVisitor<T1, T2, T3> visitor, T1 arg1, T2 arg2, T3 arg3);
    }

    /// <summary>
    /// Base class for method callbacks without return value and four parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    public abstract class MethodCallbackBase<T1, T2, T3, T4> : IMethodCallback<T1, T2, T3, T4>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallbackBase{T1, T2, T3, T4}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        protected MethodCallbackBase(Action<T1, T2, T3, T4> callback)
        {
            Callback = callback;
        }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        /// <value>
        /// The callback.
        /// </value>
        public Action<T1, T2, T3, T4> Callback { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param>
        public abstract void Accept(IMethodCallbackVisitor<T1, T2, T3, T4> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    /// <summary>
    /// Base class for method callbacks without return value and five parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    public abstract class MethodCallbackBase<T1, T2, T3, T4, T5> : IMethodCallback<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallbackBase{T1, T2, T3, T4, T5}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        protected MethodCallbackBase(Action<T1, T2, T3, T4, T5> callback)
        {
            Callback = callback;
        }

        /// <summary>
        /// Gets the callback.
        /// </summary>
        /// <value>
        /// The callback.
        /// </value>
        public Action<T1, T2, T3, T4, T5> Callback { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param><param name="arg5">The fifth argument.</param>
        public abstract void Accept(IMethodCallbackVisitor<T1, T2, T3, T4, T5> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }

    /// <summary>
    /// Represents successful completion callback without return value and no parameters
    /// </summary>
    public class OnCompleteCallback : MethodCallbackBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallback"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public OnCompleteCallback(Action callback) : base(callback)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallbackVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents successful completion callback without return value and one parameter
    /// </summary>
    /// <typeparam name="T">Type of parameter</typeparam>
    public class OnCompleteCallback<T> : MethodCallbackBase<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallback{T}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public OnCompleteCallback(Action<T> callback)
            : base(callback)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg">The argument.</param>
        public override void Accept(IMethodCallbackVisitor<T> visitor, T arg)
        {
            visitor.Visit(this, arg);
        }
    }

    /// <summary>
    /// Represents successful completion callback without return value and two parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public class OnCompleteCallback<T1, T2> : MethodCallbackBase<T1, T2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallback{T1, T2}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public OnCompleteCallback(Action<T1, T2> callback)
            : base(callback)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param>
        public override void Accept(IMethodCallbackVisitor<T1, T2> visitor, T1 arg1, T2 arg2)
        {
            visitor.Visit(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represents successful completion callback without return value and three parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public class OnCompleteCallback<T1, T2, T3> : MethodCallbackBase<T1, T2, T3>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallback{T1, T2, T3}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public OnCompleteCallback(Action<T1, T2, T3> callback)
            : base(callback)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param>
        public override void Accept(IMethodCallbackVisitor<T1, T2, T3> visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Represents successful completion callback without return value and four parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    public class OnCompleteCallback<T1, T2, T3, T4> : MethodCallbackBase<T1, T2, T3, T4>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallback{T1, T2, T3, T4}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public OnCompleteCallback(Action<T1, T2, T3, T4> callback)
            : base(callback)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param>
        public override void Accept(IMethodCallbackVisitor<T1, T2, T3, T4> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Represents successful completion callback without return value and five parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    public class OnCompleteCallback<T1, T2, T3, T4, T5> : MethodCallbackBase<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallback{T1, T2, T3, T4, T5}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public OnCompleteCallback(Action<T1, T2, T3, T4, T5> callback)
            : base(callback)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param><param name="arg5">The fifth argument.</param>
        public override void Accept(IMethodCallbackVisitor<T1, T2, T3, T4, T5> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }

    /// <summary>
    /// Represents exception throwing callback with no parameters
    /// </summary>
    public class OnErrorCallback : MethodCallbackBase, IThrowException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallback"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="exception">The exception.</param>
        public OnErrorCallback(Action callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        /// <summary>
        /// Exception to be thrown
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallbackVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents exception throwing callback with no parameters
    /// </summary>
    /// <typeparam name="T">Type of parameter</typeparam>
    public class OnErrorCallback<T> : MethodCallbackBase<T>, IThrowException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallback{T}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="exception">The exception.</param>
        public OnErrorCallback(Action<T> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        /// <summary>
        /// Exception to be thrown
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg">The argument.</param>
        public override void Accept(IMethodCallbackVisitor<T> visitor, T arg)
        {
            visitor.Visit(this, arg);
        }
    }

    /// <summary>
    /// Represents exception throwing callback with two parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public class OnErrorCallback<T1, T2> : MethodCallbackBase<T1, T2>, IThrowException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallback{T1, T2}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="exception">The exception.</param>
        public OnErrorCallback(Action<T1, T2> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        /// <summary>
        /// Exception to be thrown
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param>
        public override void Accept(IMethodCallbackVisitor<T1, T2> visitor, T1 arg1, T2 arg2)
        {
            visitor.Visit(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represents exception throwing callback with two parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public class OnErrorCallback<T1, T2, T3> : MethodCallbackBase<T1, T2, T3>, IThrowException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallback{T1, T2, T3}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="exception">The exception.</param>
        public OnErrorCallback(Action<T1, T2, T3> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        /// <summary>
        /// Exception to be thrown
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param>
        public override void Accept(IMethodCallbackVisitor<T1, T2, T3> visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Represents exception throwing callback with two parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    public class OnErrorCallback<T1, T2, T3, T4> : MethodCallbackBase<T1, T2, T3, T4>, IThrowException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallback{T1, T2, T3, T4}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="exception">The exception.</param>
        public OnErrorCallback(Action<T1, T2, T3, T4> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        /// <summary>
        /// Exception to be thrown
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param>
        public override void Accept(IMethodCallbackVisitor<T1, T2, T3, T4> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Represents exception throwing callback with two parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    public class OnErrorCallback<T1, T2, T3, T4, T5> : MethodCallbackBase<T1, T2, T3, T4, T5>, IThrowException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallback{T1, T2, T3, T4, T5}"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="exception">The exception.</param>
        public OnErrorCallback(Action<T1, T2, T3, T4, T5> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        /// <summary>
        /// Exception to be thrown
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param><param name="arg5">The fifth argument.</param>
        public override void Accept(IMethodCallbackVisitor<T1, T2, T3, T4, T5> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }

    /// <summary>
    /// Represents cancellation callback with no parameters
    /// </summary>
    public class OnCancelCallback : MethodCallbackBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnCancelCallback"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public OnCancelCallback(Action callback)
            : base(callback)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallbackVisitor visitor)
        {
            visitor.Visit(this);
        }
    }    

    /// <summary>
    /// Base class for progress callbacks
    /// </summary>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    public abstract class ProgressableCallbackBase<TCallback> : ProgressMessagesBase, IProgressableProcessRunning<TCallback>,
        IProgressableProcessFinished<TCallback>, IMethodCallback
    {
        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public abstract IProgressableProcessFinished<TCallback> Complete();

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public abstract IProgressableProcessFinished<TCallback> Throw(Exception exception);

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public abstract IProgressableProcessFinished<TCallback> Cancel();

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public abstract IProgressableProcessFinished<TCallback> WithoutCallback();

        /// <summary>
        /// Gets the finish callback.
        /// </summary>
        /// <value>
        /// The finish callback.
        /// </value>
        public TCallback FinishCallback { get; protected set; }

        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        public IMethodCallback AsMethodCallback()
        {
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public abstract void Accept(IMethodCallbackVisitor visitor);
    }

    /// <summary>
    /// Represents progress callback
    /// </summary>
    public class ProgressableCallback : ProgressableCallbackBase<IMethodCallback>
    {
        private ProgressableCallback()
        {

        }

        /// <summary>
        /// Creates new instance of progress message callback.
        /// </summary>
        /// <returns></returns>
        public static IProgressableProcessRunning<IMethodCallback> Create()
        {
            return new ProgressableCallback();
        }

        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinished<IMethodCallback> Complete()
        {
            FinishCallback =
                CallbackBuilder<ActionWrapper, MethodCallbackTemplate, IMethodCallback>.CreateCallbackBuilder()
                    .WithDefaultAction();
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public override IProgressableProcessFinished<IMethodCallback> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallback(() => { }, exception);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinished<IMethodCallback> Cancel()
        {
            FinishCallback = new OnCancelCallback(() => { });
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinished<IMethodCallback> WithoutCallback()
        {
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallbackVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}