using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Base class for async method calls with return value.
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
    /// Represents async method call with return value.
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
    /// Represents async method call with return value and one parameter.
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

    /// <summary>
    /// Represents async method call with return value and two parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam> 
    /// <typeparam name="T2">The type of the second parameter.</typeparam> 
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class MethodCallWithResultAsync<TService, T1, T2, TResult> :
        MethodCallWithResultBaseAsync<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult>,
        IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>,
        IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>,
        IGenerateMethodCallbackWithResult<T1, T2> where TService : class
    {
        private Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, T1, T2, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>> _callbacksProducer;

        private MethodCallWithResultAsync(Expression<Func<TService, Task<TResult>>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates the method call using the specified run method.
        /// </summary>
        /// <param name="runMethod">The specified run method.</param>
        /// <returns></returns>
        public static IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, TResult>, 
            T1, T2, TResult> CreateMethodCall(Expression<Func<TService, Task<TResult>>> runMethod)
        {
            return new MethodCallWithResultAsync<TService, T1, T2, TResult>(runMethod);
        }

        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult> AddCallback(
            IMethodCallbackWithResult<T1, T2, TResult> methodCallback)
        {
            AddCallbackInternal(methodCallback);
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, TResult>(result));
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult> Complete(Func<T1, T2, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, TResult>(valueFunction));
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, TResult>(exception));
            return this;
        }

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T1, T2, TResult>.Create().WithoutCallback().AsMethodCallback());
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
        public IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult>
            BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>,
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }

        IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, TResult>, TResult> 
            IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>
            .BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, TResult>, T1, T2, TResult>, 
                T1, T2, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, TResult>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        bool IGenerateMethodCallbackConditionChecker.CanGenerateCallback
        {
            get { return _callbacksProducer != null; }
        }

        void IGenerateMethodCallbackWithResult<T1, T2>.GenerateCallback(T1 arg1, T2 arg2)
        {
            _callbacksProducer(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represents async method call with return value and three parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam> 
    /// <typeparam name="T2">The type of the second parameter.</typeparam> 
    /// <typeparam name="T3">The type of the third parameter.</typeparam> 
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class MethodCallWithResultAsync<TService, T1, T2, T3, TResult> :
        MethodCallWithResultBaseAsync<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult>,
        IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>,
        IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>,
        IGenerateMethodCallbackWithResult<T1, T2, T3> where TService : class
    {
        private Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, T1, T2, T3, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>> _callbacksProducer;

        private MethodCallWithResultAsync(Expression<Func<TService, Task<TResult>>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates the method call using the specified run method.
        /// </summary>
        /// <param name="runMethod">The specified run method.</param>
        /// <returns></returns>
        public static IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, 
            T1, T2, T3, TResult> CreateMethodCall(Expression<Func<TService, Task<TResult>>> runMethod)
        {
            return new MethodCallWithResultAsync<TService, T1, T2, T3, TResult>(runMethod);
        }

        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult> AddCallback(
            IMethodCallbackWithResult<T1, T2, T3, TResult> methodCallback)
        {
            AddCallbackInternal(methodCallback);
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, TResult>(result));
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult> Complete(Func<T1, T2, T3, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, TResult>(valueFunction));
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, T3, TResult>(exception));
            return this;
        }

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T1, T2, T3, TResult>.Create().WithoutCallback().AsMethodCallback());
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
        public IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, 
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }

        IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> 
            IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>.BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, T1, T2, T3, TResult>, T1, T2, T3, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, TResult>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        bool IGenerateMethodCallbackConditionChecker.CanGenerateCallback
        {
            get { return _callbacksProducer != null; }
        }

        void IGenerateMethodCallbackWithResult<T1, T2, T3>.GenerateCallback(T1 arg1, T2 arg2, T3 arg3)
        {
            _callbacksProducer(this, arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Represents async method call with return value and four parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam> 
    /// <typeparam name="T2">The type of the second parameter.</typeparam> 
    /// <typeparam name="T3">The type of the third parameter.</typeparam> 
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam> 
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class MethodCallWithResultAsync<TService, T1, T2, T3, T4, TResult> :
        MethodCallWithResultBaseAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult>,
        IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, 
            T1, T2, T3, T4, TResult>,
        IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>,
        IGenerateMethodCallbackWithResult<T1, T2, T3, T4>
        where TService : class
    {
        private Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, 
            T1, T2, T3, T4, TResult>, 
            T1, T2, T3, T4, 
            IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>> _callbacksProducer;

        private MethodCallWithResultAsync(Expression<Func<TService, Task<TResult>>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates the method call using the specified run method.
        /// </summary>
        /// <param name="runMethod">The specified run method.</param>
        /// <returns></returns>
        public static IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>,
            T1, T2, T3, T4, TResult> CreateMethodCall(Expression<Func<TService, Task<TResult>>> runMethod)
        {
            return new MethodCallWithResultAsync<TService, T1, T2, T3, T4, TResult>(runMethod);
        }

        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> AddCallback(
            IMethodCallbackWithResult<T1, T2, T3, T4, TResult> methodCallback)
        {
            AddCallbackInternal(methodCallback);
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult>(result));
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> Complete(Func<T1, T2, T3, T4, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult>(valueFunction));
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, T3, T4, TResult>(exception));
            return this;
        }

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T1, T2, T3, T4, TResult>.Create().WithoutCallback().AsMethodCallback());
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
        public IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, 
                T1, T2, T3, T4, TResult>, 
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }

        IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> 
            IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, 
                T1, T2, T3, T4, TResult>.BuildCallbacks(Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>, T1, T2, T3, T4, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        bool IGenerateMethodCallbackConditionChecker.CanGenerateCallback
        {
            get { return _callbacksProducer != null; }
        }

        void IGenerateMethodCallbackWithResult<T1, T2, T3, T4>.GenerateCallback(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            _callbacksProducer(this, arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Represents async method call with return value and five parameters.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="T1">The type of the first parameter.</typeparam> 
    /// <typeparam name="T2">The type of the second parameter.</typeparam> 
    /// <typeparam name="T3">The type of the third parameter.</typeparam> 
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam> 
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam> 
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class MethodCallWithResultAsync<TService, T1, T2, T3, T4, T5, TResult> :
        MethodCallWithResultBaseAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult>,
        IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>,
        IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>,
        IGenerateMethodCallbackWithResult<T1, T2, T3, T4, T5> where TService : class
    {
        private Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>> _callbacksProducer;

        private MethodCallWithResultAsync(Expression<Func<TService, Task<TResult>>> runMethod)
            : base(runMethod)
        {
        }

        /// <summary>
        /// Creates the method call using the specified run method.
        /// </summary>
        /// <param name="runMethod">The specified run method.</param>
        /// <returns></returns>
        public static IMethodCallWithResultInitialTemplateAsync<TService,
            IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, 
            T1, T2, T3, T4, T5, TResult> CreateMethodCall(Expression<Func<TService, Task<TResult>>> runMethod)
        {
            return new MethodCallWithResultAsync<TService, T1, T2, T3, T4, T5, TResult>(runMethod);
        }

        /// <summary>
        /// Adds custom callback to the callbacks container
        /// </summary>
        /// <param name="methodCallback">Custom callback</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> AddCallback(
            IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult> methodCallback)
        {
            AddCallbackInternal(methodCallback);
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="result">Successful completion return value</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> Complete(TResult result)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult>(result));
            return this;
        }

        /// <summary>
        /// Adds successful completion callback to the callbacks container
        /// </summary>
        /// <param name="valueFunction">Successful completion return value's function</param>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> Complete(Func<T1, T2, T3, T4, T5, TResult> valueFunction)
        {
            Callbacks.Add(new OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult>(valueFunction));
            return this;
        }

        /// <summary>
        /// Adds exception throwing callback to the callbacks container
        /// </summary>
        /// <param name="exception">Exception to be thrown</param>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> Throw(Exception exception)
        {
            Callbacks.Add(new OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult>(exception));
            return this;
        }

        /// <summary>
        /// Adds never-ending callback to the callbacks container
        /// </summary>
        /// <returns>Callbacks container</returns>
        public IAddCallbackWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> WithoutCallback()
        {
            Callbacks.Add(ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult>.Create().WithoutCallback().AsMethodCallback());
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
        public IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, 
                T1, T2, T3, T4, T5, TResult>, 
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>> buildCallbacks)
        {
            buildCallbacks(this);
            return this;
        }

        IMethodCallWithResultAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> 
            IMethodCallWithResultInitialTemplateAsync<TService, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, 
                T1, T2, T3, T4, T5, TResult>.BuildCallbacks(
            Func<IHaveNoCallbacksWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, 
                T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, 
                IHaveCallbacks<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>>> callbacksProducer)
        {
            _callbacksProducer = callbacksProducer;
            return this;
        }

        bool IGenerateMethodCallbackConditionChecker.CanGenerateCallback
        {
            get { return _callbacksProducer != null; }
        }

        void IGenerateMethodCallbackWithResult<T1, T2, T3, T4, T5>.GenerateCallback(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            _callbacksProducer(this, arg1, arg2, arg3, arg4, arg5);
        }
    }
}