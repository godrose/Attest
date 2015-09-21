using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    public class MethodCallbackWithResultTemplate<TResult> : IAcceptor<IMethodCallbackWithResultTemplateVisitor, IMethodCallbackWithResult<TResult>>, IReturnResult<TResult>
    {
        public MethodCallbackWithResultTemplate<TResult> WithResult(TResult result)
        {
            Result = result;
            return this;
        }

        public IMethodCallbackWithResult<TResult> Accept(IMethodCallbackWithResultTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public TResult Result { get; private set; }
    }

    public class MethodCallbackWithResultTemplate<T, TResult> : IAcceptor<IMethodCallbackWithResultTemplateVisitor, IMethodCallbackWithResult<T, TResult>>, IReturnResult<TResult>
    {
        public MethodCallbackWithResultTemplate<T, TResult> WithResult(TResult result)
        {
            Result = result;
            return this;
        }

        public IMethodCallbackWithResult<T, TResult> Accept(IMethodCallbackWithResultTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public TResult Result { get; private set; }
    }

    public class MethodCallbackWithResultTemplate<T1, T2, TResult> : IAcceptor<IMethodCallbackWithResultTemplateVisitor, IMethodCallbackWithResult<T1, T2, TResult>>, IReturnResult<TResult>
    {
        public MethodCallbackWithResultTemplate<T1, T2, TResult> WithResult(TResult result)
        {
            Result = result;
            return this;
        }

        public IMethodCallbackWithResult<T1, T2, TResult> Accept(IMethodCallbackWithResultTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public TResult Result { get; private set; }
    }

    public interface IMethodCallbackWithResultTemplateVisitor
    {
        IMethodCallbackWithResult<TResult> Visit<TResult>(MethodCallbackWithResultTemplate<TResult> methodCallbackTemplate);
        IMethodCallbackWithResult<T, TResult> Visit<T, TResult>(MethodCallbackWithResultTemplate<T, TResult> methodCallbackTemplate);
        IMethodCallbackWithResult<T1, T2, TResult> Visit<T1, T2, TResult>(MethodCallbackWithResultTemplate<T1, T2, TResult> methodCallbackTemplate);
    }

    public class OnCompleteCallbackWithResultVisitor : IMethodCallbackWithResultTemplateVisitor
    {
        public IMethodCallbackWithResult<TResult> Visit<TResult>(MethodCallbackWithResultTemplate<TResult> methodCallbackTemplate)
        {
            return new OnCompleteCallbackWithResult<TResult>(methodCallbackTemplate.Result);
        }

        public IMethodCallbackWithResult<T, TResult> Visit<T, TResult>(MethodCallbackWithResultTemplate<T, TResult> methodCallbackTemplate)
        {
            return new OnCompleteCallbackWithResult<T, TResult>(methodCallbackTemplate.Result);
        }

        public IMethodCallbackWithResult<T1, T2, TResult> Visit<T1, T2, TResult>(MethodCallbackWithResultTemplate<T1, T2, TResult> methodCallbackTemplate)
        {
            return new OnCompleteCallbackWithResult<T1, T2, TResult>(methodCallbackTemplate.Result);
        }
    }
}