using System;

namespace Attest.Fake.Setup.Contracts
{    
    public abstract class MethodCallbackBase : IMethodCallback
    {
        protected MethodCallbackBase(Action callback)
        {
            Callback = callback;
        }

        public abstract void Accept(IMethodCallbackVisitor visitor);

        public Action Callback { get; private set; }
    }

    public abstract class MethodCallbackBase<T> : IMethodCallback<T>
    {
        protected MethodCallbackBase(Action<T> callback)
        {
            Callback = callback;
        }        

        public Action<T> Callback { get; private set; }

        public abstract void Accept(IMethodCallbackVisitor<T> visitor, T arg);
    }

    public abstract class MethodCallbackBase<T1, T2> : IMethodCallback<T1, T2>
    {
        protected MethodCallbackBase(Action<T1, T2> callback)
        {
            Callback = callback;
        }

        public Action<T1, T2> Callback { get; private set; }

        public abstract void Accept(IMethodCallbackVisitor<T1, T2> visitor, T1 arg1, T2 arg2);
    }

    public abstract class MethodCallbackBase<T1, T2, T3> : IMethodCallback<T1, T2, T3>
    {
        protected MethodCallbackBase(Action<T1, T2, T3> callback)
        {
            Callback = callback;
        }

        public Action<T1, T2, T3> Callback { get; private set; }

        public abstract void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3);
    }

    public abstract class MethodCallbackBase<T1, T2, T3, T4> : IMethodCallback<T1, T2, T3, T4>
    {
        protected MethodCallbackBase(Action<T1, T2, T3, T4> callback)
        {
            Callback = callback;
        }

        public Action<T1, T2, T3, T4> Callback { get; private set; }

        public abstract void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    public abstract class MethodCallbackBase<T1, T2, T3, T4, T5> : IMethodCallback<T1, T2, T3, T4, T5>
    {
        protected MethodCallbackBase(Action<T1, T2, T3, T4, T5> callback)
        {
            Callback = callback;
        }

        public Action<T1, T2, T3, T4, T5> Callback { get; private set; }

        public abstract void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }

    public class OnCompleteCallback : MethodCallbackBase
    {
        public OnCompleteCallback(Action callback) : base(callback)
        {
        }

        public override void Accept(IMethodCallbackVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class OnCompleteCallback<T> : MethodCallbackBase<T>
    {
        public OnCompleteCallback(Action<T> callback)
            : base(callback)
        {
        }

        public override void Accept(IMethodCallbackVisitor<T> visitor, T arg)
        {
            visitor.Visit(this, arg);
        }
    }

    public class OnCompleteCallback<T1, T2> : MethodCallbackBase<T1, T2>
    {
        public OnCompleteCallback(Action<T1, T2> callback)
            : base(callback)
        {
        }

        public override void Accept(IMethodCallbackVisitor<T1, T2> visitor, T1 arg1, T2 arg2)
        {
            visitor.Visit(this, arg1, arg2);
        }
    }

    public class OnCompleteCallback<T1, T2, T3> : MethodCallbackBase<T1, T2, T3>
    {
        public OnCompleteCallback(Action<T1, T2, T3> callback)
            : base(callback)
        {
        }

        public override void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    public class OnCompleteCallback<T1, T2, T3, T4> : MethodCallbackBase<T1, T2, T3, T4>
    {
        public OnCompleteCallback(Action<T1, T2, T3, T4> callback)
            : base(callback)
        {
        }

        public override void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    public class OnCompleteCallback<T1, T2, T3, T4, T5> : MethodCallbackBase<T1, T2, T3, T4, T5>
    {
        public OnCompleteCallback(Action<T1, T2, T3, T4, T5> callback)
            : base(callback)
        {
        }

        public override void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }

    public class OnErrorCallback : MethodCallbackBase, IThrowException
    {
        public OnErrorCallback(Action callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override void Accept(IMethodCallbackVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class OnErrorCallback<T> : MethodCallbackBase<T>, IThrowException
    {
        public OnErrorCallback(Action<T> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override void Accept(IMethodCallbackVisitor<T> visitor, T arg)
        {
            visitor.Visit(this, arg);
        }
    }

    public class OnErrorCallback<T1, T2> : MethodCallbackBase<T1, T2>, IThrowException
    {
        public OnErrorCallback(Action<T1, T2> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override void Accept(IMethodCallbackVisitor<T1, T2> visitor, T1 arg1, T2 arg2)
        {
            visitor.Visit(this, arg1, arg2);
        }
    }

    public class OnErrorCallback<T1, T2, T3> : MethodCallbackBase<T1, T2, T3>, IThrowException
    {
        public OnErrorCallback(Action<T1, T2, T3> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    public class OnErrorCallback<T1, T2, T3, T4> : MethodCallbackBase<T1, T2, T3, T4>, IThrowException
    {
        public OnErrorCallback(Action<T1, T2, T3, T4> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    public class OnErrorCallback<T1, T2, T3, T4, T5> : MethodCallbackBase<T1, T2, T3, T4, T5>, IThrowException
    {
        public OnErrorCallback(Action<T1, T2, T3, T4, T5> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }

    public class OnCancelCallback : MethodCallbackBase
    {
        public OnCancelCallback(Action callback)
            : base(callback)
        {
        }

        public override void Accept(IMethodCallbackVisitor visitor)
        {
            visitor.Visit(this);
        }
    }    

    public abstract class ProgressableCallbackBase<TCallback> : ProgressMessagesBase, IProgressableProcessRunning<TCallback>,
        IProgressableProcessFinished<TCallback>, IMethodCallback
    {
        public abstract IProgressableProcessFinished<TCallback> Complete();
        public abstract IProgressableProcessFinished<TCallback> Throw(Exception exception);
        public abstract IProgressableProcessFinished<TCallback> Cancel();
        public abstract IProgressableProcessFinished<TCallback> WithoutCallback();

        public TCallback FinishCallback { get; protected set; }

        public IMethodCallback AsMethodCallback()
        {
            return this;
        }

        public abstract void Accept(IMethodCallbackVisitor visitor);
    }

    public class ProgressableCallback : ProgressableCallbackBase<IMethodCallback>
    {
        private ProgressableCallback()
        {

        }

        public static IProgressableProcessRunning<IMethodCallback> Create()
        {
            return new ProgressableCallback();
        }

        public override IProgressableProcessFinished<IMethodCallback> Complete()
        {
            FinishCallback =
                CallbackBuilder<ActionWrapper, MethodCallbackTemplate, IMethodCallback>.CreateCallbackBuilder()
                    .WithDefaultAction();
            return this;
        }

        public override IProgressableProcessFinished<IMethodCallback> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallback(() => { }, exception);
            return this;
        }

        public override IProgressableProcessFinished<IMethodCallback> Cancel()
        {
            FinishCallback = new OnCancelCallback(() => { });
            return this;
        }

        public override IProgressableProcessFinished<IMethodCallback> WithoutCallback()
        {
            return this;
        }

        public override void Accept(IMethodCallbackVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}