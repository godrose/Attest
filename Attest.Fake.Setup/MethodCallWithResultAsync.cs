using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Base class for method calls with return value.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public abstract class MethodCallWithResultBaseAsync<TService, TCallback, TResult> :
        MethodCallbacksContainerBase<TCallback>,
        IAddCallbackWithResultShared<TCallback>,
        IMethodCallWithResultAsync<TService, TCallback, TResult> where TService : class
    {
        /// <summary>
        /// Method to be called
        /// </summary>
        public Expression<Func<TService, Task<TResult>>> RunMethod { get; private set; }

        /// <summary>
        /// Gets the run method description.
        /// </summary>
        /// <value>
        /// The run method description.
        /// </value>
        public override sealed string RunMethodDescription { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallWithResultBase{TService, TCallback, TResult}"/> class.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        protected MethodCallWithResultBaseAsync(Expression<Func<TService, Task<TResult>>> runMethod)
        {
            RunMethod = runMethod;
            RunMethodDescription = RunMethod.ToString();
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public abstract void Accept(IMethodCallWithResultVisitorAsync<TService> visitor);
    }

    /// <summary>
    /// Represents method call with return value.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>   
    public class MethodCallWithResultAsync<TService, TResult> :
        MethodCallWithResultBaseAsync<TService, IMethodCallbackWithResult<TResult>, TResult>,
        IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<TResult>, TResult>,
        IHaveNoCallbacksWithResult<IMethodCallbackWithResult<TResult>, TResult> where TService : class
    {
        private MethodCallWithResultAsync(Expression<Func<TService, Task<TResult>>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates the method call using the specified run method.
        /// </summary>
        /// <param name="runMethod">The specified run method.</param>
        /// <returns></returns>
        public static IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<TResult>, TResult> CreateMethodCall(Expression<Func<TService, Task<TResult>>> runMethod)
        {
            return new MethodCallWithResultAsync<TService, TResult>(runMethod);
        }

        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<TResult>, TResult> AddCallback(IMethodCallbackWithResult<TResult> methodCallback)
        {
            AddCallbackInternal(methodCallback);
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<TResult>, TResult> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<TResult>(result));
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<TResult>, TResult> Complete(Func<TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<TResult>(valueFunction));
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<TResult>, TResult> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<TResult>(exception));
            return this;
        }

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<TResult>, TResult> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<TResult>.Create().WithoutCallback().AsMethodCallback());
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallWithResultVisitorAsync<TService> visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<TResult>, TResult> BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<TResult>, TResult>, IHaveCallbacks<IMethodCallbackWithResult<TResult>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }
    }

    /// <summary>
    /// Represents method call with return value and 1 parameter.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T">The type of the parameter.</typeparam> 
    /// <typeparam name="TResult">The type of the return value.</typeparam>    
    public class MethodCallWithResultAsync<TService, T, TResult> :
        MethodCallWithResultBaseAsync<TService, IMethodCallbackWithResult<T, TResult>, TResult>,
        IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T, TResult>, T, TResult>,
        IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>,
        IGenerateMethodCallbackWithResult<T> where TService : class
    {
        private Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>, T, IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>> _callbacksProducer;

        private MethodCallWithResultAsync(Expression<Func<TService, Task<TResult>>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates the method call using the specified run method.
        /// </summary>
        /// <param name="runMethod">The specified run method.</param>
        /// <returns></returns>
        public static IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T, TResult>, T, TResult> 
            CreateMethodCall(Expression<Func<TService, Task<TResult>>> runMethod)
        {
            return new MethodCallWithResultAsync<TService, T, TResult>(runMethod);
        }

        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult> AddCallback(IMethodCallbackWithResult<T, TResult> methodCallback)
        {
            AddCallbackInternal(methodCallback);
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T, TResult>(result));
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult> Complete(Func<T, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T, TResult>(valueFunction));
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T, TResult>(exception));
            return this;
        }

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T, TResult>.Create().WithoutCallback().AsMethodCallback());
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(IMethodCallWithResultVisitorAsync<TService> visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>
        /// Builds the method call with return value from the specified build callbacks.
        /// </summary>
        /// <param name="buildCallbacks">The build callbacks.</param>
        /// <returns></returns>
        public IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T, TResult>, TResult>
            BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }

        IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T, TResult>, TResult> 
            IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T, TResult>, T, TResult>
            .BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T, TResult>, T, TResult>, T, 
                IHaveCallbacks<IMethodCallbackWithResult<T, TResult>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        bool IGenerateMethodCallbackConditionChecker.CanGenerateCallback
        {
            get { return _callbacksProducer != null; }
        }

        void IGenerateMethodCallbackWithResult<T>.GenerateCallback(T arg)
        {
            _callbacksProducer(this, arg);
        }
    }

}