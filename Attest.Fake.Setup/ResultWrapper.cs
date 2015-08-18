using System;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    public class ResultWrapper<TResult> : IResultWrapper<TResult>
    {
        public ResultWrapper(TResult result)
        {
            Result = result;
        }

        public TResult Result { get; private set; }

        public MethodCallbackWithResultTemplate<TResult> Accept(IResultWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ResultWrapper<T, TResult> : IResultWrapper<T, TResult>
    {
        public ResultWrapper(TResult result)
        {
            Result = result;
        }

        public TResult Result { get; private set; }

        public MethodCallbackWithResultTemplate<T, TResult> Accept(IResultWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class ResultWrapper<T1, T2, TResult> : IResultWrapper<T1, T2, TResult>
    {
        public ResultWrapper(TResult result)
        {
            Result = result;
        }

        public TResult Result { get; private set; }

        public MethodCallbackWithResultTemplate<T1, T2, TResult> Accept(IResultWrapperVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    internal class ResultWrapperVisitor : IResultWrapperVisitor
    {
        public MethodCallbackWithResultTemplate<TResult> Visit<TResult>(IResultWrapper<TResult> resultWrapper)
        {
            return VisitImpl<MethodCallbackWithResultTemplate<TResult>>();
        }

        public MethodCallbackWithResultTemplate<T, TResult> Visit<T, TResult>(IResultWrapper<T, TResult> resultWrapper)
        {
            throw new NotImplementedException();
        }

        public MethodCallbackWithResultTemplate<T1, T2, TResult> Visit<T1, T2, TResult>(IResultWrapper<T1, T2, TResult> resultWrapper)
        {
            throw new NotImplementedException();
        }

        private TMethodCallbackTemplate VisitImpl<TMethodCallbackTemplate>() where TMethodCallbackTemplate : new()
        {            
            return new TMethodCallbackTemplate();
        }
    }
}