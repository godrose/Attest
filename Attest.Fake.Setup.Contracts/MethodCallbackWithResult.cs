using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Base class for callback with return value and no parameters
    /// </summary>
    /// <typeparam name="TResult">The type of the return value</typeparam>
    public abstract class MethodCallbackBaseWithResult<TResult> : IMethodCallbackWithResult<TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor);
    }

    /// <summary>
    /// Base class for callback with return value and 1 parameter
    /// </summary>
    /// <typeparam name="T">The type of the parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value</typeparam>
    public abstract class MethodCallbackBaseWithResult<T, TResult> : IMethodCallbackWithResult<T, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg">The argument.</param>
        /// <returns/>
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<T, TResult> visitor, T arg);
    }

    /// <summary>
    /// Base class for callback with return value and 2 parameters
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value</typeparam>
    public abstract class MethodCallbackBaseWithResult<T1, T2, TResult> : IMethodCallbackWithResult<T1, T2, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param>
        /// <returns/>
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, TResult> visitor, T1 arg1, T2 arg2);
    }

    /// <summary>
    /// Base class for callback with return value and 3 parameters
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value</typeparam>
    public abstract class MethodCallbackBaseWithResult<T1, T2, T3, TResult> : IMethodCallbackWithResult<T1, T2, T3, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param>
        /// <returns/>
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, TResult> visitor, T1 arg1, T2 arg2, T3 arg3);
    }

    /// <summary>
    /// Base class for callback with return value and 4 parameters
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value</typeparam>
    public abstract class MethodCallbackBaseWithResult<T1, T2, T3, T4, TResult> : IMethodCallbackWithResult<T1, T2, T3, T4, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param>
        /// <returns/>
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    /// <summary>
    /// Base class for callback with return value and 5 parameters
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value</typeparam>
    public abstract class MethodCallbackBaseWithResult<T1, T2, T3, T4, T5, TResult> : IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param><param name="arg5">The fifth argument.</param>
        /// <returns/>
        public abstract TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }

    /// <summary>
    /// Represents successful completion callback with return value.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.MethodCallbackBaseWithResult{TResult}" />
    public class OnCompleteCallbackWithResult<TResult> :
        MethodCallbackBaseWithResult<TResult>
    {
        internal Func<TResult> ValueFunction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{TResult}"/> class.
        /// </summary>
        /// <param name="valueFunction">The value function.</param>
        public OnCompleteCallbackWithResult(Func<TResult> valueFunction)
        {
            ValueFunction = valueFunction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{TResult}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public OnCompleteCallbackWithResult(TResult result)
            :this(() => result)
        {            
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents successful completion callback with return value and 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.MethodCallbackBaseWithResult{T, TResult}" />
    public class OnCompleteCallbackWithResult<T, TResult> : MethodCallbackBaseWithResult<T, TResult>
    {
        internal Func<T, TResult> ValueFunction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T, TResult}"/> class.
        /// </summary>
        /// <param name="result">The expected return value</param>
        public OnCompleteCallbackWithResult(TResult result)
            :this(arg => result)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T, TResult}"/> class.
        /// </summary>
        /// <param name="valueFunction">The return value producer.</param>
        public OnCompleteCallbackWithResult(Func<T, TResult> valueFunction)
        {
            ValueFunction = valueFunction;            
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg">The argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T, TResult> visitor, T arg)
        {
            return visitor.Visit(this, arg);
        }
    }

    /// <summary>
    /// Represents successful completion callback with return value and 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.MethodCallbackBaseWithResult{T1, T2, TResult}" />
    public class OnCompleteCallbackWithResult<T1, T2, TResult> : MethodCallbackBaseWithResult<T1, T2, TResult>
    {
        internal Func<T1, T2, TResult> ValueFunction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T1, T2, TResult}"/> class.
        /// </summary>
        /// <param name="result">The expected return value.</param>
        public OnCompleteCallbackWithResult(TResult result)
            : this((arg1, arg2) => result)
        {            
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T1, T2, TResult}"/> class.
        /// </summary>
        /// <param name="valueFunction">The return value producer</param>
        public OnCompleteCallbackWithResult(Func<T1, T2, TResult> valueFunction)
        {
            ValueFunction = valueFunction;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, TResult> visitor, T1 arg1, T2 arg2)
        {
            return visitor.Visit(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represents successful completion callback with return value and 3 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.MethodCallbackBaseWithResult{T1, T2, T3, TResult}" />
    public class OnCompleteCallbackWithResult<T1, T2, T3, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, TResult>
    {
        internal Func<T1, T2, T3, TResult> ValueFunction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T1, T2, T3, TResult}"/> class.
        /// </summary>
        /// <param name="result">The expected return value.</param>
        public OnCompleteCallbackWithResult(TResult result)
            : this((arg1, arg2, arg3) => result)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T1, T2, T3, TResult}"/> class.
        /// </summary>
        /// <param name="valueFunction">The return value producer function.</param>
        public OnCompleteCallbackWithResult(Func<T1, T2, T3, TResult> valueFunction)
        {
            ValueFunction = valueFunction;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, TResult> visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            return visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Represents successful completion callback with return value and 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.MethodCallbackBaseWithResult{T1, T2, T3, T4, TResult}" />
    public class OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, T4, TResult>        
    {
        internal Func<T1, T2, T3, T4, TResult> ValueFunction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T1, T2, T3, T4, TResult}"/> class.
        /// </summary>
        /// <param name="result">The expected return value.</param>
        public OnCompleteCallbackWithResult(TResult result)
            : this((arg1, arg2, arg3, arg4) => result)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T1, T2, T3, T4, TResult}"/> class.
        /// </summary>
        /// <param name="valueFunction">The return value producer function.</param>
        public OnCompleteCallbackWithResult(Func<T1, T2, T3, T4, TResult> valueFunction)
        {
            ValueFunction = valueFunction;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Represents successful completion callback with return value and 5 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter</typeparam>
    /// <typeparam name="T2">The type of the second parameter</typeparam>
    /// <typeparam name="T3">The type of the third parameter</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.MethodCallbackBaseWithResult{T1, T2, T3, T4, T5, TResult}" />
    public class OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, T4, T5, TResult>        
    {
        internal Func<T1, T2, T3, T4, T5, TResult> ValueFunction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T1, T2, T3, T4, T5, TResult}"/> class.
        /// </summary>
        /// <param name="result">The expected return value.</param>
        public OnCompleteCallbackWithResult(TResult result)
            : this((arg1, arg2, arg3, arg4, arg5) => result)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCompleteCallbackWithResult{T1, T2, T3, T4, T5, TResult}"/> class.
        /// </summary>
        /// <param name="valueFunction">The return value producer function.</param>
        public OnCompleteCallbackWithResult(Func<T1, T2, T3, T4, T5, TResult> valueFunction)
        {
            ValueFunction = valueFunction;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }

    /// <summary>
    /// Represents error-throwing callback with return value.    
    /// </summary>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    /// <seealso cref="Contracts.MethodCallbackBaseWithResult{TResult}" />
    public class OnErrorCallbackWithResult<TResult> : MethodCallbackBaseWithResult<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallbackWithResult{TResult}"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents error-throwing callback with return value and 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnErrorCallbackWithResult<T, TResult> : MethodCallbackBaseWithResult<T, TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallbackWithResult{T, TResult}"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg">The argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T, TResult> visitor, T arg)
        {
            return visitor.Visit(this, arg);
        }
    }

    /// <summary>
    /// Represents error-throwing callback with return value and 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnErrorCallbackWithResult<T1, T2, TResult> : MethodCallbackBaseWithResult<T1, T2, TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallbackWithResult{T1, T2, TResult}"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, TResult> visitor, T1 arg1, T2 arg2)
        {
            return visitor.Visit(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represents error-throwing callback with return value and 3 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnErrorCallbackWithResult<T1, T2, T3, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallbackWithResult{T1, T2, TResult}"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, TResult> visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            return visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Represents error-throwing callback with return value and 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnErrorCallbackWithResult<T1, T2, T3, T4, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, T4, TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallbackWithResult{T1, T2, T3, T4, TResult}"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Represents error-throwing callback with return value and 5 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, T4, T5, TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnErrorCallbackWithResult{T1, T2, T3, T4, T5, TResult}"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public OnErrorCallbackWithResult(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param><param name="arg5">The fifth argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }    

    /// <summary>
    /// Represents cancellation callback with return value.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class OnCancelCallbackWithResult<TResult> : MethodCallbackBaseWithResult<TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents cancellation callback with return value and 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnCancelCallbackWithResult<T, TResult> : MethodCallbackBaseWithResult<T, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg">The argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T, TResult> visitor, T arg)
        {
            return visitor.Visit(this, arg);
        }
    }

    /// <summary>
    /// Represents cancellation callback with return value and 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnCancelCallbackWithResult<T1, T2, TResult> : MethodCallbackBaseWithResult<T1, T2, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, TResult> visitor, T1 arg1, T2 arg2)
        {
            return visitor.Visit(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represents cancellation callback with return value and 3 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnCancelCallbackWithResult<T1, T2, T3, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, TResult> visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            return visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Represents cancellation callback with return value and 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnCancelCallbackWithResult<T1, T2, T3, T4, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, T4, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Represents cancellation callback with return value and 5 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnCancelCallbackWithResult<T1, T2, T3, T4, T5, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, T4, T5, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }

    /// <summary>
    /// Represents never-ending callback with return value.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnWithoutCallbackWithResult<TResult> : MethodCallbackBaseWithResult<TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represents never-ending callback with return value and 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnWithoutCallbackWithResult<T, TResult> : MethodCallbackBaseWithResult<T, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg">The argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T, TResult> visitor, T arg)
        {
            return visitor.Visit(this, arg);
        }
    }

    /// <summary>
    /// Represents never-ending callback with return value and 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnWithoutCallbackWithResult<T1, T2, TResult> : MethodCallbackBaseWithResult<T1, T2, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, TResult> visitor, T1 arg1, T2 arg2)
        {
            return visitor.Visit(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represents never-ending callback with return value and 3 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnWithoutCallbackWithResult<T1, T2, T3, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, TResult> visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            return visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Represents never-ending callback with return value and 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnWithoutCallbackWithResult<T1, T2, T3, T4, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, T4, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Represents never-ending callback with return value and 5 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class OnWithoutCallbackWithResult<T1, T2, T3, T4, T5, TResult> : MethodCallbackBaseWithResult<T1, T2, T3, T4, T5, TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <returns/>
        public override TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }

    //unfortunately this case can't be supported in the current model:
    //try-finally block can't both throw an exception and return a value
    //additionally it's rather strange to have progressable call return a value
    //when all the data can be just transferred over the progress messages path
    /// <summary>
    /// Base class for progress message callback with return value.
    /// </summary>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public abstract class ProgressCallbackWithResultBase<TCallback, TResult> :
        ProgressMessagesBase, 
        IProgressableProcessRunningWithResult<TCallback, TResult>, 
        IProgressableProcessFinishedWithResult<TCallback, TResult>
    {
        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public abstract IProgressableProcessFinishedWithResult<TCallback, TResult> Complete(TResult result);

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public abstract IProgressableProcessFinishedWithResult<TCallback, TResult> Throw(Exception exception);

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public abstract IProgressableProcessFinishedWithResult<TCallback, TResult> Cancel();

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public abstract IProgressableProcessFinishedWithResult<TCallback, TResult> WithoutCallback();

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
        public abstract TCallback AsMethodCallback();        
    }

    /// <summary>
    /// Represent progress message callback with return value.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class ProgressCallbackWithResult<TResult> : ProgressCallbackWithResultBase<IMethodCallbackWithResult<TResult>, TResult>, IMethodCallbackWithResult<TResult>
    {
        private ProgressCallbackWithResult()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ProgressCallbackWithResult{TResult}"/>
        /// </summary>
        /// <returns></returns>
        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult<TResult>();
        }

        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<TResult>(result);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<TResult>(exception);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<TResult>();
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<TResult>();
            return this;
        }

        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        public override IMethodCallbackWithResult<TResult> AsMethodCallback()
        {
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public TResult Accept(IMethodCallbackWithResultVisitor<TResult> visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    /// Represent progress message callback with return value and 1 parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class ProgressCallbackWithResult<T, TResult> : ProgressCallbackWithResultBase<IMethodCallbackWithResult<T, TResult>, TResult>, IMethodCallbackWithResult<T, TResult>
    {
        private ProgressCallbackWithResult()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ProgressCallbackWithResult{T, TResult}"/>
        /// </summary>
        /// <returns></returns>
        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<T, TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult<T, TResult>();
        }

        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T, TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<T, TResult>(result);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T, TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<T, TResult>(exception);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T, TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<T, TResult>();
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T, TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<T, TResult>();
            return this;
        }

        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        public override IMethodCallbackWithResult<T, TResult> AsMethodCallback()
        {
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg">The argument.</param>
        /// <returns/>
        public TResult Accept(IMethodCallbackWithResultVisitor<T, TResult> visitor, T arg)
        {
            return visitor.Visit(this, arg);
        }
    }

    /// <summary>
    /// Represent progress message callback with return value and 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class ProgressCallbackWithResult<T1, T2, TResult> : ProgressCallbackWithResultBase<IMethodCallbackWithResult<T1, T2, TResult>, TResult>, IMethodCallbackWithResult<T1, T2, TResult>
    {
        private ProgressCallbackWithResult()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ProgressCallbackWithResult{T1, T2, TResult}"/>
        /// </summary>
        /// <returns></returns>
        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult<T1, T2, TResult>();
        }

        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<T1, T2, TResult>(result);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<T1, T2, TResult>(exception);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<T1, T2, TResult>();
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<T1, T2, TResult>();
            return this;
        }

        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        public override IMethodCallbackWithResult<T1, T2, TResult> AsMethodCallback()
        {
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <returns/>
        public TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, TResult> visitor, T1 arg1, T2 arg2)
        {
            return visitor.Visit(this, arg1, arg2);
        }
    }

    /// <summary>
    /// Represent progress message callback with return value and 3 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class ProgressCallbackWithResult<T1, T2, T3, TResult> : ProgressCallbackWithResultBase<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult>, IMethodCallbackWithResult<T1, T2, T3, TResult>
    {
        private ProgressCallbackWithResult()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ProgressCallbackWithResult{T1, T2, T3, TResult}"/>
        /// </summary>
        /// <returns></returns>
        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult<T1, T2, T3, TResult>();
        }

        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<T1, T2, T3, TResult>(result);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<T1, T2, T3, TResult>(exception);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<T1, T2, T3, TResult>();
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<T1, T2, T3, TResult>();
            return this;
        }

        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        public override IMethodCallbackWithResult<T1, T2, T3, TResult> AsMethodCallback()
        {
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <returns/>
        public TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, TResult> visitor, T1 arg1, T2 arg2, T3 arg3)
        {
            return visitor.Visit(this, arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Represent progress message callback with return value and 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class ProgressCallbackWithResult<T1, T2, T3, T4, TResult> : ProgressCallbackWithResultBase<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult>, IMethodCallbackWithResult<T1, T2, T3, T4, TResult>
    {
        private ProgressCallbackWithResult()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ProgressCallbackWithResult{T1, T2, T3, T4, TResult}"/>
        /// </summary>
        /// <returns></returns>
        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult<T1, T2, T3, T4, TResult>();
        }

        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult>(result);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<T1, T2, T3, T4, TResult>(exception);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<T1, T2, T3, T4, TResult>();
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<T1, T2, T3, T4, TResult>();
            return this;
        }

        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        public override IMethodCallbackWithResult<T1, T2, T3, T4, TResult> AsMethodCallback()
        {
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param><param name="arg1">The first argument.</param><param name="arg2">The second argument.</param><param name="arg3">The third argument.</param><param name="arg4">The fourth argument.</param>
        /// <returns/>
        public TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Represent progress message callback with return value and 5 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the return value.</typeparam>
    public class ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult> : ProgressCallbackWithResultBase<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult>, IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>
    {
        private ProgressCallbackWithResult()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ProgressCallbackWithResult{T1, T2, T3, T4, T5, TResult}"/>
        /// </summary>
        /// <returns></returns>
        public static IProgressableProcessRunningWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> Create()
        {
            return new ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult>();
        }

        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> Complete(TResult result)
        {
            FinishCallback = new OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult>(result);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> Throw(Exception exception)
        {
            FinishCallback = new OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult>(exception);
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> Cancel()
        {
            FinishCallback = new OnCancelCallbackWithResult<T1, T2, T3, T4, T5, TResult>();
            return this;
        }

        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        public override IProgressableProcessFinishedWithResult<IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult>, TResult> WithoutCallback()
        {
            FinishCallback = new OnWithoutCallbackWithResult<T1, T2, T3, T4, T5, TResult>();
            return this;
        }

        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        public override IMethodCallbackWithResult<T1, T2, T3, T4, T5, TResult> AsMethodCallback()
        {
            return this;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <returns/>
        public TResult Accept(IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult> visitor, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return visitor.Visit(this, arg1, arg2, arg3, arg4, arg5);
        }
    }
}