using System;

namespace Attest.Fake.Setup.Contracts
{
    public class CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> 
        where TActionWrapper : IAcceptorWithParametersResult<IActionWrapperVisitor, TCallbackTemplate>, new() 
        where TCallbackTemplate : IAcceptorWithParametersResult<IMethodCallbackTemplateVisitor,TCallback>
    {
        private TActionWrapper _actionWrapper;        
        private CallbackType _callbackType;

        private CallbackBuilder()
        {
            
        }

        public static CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> CreateCallbackBuilder()
        {
            return new CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback>();
        }

        internal CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> WithAction(TActionWrapper actionWrapper)
        {
            _actionWrapper = actionWrapper;
            return this;
        }

        public TCallback WithDefaultAction()
        {
            
            _actionWrapper = new TActionWrapper();
            return BuildCallback();
        }

        internal CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> AsComplete()
        {
            _callbackType = CallbackType.Complete;
            return this;
        }

        internal CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> AsError()
        {
            _callbackType = CallbackType.Error;
            return this;
        }

        internal CallbackBuilder<TActionWrapper, TCallbackTemplate, TCallback> AsCancel()
        {
            _callbackType = CallbackType.Cancel;
            return this;
        }

        internal TCallback BuildCallback()
        {
            var callbackTemplateVisitor = PickCallbackTemplateVisitor();
            var actionWrapperVisitor = new ActionWrapperVisitor();
            return _actionWrapper.Accept(actionWrapperVisitor, TODO).Accept(callbackTemplateVisitor, TODO);
        }

        private IMethodCallbackTemplateVisitor PickCallbackTemplateVisitor()
        {
            switch (_callbackType)
            {
                case CallbackType.Complete: return new OnCompleteCallbackVisitor();
                case CallbackType.Error: throw new NotImplementedException();
                case CallbackType.Cancel: throw new NotImplementedException();
            }
            throw new NotSupportedException("Callback type not supported");
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