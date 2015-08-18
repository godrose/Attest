using System;

namespace Attest.Fake.Setup.Contracts
{
    public class ActionWrapper : IActionWrapper
    {
        public ActionWrapper()
            :this(() => { })
        {
            
        }

        public ActionWrapper(Action action)
        {
            Action = action;
        }

        public Action Action { get; private set; }

        public MethodCallbackTemplate Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ActionWrapper<T> : IActionWrapper<T>
    {
        public ActionWrapper() :this(T => { })
        {
            
        }

        public ActionWrapper(Action<T> action)
        {
            Action = action;
        }        

        public Action<T> Action { get; private set; }

        public MethodCallbackTemplate<T> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ActionWrapper<T1,T2> : IActionWrapper<T1, T2>
    {
        public ActionWrapper()
            :this((arg1, arg2) => { })
        {
            
        }

        public ActionWrapper(Action<T1, T2> action)
        {
            Action = action;
        }       

        public Action<T1, T2> Action { get; private set; }

        public MethodCallbackTemplate<T1, T2> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    internal class ActionWrapperVisitor : IActionWrapperVisitor
    {
        public MethodCallbackTemplate Visit(IActionWrapper actionWrapper)
        {
            var methodCallbackTemplate = new MethodCallbackTemplate();
            return methodCallbackTemplate.SetActionWrapper(actionWrapper);
        }

        public MethodCallbackTemplate<T> Visit<T>(IActionWrapper<T> actionWrapper)
        {
            var methodCallbackTemplate = new MethodCallbackTemplate<T>();
            return methodCallbackTemplate.SetActionWrapper(actionWrapper);
        }

        public MethodCallbackTemplate<T1, T2> Visit<T1, T2>(IActionWrapper<T1, T2> actionWrapper)
        {
            var methodCallbackTemplate = new MethodCallbackTemplate<T1, T2>();
            return methodCallbackTemplate.SetActionWrapper(actionWrapper);
        }
    }
}