using System;
using System.Linq.Expressions;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    public abstract class MethodCallWithResultBase<TService, TCallback, TResult> : 
        MethodCallbacksContainerBase<TCallback>,
        IAddCallbackWithResultShared<TCallback, TResult>,
        IMethodCallWithResult<TService, TCallback, TResult> where TService : class
    {
        public Expression<Func<TService, TResult>> RunMethod { get; private set; }

        public override sealed string RunMethodDescription { get; protected set; }

        protected MethodCallWithResultBase(Expression<Func<TService, TResult>> runMethod)
        {
            RunMethod = runMethod;
            RunMethodDescription = RunMethod.ToString();
        }

        public IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback)
        {
            AddCallbackImpl(methodCallback);
            return this;
        }

        public abstract IMethodCallbacksContainer<TCallback> Complete(TResult result);

        public abstract IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        public abstract IMethodCallbacksContainer<TCallback> WithoutCallback();

        public abstract void Accept(IMethodCallWithResultVisitor<TService> visitor);
    }

    public class MethodCallWithResult0<TService, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<TResult>, TResult>, IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<TResult>, TResult>, IHaveNoCallbacksWithResult<IMethodCallbackWithResult<TResult>, TResult>, IAddCallbackWithResult<IMethodCallbackWithResult<TResult>, TResult> where TService : class
    {
        private MethodCallWithResult0(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<TResult>, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult0<TService, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<TResult>(result));
            return this;
        }

        public IMethodCallbacksContainer<IMethodCallbackWithResult<TResult>> Complete(Func<TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<TResult>(valueFunction));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<TResult>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<TResult>.Create().WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }

        public IMethodCallWithResult<TService, IMethodCallbackWithResult<TResult>, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<TResult>, TResult>, IHaveCallbacks<IMethodCallbackWithResult<TResult>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }
    }

    public class MethodCallWithResult1<TService, T, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<T, TResult>, TResult>, IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T, TResult>, T, TResult>, IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>, IAddCallbackWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult> where TService : class
    {
        private MethodCallWithResult1(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T, TResult>, T, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult1<TService, T, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T, TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T, TResult>(result));
            return this;
        }

        public IMethodCallbacksContainer<IMethodCallbackWithResult<T, TResult>> Complete(Func<T, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T, TResult>(valueFunction));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T, TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T, TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T, TResult>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T, TResult>.Create().WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }

        public IMethodCallWithResult<TService, IMethodCallbackWithResult<T, TResult>, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>> buildCallbacks)
        {
            IHaveCallbacks<IMethodCallbackWithResult<T, TResult>> haveCallbacks = buildCallbacks(this);
            return this;
        }
    }

    public class MethodCallWithResult2<TService, T1, T2, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult>, IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult> where TService : class
    {
        private MethodCallWithResult2(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult2<TService, T1, T2, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, TResult>(result));
            return this;
        }

        public IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, TResult>> Complete(Func<T1, T2, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, TResult>(valueFunction));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, TResult>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T1, T2, TResult>.Create().WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }

        public IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>> buildCallbacks)
        {
            IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>> haveCallbacks = buildCallbacks(this);
            return this;
        }
    }

    public class MethodCallWithResult3<TService, T1, T2, T3, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult>, IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult> where TService : class
    {
        private MethodCallWithResult3(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult3<TService, T1, T2, T3, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, TResult>(result));
            return this;
        }

        public IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, TResult>> Complete(Func<T1, T2, T3, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, TResult>(valueFunction));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, T3, TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, TResult>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T1, T2, T3, TResult>.Create().WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }

        public IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>> buildCallbacks)
        {
            IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>> haveCallbacks = buildCallbacks(this);
            return this;
        }
    }

    public class MethodCallWithResult4<TService, T1, T2, T3, T4, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult>, IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>, IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>, IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> where TService : class
    {
        private MethodCallWithResult4(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult4<TService, T1, T2, T3, T4, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult>(result));
            return this;
        }

        public IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>> Complete(Func<T1, T2, T3, T4, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult>(valueFunction));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, T3, T4, TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T1, T2, T3, T4, TResult>.Create().WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }

        public IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>> buildCallbacks)
        {
            IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>> haveCallbacks = buildCallbacks(this);
            return this;
        }
    }

    public class MethodCallWithResult5<TService, T1, T2, T3, T4, T5, TResult> : MethodCallWithResultBase<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult>, IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>, IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>, IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> where TService : class
    {
        private MethodCallWithResult5(Expression<Func<TService, TResult>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallWithResultInitialTemplate<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> CreateMethodCall(Expression<Func<TService, TResult>> runMethod)
        {
            return new MethodCallWithResult5<TService, T1, T2, T3, T4, T5, TResult>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult>(result));
            return this;
        }

        public IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>> Complete(Func<T1, T2, T3, T4, T5, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult>(valueFunction));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult>(exception));
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult>.Create().WithoutCallback().AsMethodCallback());
            return this;
        }

        public override void Accept(IMethodCallWithResultVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }

        public IMethodCallWithResult<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>> buildCallbacks)
        {
            IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>> haveCallbacks = buildCallbacks(this);
            return this;
        }
    }
}