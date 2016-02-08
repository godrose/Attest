using System;
using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that can add progress messages.
    /// </summary>
    public interface ICanAddProgressMessages
    {
        /// <summary>
        /// Adds the progress message.
        /// </summary>
        /// <param name="progressMessage">The progress message.</param>
        /// <returns></returns>
        ICanAddProgressMessages AddProgress(object progressMessage);
    }

    /// <summary>
    /// Represents an object that contains progress messages and has not completed yet.
    /// </summary>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <seealso cref="ICanAddProgressMessages" />
    public interface IProgressableProcessRunning<TCallback> : ICanAddProgressMessages
    {
        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        IProgressableProcessFinished<TCallback> Complete();
        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        IProgressableProcessFinished<TCallback> Throw(Exception exception);
        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        IProgressableProcessFinished<TCallback> Cancel();
        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        IProgressableProcessFinished<TCallback> WithoutCallback();
    }

    /// <summary>
    /// Represents an object that contains progress messages with result and has not completed yet.
    /// </summary>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="ICanAddProgressMessages" />
    public interface IProgressableProcessRunningWithResult<TCallback, TResult> : ICanAddProgressMessages
    {
        /// <summary>
        /// Completes the progress messages stream by signaling successful completion.
        /// </summary>
        /// <returns></returns>
        IProgressableProcessFinishedWithResult<TCallback, TResult> Complete(TResult result);
        /// <summary>
        /// Completes the progress messages stream by throwing exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        IProgressableProcessFinishedWithResult<TCallback, TResult> Throw(Exception exception);
        /// <summary>
        /// Completes the progress messages stream by cancelling the associated operation.
        /// </summary>
        /// <returns></returns>
        IProgressableProcessFinishedWithResult<TCallback, TResult> Cancel();
        /// <summary>
        /// Completes the progress messages stream by signaling a never-ending operation.
        /// </summary>
        /// <returns></returns>
        IProgressableProcessFinishedWithResult<TCallback, TResult> WithoutCallback();
    }

    /// <summary>
    /// Represents an object that contains progress messages.
    /// </summary>
    public interface IHaveProgressMessages
    {
        /// <summary>
        /// Gets the progress messages.
        /// </summary>
        /// <value>
        /// The progress messages.
        /// </value>
        IEnumerable<object> ProgressMessages { get; }
    }

    /// <summary>
    /// Represents progress messages stream that has completed.
    /// </summary>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <seealso cref="IHaveProgressMessages" />
    public interface IProgressableProcessFinished<out TCallback> : IHaveProgressMessages
    {
        /// <summary>
        /// Gets the finish callback.
        /// </summary>
        /// <value>
        /// The finish callback.
        /// </value>
        TCallback FinishCallback { get; }
        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        IMethodCallback AsMethodCallback();
    }

    /// <summary>
    /// Represents progress messages with result stream that has completed.
    /// </summary>
    /// <typeparam name="TCallback">The type of the callback.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IHaveProgressMessages" />
    // ReSharper disable once UnusedTypeParameter - no other way to differentiate between this and w/o return value
    public interface IProgressableProcessFinishedWithResult<out TCallback, TResult> : IHaveProgressMessages
    {
        /// <summary>
        /// Gets the finish callback.
        /// </summary>
        /// <value>
        /// The finish callback.
        /// </value>
        TCallback FinishCallback { get; }
        /// <summary>
        /// Return the correspondent method callback.
        /// </summary>
        /// <returns></returns>
        TCallback AsMethodCallback();
    }

    /// <summary>
    /// Base class for progress messages container.
    /// </summary>
    /// <seealso cref="IHaveProgressMessages" />
    /// <seealso cref="ICanAddProgressMessages" />
    public abstract class ProgressMessagesBase : IHaveProgressMessages, ICanAddProgressMessages
    {
        private readonly List<object> _progressMessages = new List<object>();
        /// <summary>
        /// Gets the progress messages.
        /// </summary>
        /// <value>
        /// The progress messages.
        /// </value>
        public IEnumerable<object> ProgressMessages
        {
            get { return _progressMessages; }
        }

        /// <summary>
        /// Adds the progress message.
        /// </summary>
        /// <param name="progressMessage">The progress message.</param>
        /// <returns></returns>
        public ICanAddProgressMessages AddProgress(object progressMessage)
        {
            _progressMessages.Add(progressMessage);
            return this;
        }
    }       
}