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
    /// <seealso cref="Attest.Fake.Setup.Contracts.IHaveNoCallbacks{TCallback}" />
    public abstract class MethodCallBase<TService, TCallback> : 
        MethodCallbacksContainerBase<TCallback>, 
        IMethodCall<TService, TCallback>,         
        IAddCallbackShared<TCallback>
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

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public abstract IMethodCallbacksContainer<TCallback> WithoutCallback();

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public abstract void Accept(IMethodCallVisitor<TService> visitor);
    }

    /// <summary>
    /// Represents method call without return value.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>    
    public class MethodCall<TService> : MethodCallBase<TService, IMethodCallback>,
        IMethodCallInitialTemplate<TService,IMethodCallback>,
        IHaveNoCallbacks<IMethodCallback> where TService : class
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

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback> WithoutCallback()
        {
            Callbacks.Add(ProgressCallback.Create().WithoutCallback().AsMethodCallback());
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

        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCall<TService, IMethodCallback> BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback>, IHaveCallbacks<IMethodCallback>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }
    }

    /// <summary>
    /// Represents method call without return value and 1 parameter.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T">The type of the parameter</typeparam>    
    public class MethodCall<TService, T> : 
        MethodCallBase<TService, IMethodCallback<T>>,
        IMethodCallInitialTemplate<TService, IMethodCallback<T>, T>,
        IHaveNoCallbacks<IMethodCallback<T>, T>,
        IGenerateMethodCallback<T> where TService : class
    {
        private Func<IHaveNoCallbacks<IMethodCallback<T>, T>, T, IHaveCallbacks<IMethodCallback<T>>> _callbacksProducer;

        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T>, T> CreateMethodCall(Expression<Action<TService>> runMethod)
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

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallback<T>.Create().WithoutCallback().AsMethodCallback());
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

        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCall<TService, IMethodCallback<T>> BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T>, T>, IHaveCallbacks<IMethodCallback<T>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }        

        IMethodCall<TService, IMethodCallback<T>> IMethodCallInitialTemplate<TService, IMethodCallback<T>, T>.BuildCallbacks(
            Func<IHaveNoCallbacks<IMethodCallback<T>, T>, T, IHaveCallbacks<IMethodCallback<T>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="callback">Successful completion callback</param>
        public IMethodCallbacksContainer<IMethodCallback<T>> Complete(Action<T> callback)
        {
            Callbacks.Add(new OnCompleteCallback<T>(callback));
            return this;
        }

        void IGenerateMethodCallback<T>.EvaluateArguments(T arg)
        {
            _callbacksProducer(this, arg);            
        }
    }

    /// <summary>
    /// Represents method call without return value and 2 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    public class MethodCall<TService, T1, T2> : 
        MethodCallBase<TService, IMethodCallback<T1, T2>>,
        IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2>, T1, T2>,
        IHaveNoCallbacks<IMethodCallback<T1, T2>, T1, T2>,
        IGenerateMethodCallback<T1, T2> where TService : class
    {
        private Func<IHaveNoCallbacks<IMethodCallback<T1, T2>, T1, T2>, T1, T2, IHaveCallbacks<IMethodCallback<T1, T2>>> _callbacksProducer;

        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T1, T2}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2>, T1, T2> CreateMethodCall(Expression<Action<TService>> runMethod)
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
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallback<T1, T2>.Create().WithoutCallback().AsMethodCallback());
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

        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCall<TService, IMethodCallback<T1, T2>> BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T1, T2>, T1, T2>, IHaveCallbacks<IMethodCallback<T1, T2>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }        

        IMethodCall<TService, IMethodCallback<T1, T2>> IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2>, T1, T2>.BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T1, T2>, T1, T2>, T1, T2, IHaveCallbacks<IMethodCallback<T1, T2>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="callback">Successful completion callback</param>
        public IMethodCallbacksContainer<IMethodCallback<T1, T2>> Complete(Action<T1, T2> callback)
        {
            Callbacks.Add(new OnCompleteCallback<T1, T2>(callback));
            return this;
        }

        void IGenerateMethodCallback<T1, T2>.EvaluateArguments(T1 arg1, T2 arg2)
        {
            _callbacksProducer(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represents method call without return value and 3 parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    public class MethodCall<TService, T1, T2, T3> : 
        MethodCallBase<TService, IMethodCallback<T1, T2, T3>>,
        IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3>, T1, T2, T3>,
        IHaveNoCallbacks<IMethodCallback<T1, T2, T3>, T1, T2, T3>,
        IGenerateMethodCallback<T1, T2, T3> where TService : class
    {
        private Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3>, T1, T2, T3>, T1, T2, T3, IHaveCallbacks<IMethodCallback<T1, T2, T3>>> _callbacksProducer;

        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T1, T2, T3}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3>, T1, T2, T3> CreateMethodCall(Expression<Action<TService>> runMethod)
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
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallback<T1, T2, T3>.Create().WithoutCallback().AsMethodCallback());
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

        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCall<TService, IMethodCallback<T1, T2, T3>> BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3>, T1, T2, T3>, IHaveCallbacks<IMethodCallback<T1, T2, T3>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }      

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="callback">Successful completion callback</param>
        public IMethodCallbacksContainer<IMethodCallback<T1, T2, T3>> Complete(Action<T1, T2, T3> callback)
        {
            Callbacks.Add(new OnCompleteCallback<T1, T2, T3>(callback));
            return this;
        }

        IMethodCall<TService, IMethodCallback<T1, T2, T3>> IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3>, T1, T2, T3>.BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3>, T1, T2, T3>, T1, T2, T3, IHaveCallbacks<IMethodCallback<T1, T2, T3>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        void IGenerateMethodCallback<T1, T2, T3>.EvaluateArguments(T1 arg1, T2 arg2, T3 arg3)
        {
            _callbacksProducer(this, arg1, arg2, arg3);
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
    public class MethodCall<TService, T1, T2, T3, T4> : 
        MethodCallBase<TService, IMethodCallback<T1, T2, T3, T4>>,
        IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>,
        IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>,
        IGenerateMethodCallback<T1, T2, T3, T4> where TService : class
    {
        private Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>, T1, T2, T3, T4, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4>>> _callbacksProducer;

        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T1, T2, T3, T4}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4> CreateMethodCall(Expression<Action<TService>> runMethod)
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
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallback<T1, T2, T3, T4>.Create().WithoutCallback().AsMethodCallback());
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

        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCall<TService, IMethodCallback<T1, T2, T3, T4>> BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }
        
        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="callback">Successful completion callback</param>
        public IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4>> Complete(Action<T1, T2, T3, T4> callback)
        {
            Callbacks.Add(new OnCompleteCallback<T1, T2, T3, T4>(callback));
            return this;
        }

        IMethodCall<TService, IMethodCallback<T1, T2, T3, T4>> IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>.BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4>, T1, T2, T3, T4>, T1, T2, T3, T4, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        void IGenerateMethodCallback<T1, T2, T3, T4>.EvaluateArguments(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            _callbacksProducer(this, arg1, arg2, arg3, arg4);
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
    public class MethodCall<TService, T1, T2, T3, T4, T5> : 
        MethodCallBase<TService, IMethodCallback<T1, T2, T3, T4, T5>>,
        IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>,
        IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>,
        IGenerateMethodCallback<T1, T2, T3, T4, T5> where TService : class
    {
        private Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4, T5>>> _callbacksProducer;

        private MethodCall(Expression<Action<TService>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MethodCall{TService, T1, T2, T3, T4, T5}" /> using the specified run method.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public static IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> CreateMethodCall(Expression<Action<TService>> runMethod)
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
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public override IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4, T5>> WithoutCallback()
        {
            Callbacks.Add(ProgressCallback<T1, T2, T3, T4, T5>.Create().WithoutCallback().AsMethodCallback());
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

        /// <summary>
        /// Builds the method call with specified callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCall<TService, IMethodCallback<T1, T2, T3, T4, T5>> BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4, T5>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }        

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="callback">Successful completion callback</param>
        public IMethodCallbacksContainer<IMethodCallback<T1, T2, T3, T4, T5>> Complete(Action<T1, T2, T3, T4, T5> callback)
        {
            Callbacks.Add(new OnCompleteCallback<T1, T2, T3, T4, T5>(callback));
            return this;
        }

        IMethodCall<TService, IMethodCallback<T1, T2, T3, T4, T5>> IMethodCallInitialTemplate<TService, IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>.BuildCallbacks(Func<IHaveNoCallbacks<IMethodCallback<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5, IHaveCallbacks<IMethodCallback<T1, T2, T3, T4, T5>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        void IGenerateMethodCallback<T1, T2, T3, T4, T5>.EvaluateArguments(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            _callbacksProducer(this, arg1, arg2, arg3, arg4, arg5);
        }
    }
}