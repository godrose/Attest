using System;
using Attest.Fake.Setup.Contracts;
using Solid.Patterns.Builder;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Callback builder for creating different types of callbacks to the wrapped action
    /// </summary>
    /// <typeparam name="TActionWrapper">Type of action wrapper</typeparam>
    /// <typeparam name="TCallbackTemplate">Type of callback template</typeparam>
    /// <typeparam name="TCallback">Type of callback</typeparam>
    public class CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> : IBuilder<TCallback>
        where TActionWrapper : IAcceptor<IActionWrapperVisitor, TCallbackTemplate>, new()
        where TCallbackTemplate : IAcceptor<IMethodCallbackTemplateVisitor, TCallback>
    {
        private TActionWrapper _actionWrapper;
        private CallbackType _callbackType = CallbackType.Complete;

        private CallbackBuilder()
        {
        }

        /// <summary>
        /// Creates instance of callback builder
        /// </summary>
        /// <returns>Callback builder instance</returns>
        public static CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> CreateCallbackBuilder()
        {
            return new CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback>();
        }

        internal CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> WithAction(TActionWrapper actionWrapper)
        {
            _actionWrapper = actionWrapper;
            return this;
        }

        /// <summary>
        /// Sets the action wrapper to the default action wrapper
        /// and builds the callback
        /// </summary>
        /// <returns>Callback after the setup</returns>
        public TCallback WithDefaultAction()
        {
            _actionWrapper = new TActionWrapper();
            return BuildCallback();
        }

        /// <summary>
        /// Builds the callback.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException">Action Wrapper can't be null</exception>
        public TCallback Build()
        {
            if (_actionWrapper == null)
            {
                throw new NullReferenceException("Action Wrapper can't be null");
            }
            return BuildCallback();
        }

        /// <summary>
        /// Sets the type of callback to a successful completion
        /// </summary>
        /// <returns>Callback builder configured to return successful completion callback</returns>
        internal CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> AsComplete()
        {
            _callbackType = CallbackType.Complete;
            return this;
        }

        /// <summary>
        /// Sets the type of callback to throwing exception
        /// </summary>
        /// <returns>Callback builder configured to return exception-throwing callback</returns>
        internal CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> AsError()
        {
            _callbackType = CallbackType.Error;
            return this;
        }

        /// <summary>
        /// Sets the type of callback to operation cancellation
        /// </summary>
        /// <returns>Callback builder configured to return operation cancellation callback</returns>
        internal CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> AsCancel()
        {
            _callbackType = CallbackType.Cancel;
            return this;
        }

        /// <summary>
        /// Builds new callback according to the current setup
        /// </summary>
        /// <returns>Instance of callback</returns>
        private TCallback BuildCallback()
        {
            return _actionWrapper.Accept(new ActionWrapperVisitor()).Accept(PickCallbackTemplateVisitor());
        }

        private IMethodCallbackTemplateVisitor PickCallbackTemplateVisitor()
        {
            switch (_callbackType)
            {
                case CallbackType.Complete:
                    return new OnCompleteCallbackVisitor();
                case CallbackType.Error:
                    throw new NotImplementedException();
                case CallbackType.Cancel:
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException("Callback type not supported");
            }
        }
    }

    //for now no polymorphism
    enum CallbackType
    {
        Complete,
        Error,
        Cancel
    }
}