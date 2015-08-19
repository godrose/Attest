using System;
using System.Linq;

namespace Attest.Fake.Setup.Contracts
{
    public abstract class MethodCallbackBaseWithResult<TResult> : IMethodCallbackWithResult<TResult>
    {
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor);
    }

    public abstract class MethodCallbackBaseWithResult<T, TResult> : IMethodCallbackWithResult<T, TResult>
    {
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor);
    }

    public abstract class MethodCallbackBaseWithResult<T1, T2, TResult> : IMethodCallbackWithResult<T1, T2, TResult>
    {
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor);
    }

    public abstract class MethodCallbackBaseWithResult<T1, T2, T3, TResult> : IMethodCallbackWithResult<T1, T2, T3, TResult>
    {
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor);
    }

    public class OnCompleteCallbackWithResult<TResult> : MethodCallbackBaseWithResult<TResult>
    {
        public TResult Result { get; private set; }

        public OnCompleteCallbackWithResult(TResult result)
        {
            Result = result;
        }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnCompleteCallbackWithResult<T, TResult> : MethodCallbackBaseWithResult<T, TResult>, IReturnResult<TResult>
    {
        public OnCompleteCallbackWithResult(TResult result)
        {
            Result = result;
        }

        public TResult Result { get; private set; }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnCompleteCallbackWithResult<T1, T2, TResult> : MethodCallbackBaseWithResult<T1, T2, TResult>, IReturnResult<TResult>
    {
        public OnCompleteCallbackWithResult(TResult result)
        {
            Result = result;
        }

        public TResult Result { get; private set; }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnCompleteCallbackWithResult<T1, T2, T3, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, TResult>, IReturnResult<TResult>
    {
        public OnCompleteCallbackWithResult(TResult result)
        {
            Result = result;
        }

        public TResult Result { get; private set; }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnErrorCallback : MethodCallbackBase
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

    public class OnErrorCallback<T> : MethodCallbackBase<T>
    {
        public OnErrorCallback(Action<T> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override void Accept(IMethodCallbackVisitor visitor, T arg)
        {
            visitor.Visit(this, arg);
        }
    }

    public class OnErrorCallback<T1, T2> : MethodCallbackBase<T1, T2>
    {
        public OnErrorCallback(Action<T1, T2> callback, Exception exception)
            : base(callback)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override void Accept(IMethodCallbackVisitor visitor, T1 arg1, T2 arg2)
        {
            visitor.Visit(this, arg1, arg2);
        }
    }

    public class OnErrorCallback<T1, T2, T3> : MethodCallbackBase<T1, T2, T3>
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

    public class OnErrorCallback<T1, T2, T3, T4> : MethodCallbackBase<T1, T2, T3, T4>
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

    public class OnErrorCallback<T1, T2, T3, T4, T5> : MethodCallbackBase<T1, T2, T3, T4, T5>
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

    public class OnErrorCallbackWithResult<TResult> : MethodCallbackBaseWithResult<TResult>
    {
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnErrorCallbackWithResult<T, TResult> : MethodCallbackBaseWithResult<T, TResult>
    {
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnErrorCallbackWithResult<T1, T2, TResult> : MethodCallbackBaseWithResult<T1, T2, TResult>
    {
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnErrorCallbackWithResult<T1, T2, T3, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, TResult>
    {
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; private set; }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
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

    public class OnCancelCallbackWithResult<TResult> : MethodCallbackBaseWithResult<TResult>
    {
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnCancelCallbackWithResult<T, TResult> : MethodCallbackBaseWithResult<T, TResult>
    {
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnCancelCallbackWithResult<T1, T2, TResult> : MethodCallbackBaseWithResult<T1, T2, TResult>
    {
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnCancelCallbackWithResult<T1, T2, T3, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, TResult>
    {
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnWithoutCallbackWithResult<TResult> : MethodCallbackBaseWithResult<TResult>
    {
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnWithoutCallbackWithResult<T, TResult> : MethodCallbackBaseWithResult<T, TResult>
    {
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnWithoutCallbackWithResult<T1, T2, TResult> : MethodCallbackBaseWithResult<T1, T2, TResult>
    {
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class OnWithoutCallbackWithResult<T1, T2, T3, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, TResult>
    {
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    //unfortunately this case can't be supported in the current model:
    //try-finally block can't both throw an exception and return a value
    //additionally it's rather strange to have progressable call return a value
    //when all the data can be just transferred over the progress messages path
    public abstract class ProgressableCallbackWithResultBase<TCallback, TResult> : ProgressMessagesBase, IProgressableProcessRunningWithResult<TCallback, TResult>,
        IProgressableProcessFinishedWithResult<TCallback, TResult>, IMethodCallbackWithResult<TCallback,TResult>
    {
        public abstract IProgressableProcessFinishedWithResult<TCallback, TResult> Complete(TResult result);
        public abstract IProgressableProcessFinishedWithResult<TCallback, TResult> Throw(Exception exception);
        public abstract IProgressableProcessFinishedWithResult<TCallback, TResult> Cancel();
        public abstract IProgressableProcessFinishedWithResult<TCallback, TResult> WithoutCallback();

        public TCallback FinishCallback { get; protected set; }

        public abstract TCallback AsMethodCallback();

        public abstract TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor);
    }

    public class ProgressCallbackWithResult0<TResult> : ProgressableCallbackWithResultBase<IMethodCallbackWithResult<TResult>, TResult>, IMethodCallbackWithResult<TResult>
    {
        private ProgressCallbackWithResult0()
        {

        }

        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult0<TResult>();
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<TResult>(result);
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<TResult>(exception);
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<TResult>();
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<TResult>, TResult> WithoutCallback()
        {
            return this;
        }

        public override IMethodCallbackWithResult<TResult> AsMethodCallback()
        {
            return this;
        }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ProgressCallbackWithResult1<T, TResult> : ProgressableCallbackWithResultBase<IMethodCallbackWithResult<T, TResult>, TResult>, IMethodCallbackWithResult<T, TResult>
    {
        private ProgressCallbackWithResult1()
        {

        }

        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<T, TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult1<T, TResult>();
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T, TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<T, TResult>(result);
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T, TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<T, TResult>(exception);
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T, TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<T, TResult>();
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T, TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<T, TResult>();
            return this;
        }

        public override IMethodCallbackWithResult<T, TResult> AsMethodCallback()
        {
            return this;
        }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ProgressCallbackWithResult2<T1, T2, TResult> : ProgressableCallbackWithResultBase<IMethodCallbackWithResult<T1, T2, TResult>, TResult>, IMethodCallbackWithResult<T1, T2, TResult>
    {
        private ProgressCallbackWithResult2()
        {

        }

        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult2<T1, T2, TResult>();
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<T1, T2, TResult>(result);
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<T1, T2, TResult>(exception);
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<T1, T2, TResult>();
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<T1, T2, TResult>();
            return this;
        }

        public override IMethodCallbackWithResult<T1, T2, TResult> AsMethodCallback()
        {
            return this;
        }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ProgressCallbackWithResult3<T1, T2, T3, TResult> : ProgressableCallbackWithResultBase<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult>, IMethodCallbackWithResult<T1, T2, T3, TResult>
    {
        private ProgressCallbackWithResult3()
        {

        }

        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult3<T1, T2, T3, TResult>();
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<T1, T2, T3, TResult>(result);
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<T1, T2, T3, TResult>(exception);
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<T1, T2, T3, TResult>();
            return this;
        }

        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<T1, T2, T3, TResult>();
            return this;
        }

        public override IMethodCallbackWithResult<T1, T2, T3, TResult> AsMethodCallback()
        {
            return this;
        }

        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class MethodCallbackWithResultVisitor<TResult> : IMethodCallbackWithResultVisitor<TResult>
    {
        public TResult Visit(OnErrorCallbackWithResult<TResult> onErrorCallback)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit<T>(OnErrorCallbackWithResult<T, TResult> onErrorCallback)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit<T1, T2>(OnErrorCallbackWithResult<T1, T2, TResult> onErrorCallback)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit<T1, T2, T3>(OnErrorCallbackWithResult<T1, T2, T3, TResult> onErrorCallback)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit(OnCancelCallbackWithResult<TResult> onCancelCallback)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit<T>(OnCancelCallbackWithResult<T, TResult> onCancelCallback)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit<T1, T2>(OnCancelCallbackWithResult<T1, T2, TResult> onCancelCallback)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit<T1, T2, T3>(OnCancelCallbackWithResult<T1, T2, T3, TResult> onCancelCallback)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult)
        {
            return onCompleteCallbackWithResult.Result;
        }

        public TResult Visit<T>(OnCompleteCallbackWithResult<T, TResult> onCompleteCallbackWithResult)
        {
            return onCompleteCallbackWithResult.Result;
        }

        public TResult Visit<T1, T2>(OnCompleteCallbackWithResult<T1, T2, TResult> onCompleteCallbackWithResult)
        {
            return onCompleteCallbackWithResult.Result;
        }

        public TResult Visit<T1, T2, T3>(OnCompleteCallbackWithResult<T1, T2, T3, TResult> onCompleteCallbackWithResult)
        {
            return onCompleteCallbackWithResult.Result;
        }

        public TResult Visit(ProgressCallbackWithResult0<TResult> progressCallback)
        {
            if (progressCallback.ProgressMessages.Any())
            {
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            }
            return progressCallback.FinishCallback.Accept(this);
        }

        public TResult Visit<T>(ProgressCallbackWithResult1<T, TResult> progressCallback)
        {
            if (progressCallback.ProgressMessages.Any())
            {
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            }
            return progressCallback.FinishCallback.Accept(this);
        }

        public TResult Visit<T1, T2>(ProgressCallbackWithResult2<T1, T2, TResult> progressCallback)
        {
            if (progressCallback.ProgressMessages.Any())
            {
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            }
            return progressCallback.FinishCallback.Accept(this);
        }

        public TResult Visit<T1, T2, T3>(ProgressCallbackWithResult3<T1, T2, T3, TResult> progressCallback)
        {
            if (progressCallback.ProgressMessages.Any())
            {
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            }
            return progressCallback.FinishCallback.Accept(this);
        }

        public TResult Visit(OnWithoutCallbackWithResult<TResult> withoutCallback)
        {
            throw new WithoutCallbackException();
        }

        public TResult Visit<T>(OnWithoutCallbackWithResult<T, TResult> withoutCallback)
        {
            throw new WithoutCallbackException();
        }

        public TResult Visit<T1, T2>(OnWithoutCallbackWithResult<T1, T2, TResult> withoutCallback)
        {
            throw new WithoutCallbackException();
        }

        public TResult Visit<T1, T2, T3>(OnWithoutCallbackWithResult<T1, T2, T3, TResult> withoutCallback)
        {
            throw new WithoutCallbackException();
        }
    }   
}