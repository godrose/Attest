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

    public class ActionWrapper<T1, T2, T3> : IActionWrapper<T1, T2, T3>
    {
        public ActionWrapper()
            : this((arg1, arg2, arg3) => { })
        {

        }

        public ActionWrapper(Action<T1, T2, T3> action)
        {
            Action = action;
        }

        public Action<T1, T2, T3> Action { get; private set; }

        public MethodCallbackTemplate<T1, T2, T3> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ActionWrapper<T1, T2, T3, T4> : IActionWrapper<T1, T2, T3, T4>
    {
        public ActionWrapper()
            : this((arg1, arg2, arg3, arg4) => { })
        {

        }

        public ActionWrapper(Action<T1, T2, T3, T4> action)
        {
            Action = action;
        }

        public Action<T1, T2, T3, T4> Action { get; private set; }

        public MethodCallbackTemplate<T1, T2, T3, T4> Accept(IActionWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5> : IActionWrapper<T1, T2, T3, T4, T5>
    {
        public ActionWrapper()
            : this((arg1, arg2, arg3, arg4, arg5) => { })
        {

        }

        public ActionWrapper(Action<T1, T2, T3, T4, T5> action)
        {
            Action = action;
        }

        public Action<T1, T2, T3, T4, T5> Action { get; private set; }

        public MethodCallbackTemplate<T1, T2, T3, T4, T5> Accept(IActionWrapperVisitor visitor)
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

        public MethodCallbackTemplate<T1, T2, T3> Visit<T1, T2, T3>(IActionWrapper<T1, T2, T3> actionWrapper)
        {
            var methodCallbackTemplate = new MethodCallbackTemplate<T1, T2, T3>();
            return methodCallbackTemplate.SetActionWrapper(actionWrapper);
        }

        public MethodCallbackTemplate<T1, T2, T3, T4> Visit<T1, T2, T3, T4>(IActionWrapper<T1, T2, T3, T4> actionWrapper)
        {
            var methodCallbackTemplate = new MethodCallbackTemplate<T1, T2, T3, T4>();
            return methodCallbackTemplate.SetActionWrapper(actionWrapper);
        }

        public MethodCallbackTemplate<T1, T2, T3, T4, T5> Visit<T1, T2, T3, T4, T5>(IActionWrapper<T1, T2, T3, T4, T5> actionWrapper)
        {
            var methodCallbackTemplate = new MethodCallbackTemplate<T1, T2, T3, T4, T5>();
            return methodCallbackTemplate.SetActionWrapper(actionWrapper);
        }
    }
}