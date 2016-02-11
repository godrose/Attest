using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
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