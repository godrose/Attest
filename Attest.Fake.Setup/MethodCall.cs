using System;
using System.Linq.Expressions;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{    
    public abstract class MethodCallBase<TService, TCallback> : 
        MethodCallbacksContainerBase<TCallback>, 
        IMethodCall<TService, TCallback>, 
        IMethodCallInitialTemplate<TService, TCallback>,        
        IHaveNoCallbacks<TCallback>
        where TService : class
    {                
        protected MethodCallBase(Expression<Action<TService>> runMethod)
        {
            RunMethod = runMethod;
            RunMethodDescription = RunMethod.ToString();           
        }

        public Expression<Action<TService>> RunMethod { get; private set; }
        public override sealed string RunMethodDescription { get; protected set; }        

        public IMethodCallbacksContainer<TCallback> AddCallback(TCallback methodCallback)
        {
            AddCallbackImpl(methodCallback);
            return this;
        }        

        public abstract IMethodCallbacksContainer<TCallback> Complete();

        public abstract IMethodCallbacksContainer<TCallback> Throw(Exception exception);

        public abstract void Accept(IMethodCallVisitor<TService> visitor);

        public IMethodCall<TService, TCallback> BuildCallbacks(Func<IHaveNoCallbacks<TCallback>, IHaveCallbacks<TCallback>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }
    }

    public class MethodCall0<TService> : MethodCallBase<TService, IMethodCallback> where TService : class
    {
        private MethodCall0(Expression<Action<TService>> runMethod) : base(runMethod)
        {
        }

        public static IMethodCallInitialTemplate<TService, IMethodCallback> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall0<TService>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallback> Complete()
        {
            Callbacks.Add(
                CallbackBuilder<ActionWrapper, MethodCallbackTemplate, IMethodCallback>.CreateCallbackBuilder()
                    .WithDefaultAction());
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallback> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallback(() => { }, exception));
            return this;
        }

        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    public class MethodCall1<TService, T> : MethodCallBase<TService, IMethodCallback<T>> where TService : class
    {
        private MethodCall1(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallInitialTemplate<TService, IMethodCallback<T>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall1<TService, T>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallback<T>> Complete()
        {
            Callbacks.Add(
                CallbackBuilder<ActionWrapper<T>, MethodCallbackTemplate<T>, IMethodCallback<T>>.CreateCallbackBuilder()
                    .WithDefaultAction());
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallback<T>> Throw(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    public class MethodCall2<TService, T1, T2> : MethodCallBase<TService, IMethodCallback<T1, T2>> where TService : class
    {
        private MethodCall2(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall2<TService, T1, T2>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallback<T1, T2>> Complete()
        {
            Callbacks.Add(
              CallbackBuilder<ActionWrapper<T1, T2>, MethodCallbackTemplate<T1, T2>, IMethodCallback<T1, T2>>.CreateCallbackBuilder()
                  .WithDefaultAction());
            return this;
        }

        public override IMethodCallbacksContainer<IMethodCallback<T1, T2>> Throw(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    public class MethodCall3<TService, T1, T2, T3> : MethodCallBase<TService, IMethodCallback<T1, T2, T3>> where TService : class
    {
        private MethodCall3(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall3<TService, T1, T2, T3>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3>> Complete()
        {
            throw new NotImplementedException();
        }

        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3>> Throw(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    public class MethodCall4<TService, T1, T2, T3, T4> : MethodCallBase<TService, IMethodCallback<T1, T2, T3, T4>> where TService : class
    {
        private MethodCall4(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        public static IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall4<TService, T1, T2, T3, T4>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4>> Complete()
        {
            throw new NotImplementedException();
        }

        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4>> Throw(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }

    public class MethodCall5<TService, T1, T2, T3, T4, T5> : MethodCallBase<TService, IMethodCallback<T1, T2, T3, T4, T5>> where TService : class
    {
        private MethodCall5(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3, T4, T5>> CreateMethodCall(Expression<Action<TService>> runMethod)
        {
            return new MethodCall5<TService, T1, T2, T3, T4, T5>(runMethod);
        }

        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4, T5>> Complete()
        {
            throw new NotImplementedException();
        }

        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4, T5>> Throw(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override void Accept(IMethodCallVisitor<TService> visitor)
        {
            visitor.Visit(this);
        }
    }
}