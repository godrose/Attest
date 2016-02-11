using System;
using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// This exception is thrown to indicate progress event(s)
    /// and provide appropriate callback
    /// </summary>
    public class ProgressMessageException : Exception, IHaveProgressMessages
    {
        public ProgressMessageException(IEnumerable<object> progressMessages, Action callbackAction)
        {
            CallbackAction = callbackAction;
            ProgressMessages = progressMessages;
        }

        public IEnumerable<object> ProgressMessages { get; private set; }

        public Action CallbackAction { get; private set; }
    }

    /// <summary>
    /// This exception is thrown to indicate operation cancellation
    /// </summary>
    public class CancelCallbackException : Exception
    {

    }

    /// <summary>
    /// This exception is thrown to indicate operation that never completes
    /// </summary>
    public class WithoutCallbackException : Exception
    {

    }
}