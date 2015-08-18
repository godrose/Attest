using System;
using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{
    public interface ICanAddProgressMessages
    {
        ICanAddProgressMessages AddProgress(object progressMessage);
    }

    public interface IProgressableProcessRunning<TCallback> : ICanAddProgressMessages
    {
        IProgressableProcessFinished<TCallback> Complete();
        IProgressableProcessFinished<TCallback> Throw(Exception exception);
        IProgressableProcessFinished<TCallback> Cancel();
        IProgressableProcessFinished<TCallback> WithoutCallback();
    }

    public interface IProgressableProcessRunningWithResult<TCallback, TResult> : ICanAddProgressMessages
    {
        IProgressableProcessFinishedWithResult<TCallback, TResult> Complete(TResult result);
        IProgressableProcessFinishedWithResult<TCallback, TResult> Throw(Exception exception);
        IProgressableProcessFinishedWithResult<TCallback, TResult> Cancel();
        IProgressableProcessFinishedWithResult<TCallback, TResult> WithoutCallback();
    }

    public interface IHaveProgressMessages
    {
        IEnumerable<object> ProgressMessages { get; }
    }

    public interface IProgressableProcessFinished<out TCallback> : IHaveProgressMessages
    {
        TCallback FinishCallback { get; }
        IMethodCallback AsMethodCallback();
    }

    public interface IProgressableProcessFinishedWithResult<out TCallback, TResult> : IHaveProgressMessages
    {
        TCallback FinishCallback { get; }
        TCallback AsMethodCallback();
    }

    public abstract class ProgressMessagesBase : IHaveProgressMessages, ICanAddProgressMessages
    {
        private List<object> _progressMessages = new List<object>();
        public IEnumerable<object> ProgressMessages
        {
            get { return _progressMessages; }
        }

        public ICanAddProgressMessages AddProgress(object progressMessage)
        {
            _progressMessages.Add(progressMessage);
            return this;
        }
    }       
}