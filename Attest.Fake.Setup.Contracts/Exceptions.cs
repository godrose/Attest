using System;
using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{
    class ProgressMessageException : Exception, IHaveProgressMessages
    {
        public ProgressMessageException(IEnumerable<object> progressMessages, Action callbackAction)
        {
            CallbackAction = callbackAction;
            ProgressMessages = progressMessages;
        }

        public IEnumerable<object> ProgressMessages { get; private set; }

        public Action CallbackAction { get; private set; }
    }

    class CancelCallbackException : Exception
    {

    }

    class WithoutCallbackException : Exception
    {

    }
}