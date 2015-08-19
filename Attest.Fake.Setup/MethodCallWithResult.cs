using System;
using System.Linq.Expressions;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    public abstract class MethodCallWithResultBase<TService, TCallback, TResult> : 
        MethodCallbacksContainerBase<TCallback>, 
        IMethodCallWithResult<TService, TCallback, TResult>,
        IMethodCallWithResultInitialTemplate<TService, TCallback, TResult>,        
        IHaveNoCallbacksWithResult<TCallback, TResult>
        where TService : class
    {
        protected MethodCallWithResultBase(Expression<Func<TService, TResult>> runMethod)
        {
            RunMethod = runMethod;
            RunMethodDescription = RunMethod.ToString();
        }

        public Expression<Func<TService, TResult>> RunMethod { get; private set; }
        public override sealed string RunMethodDescription { get; protected set; }

        public IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback)
        {
            AddCallbackImpl(methodCallback);
            return this;
        }

        public abstract IMethodCallbacksContainer<TCallback> Complete(TResult result);

        public abstract IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        public abstract IMethodCallbacksContainer<TCallback> WithoutCallback();

        public abstract void Accept(IMethodCallWithResultVisitor<TService> visitor);

        public IMethodCallWithResult<TService, TCallback, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<TCallback, TResult>, IHaveCallbacks<TCallback>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }
    }

    public class MethodCallWithResult0<TService, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<TResult>, TResult> where TService : class
    {
        private MethodCallWithResult0(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService,IMethodCallbackWithResult<TResult>, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult0<TService, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<TResult>(result));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<TResult>> WithoutCallback()
        {
            var progressCallback = ProgressCallbackWithResult0<TResult>.Create();
            Callbacks.Add(progressCallback.WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    public class MethodCallWithResult1<TService, T, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<T, TResult>, TResult> where TService : class
    {
        private MethodCallWithResult1(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T, TResult>, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult1<TService, T, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T, TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T, TResult>(result));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T, TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T, TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T, TResult>> WithoutCallback()
        {
            var progressCallback = ProgressCallbackWithResult1<T, TResult>.Create();
            Callbacks.Add(progressCallback.WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    public class MethodCallWithResult2<TService, T1, T2, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> where TService : class
    {
        private MethodCallWithResult2(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult2<TService, T1, T2, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, TResult>(result));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, TResult>> WithoutCallback()
        {
            var progressCallback = ProgressCallbackWithResult2<T1, T2, TResult>.Create();
            Callbacks.Add(progressCallback.WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }
}