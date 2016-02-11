using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    internal class OnCompleteCallbackVisitor : IMethodCallbackTemplateVisitor
    {
        public IMethodCallback Visit(IMethodCallbackTemplate<IActionWrapper> methodCallbackTemplate)
        {
            return new OnCompleteCallback(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T> Visit<T>(IMethodCallbackTemplate<IActionWrapper<T>, T> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T>(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T1, T2> Visit<T1, T2>(IMethodCallbackTemplate<IActionWrapper<T1, T2>, T1, T2> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T1, T2>(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T1, T2, T3> Visit<T1, T2, T3>(IMethodCallbackTemplate<IActionWrapper<T1, T2, T3>, T1, T2, T3> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T1, T2, T3>(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T1, T2, T3, T4> Visit<T1, T2, T3, T4>(IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4>, T1, T2, T3, T4> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T1, T2, T3, T4>(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T1, T2, T3, T4, T5> Visit<T1, T2, T3, T4, T5>(IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T1, T2, T3, T4, T5>(methodCallbackTemplate.ActionWrapper.Action);
        }
    }
}