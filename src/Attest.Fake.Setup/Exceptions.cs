using System;
using System.Collections.Generic;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// This exception is thrown to indicate progress event(s)
    /// and provide appropriate callback
    /// </summary>
    public class ProgressMessageException : Exception, IHaveProgressMessages
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressMessageException"/> class.
        /// </summary>
        /// <param name="progressMessages">The progress messages.</param>
        /// <param name="callbackAction">The callback action.</param>
        public ProgressMessageException(IEnumerable<object> progressMessages, Action callbackAction)
        {
            CallbackAction = callbackAction;
            ProgressMessages = progressMessages;
        }

        private IEnumerable<object> ProgressMessages { get; set; }

        IEnumerable<object> IHaveProgressMessages.ProgressMessages => ProgressMessages;

        /// <summary>
        /// The callback action.
        /// </summary>
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