using System;
using System.Linq;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Represents visitor for different callbacks with return value and no parameters
    /// </summary>
    class MethodCallbackWithResultVisitor<TResult> : IMethodCallbackWithResultVisitor<TResult>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        public TResult Visit(OnErrorCallbackWithResult<TResult> onErrorCallback)
        {
            return MethodCallbackWithResultVisitorHelper.VisitErrorWithResult<TResult>(onErrorCallback);
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="CancelCallbackException"></exception>
        public TResult Visit(OnCancelCallbackWithResult<TResult> onCancelCallback)
        {
            return MethodCallbackWithResultVisitorHelper.VisitCancelWithResult<TResult>();
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        public TResult Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult)
        {
            return onCompleteCallbackWithResult.ValueFunction();
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="System.NotSupportedException">Value-returning calls with progress messages are not supported</exception>
        public TResult Visit(ProgressCallbackWithResult<TResult> progressCallback)
        {
            return MethodCallbackWithResultVisitorHelper.VisitProgressWithResult(progressCallback, c => c.Accept(this));            
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="WithoutCallbackException"></exception>
        public TResult Visit(OnWithoutCallbackWithResult<TResult> withoutCallback)
        {
            return MethodCallbackWithResultVisitorHelper.VisitWithoutWithResult<TResult>();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks with return value and one parameter.
    /// </summary>
    class MethodCallbackWithResultVisitor<T, TResult> : IMethodCallbackWithResultVisitor<T, TResult>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>
        /// Return value
        /// </returns>
        public TResult Visit(OnErrorCallbackWithResult<T, TResult> onErrorCallback, T arg)
        {
            return MethodCallbackWithResultVisitorHelper.VisitErrorWithResult<TResult>(onErrorCallback);
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="CancelCallbackException"></exception>
        public TResult Visit(OnCancelCallbackWithResult<T, TResult> onCancelCallback, T arg)
        {
            return MethodCallbackWithResultVisitorHelper.VisitCancelWithResult<TResult>();
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>
        /// Return value
        /// </returns>
        public TResult Visit(OnCompleteCallbackWithResult<T, TResult> onCompleteCallbackWithResult, T arg)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg);
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="System.NotSupportedException">Value-returning calls with progress messages are not supported</exception>
        public TResult Visit(ProgressCallbackWithResult<T, TResult> progressCallback, T arg)
        {
            return MethodCallbackWithResultVisitorHelper.VisitProgressWithResult(progressCallback,
                c => c.Accept(this, arg));            
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        /// <returns>
        /// Return value
        /// </returns>
        /// <exception cref="WithoutCallbackException"></exception>
        public TResult Visit(OnWithoutCallbackWithResult<T, TResult> withoutCallback, T arg)
        {
            return MethodCallbackWithResultVisitorHelper.VisitWithoutWithResult<TResult>();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks with return value and two parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    class MethodCallbackWithResultVisitor<T1, T2, TResult> : IMethodCallbackWithResultVisitor<T1, T2, TResult>
    {
        /// <summary>
        /// Visits the specified error-throwing callback.
        /// </summary>
        /// <param name="onErrorCallback">The error-throwing callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnErrorCallbackWithResult<T1, T2, TResult> onErrorCallback, T1 arg1, T2 arg2)
        {
            return MethodCallbackWithResultVisitorHelper.VisitErrorWithResult<TResult>(onErrorCallback);
        }

        /// <summary>
        /// Visits the specified cancellation callback.
        /// </summary>
        /// <param name="onCancelCallback">The cancellation callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <returns></returns>
        /// <exception cref="CancelCallbackException"></exception>
        public TResult Visit(OnCancelCallbackWithResult<T1, T2, TResult> onCancelCallback, T1 arg1, T2 arg2)
        {
            return MethodCallbackWithResultVisitorHelper.VisitCancelWithResult<TResult>();
        }

        /// <summary>
        /// Visits the specified successful completion callback.
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">The successful completion callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnCompleteCallbackWithResult<T1, T2, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg1, arg2);
        }

        /// <summary>
        /// Visits the specified progress callback.
        /// </summary>
        /// <param name="progressCallback">The progress callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">Value-returning calls with progress messages are not supported</exception>
        public TResult Visit(ProgressCallbackWithResult<T1, T2, TResult> progressCallback, T1 arg1, T2 arg2)
        {
            return MethodCallbackWithResultVisitorHelper.VisitProgressWithResult(progressCallback,
                c => c.Accept(this, arg1, arg2));            
        }

        /// <summary>
        /// Visits the specified never-ending callback.
        /// </summary>
        /// <param name="onWithoutCallback">The never-ending callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <returns></returns>
        /// <exception cref="WithoutCallbackException"></exception>
        public TResult Visit(OnWithoutCallbackWithResult<T1, T2, TResult> onWithoutCallback, T1 arg1, T2 arg2)
        {
            return MethodCallbackWithResultVisitorHelper.VisitWithoutWithResult<TResult>();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks with return value and three parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    class MethodCallbackWithResultVisitor<T1, T2, T3, TResult> : IMethodCallbackWithResultVisitor<T1, T2, T3, TResult>
    {
        /// <summary>
        /// Visits the specified error-throwing callback.
        /// </summary>
        /// <param name="onErrorCallback">The error-throwing callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            throw onErrorCallback.Exception;
        }

        /// <summary>
        /// Visits the specified cancellation callback.
        /// </summary>
        /// <param name="onCancelCallback">The cancellation callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            throw new CancelCallbackException();
        }

        /// <summary>
        /// Visits the specified successful completion callback.
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">The successful completion callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The second parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg1, arg2, arg3);
        }

        /// <summary>
        /// Visits the specified progress callback.
        /// </summary>
        /// <param name="progressCallback">The progress callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <returns></returns>
        public TResult Visit(ProgressCallbackWithResult<T1, T2, T3, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return progressCallback.FinishCallback.Accept(this, arg1, arg2, arg3);
        }

        /// <summary>
        /// Visits the specified never-ending callback.
        /// </summary>
        /// <param name="onWithoutCallback">The never-ending callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            throw new WithoutCallbackException();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks with return value and four parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    class MethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult> : IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult>
    {
        /// <summary>
        /// Visits the specified error-throwing callback.
        /// </summary>
        /// <param name="onErrorCallback">The error-throwing callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, T4, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return MethodCallbackWithResultVisitorHelper.VisitErrorWithResult<TResult>(onErrorCallback);
        }

        /// <summary>
        /// Visits the specified cancellation callback.
        /// </summary>
        /// <param name="onCancelCallback">The cancellation callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <returns></returns>
        /// <exception cref="CancelCallbackException"></exception>
        public TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, T4, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return MethodCallbackWithResultVisitorHelper.VisitCancelWithResult<TResult>();
        }

        /// <summary>
        /// Visits the specified successful completion callback.
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">The successful completion callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The second parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// Visits the specified progress callback.
        /// </summary>
        /// <param name="progressCallback">The progress callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">Value-returning calls with progress messages are not supported</exception>
        public TResult Visit(ProgressCallbackWithResult<T1, T2, T3, T4, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return MethodCallbackWithResultVisitorHelper.VisitProgressWithResult(progressCallback,
                c => c.Accept(this, arg1, arg2, arg3, arg4));
        }

        /// <summary>
        /// Visits the specified never-ending callback.
        /// </summary>
        /// <param name="onWithoutCallback">The never-ending callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <returns></returns>
        /// <exception cref="WithoutCallbackException"></exception>
        public TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, T4, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return MethodCallbackWithResultVisitorHelper.VisitWithoutWithResult<TResult>();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks with return value and five parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    class MethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult> : IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult>
    {
        /// <summary>
        /// Visits the specified error-throwing callback.
        /// </summary>
        /// <param name="onErrorCallback">The error-throwing callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return MethodCallbackWithResultVisitorHelper.VisitErrorWithResult<TResult>(onErrorCallback);
        }

        /// <summary>
        /// Visits the specified cancellation callback.
        /// </summary>
        /// <param name="onCancelCallback">The cancellation callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        /// <returns></returns>
        /// <exception cref="CancelCallbackException"></exception>
        public TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return MethodCallbackWithResultVisitorHelper.VisitCancelWithResult<TResult>();
        }

        /// <summary>
        /// Visits the specified successful completion callback.
        /// </summary>
        /// <param name="onCompleteCallbackWithResult">The successful completion callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The second parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        /// <returns></returns>
        public TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>
        /// Visits the specified progress callback.
        /// </summary>
        /// <param name="progressCallback">The progress callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">Value-returning calls with progress messages are not supported</exception>
        public TResult Visit(ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return MethodCallbackWithResultVisitorHelper.VisitProgressWithResult(progressCallback,
                c => c.Accept(this, arg1, arg2, arg3, arg4, arg5));           
        }

        /// <summary>
        /// Visits the specified never-ending callback.
        /// </summary>
        /// <param name="onWithoutCallback">The never-ending callback.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        /// <returns></returns>
        /// <exception cref="WithoutCallbackException"></exception>
        public TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, T4, T5, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return MethodCallbackWithResultVisitorHelper.VisitWithoutWithResult<TResult>();
        }
    }
}