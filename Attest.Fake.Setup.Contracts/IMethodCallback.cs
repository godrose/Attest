using System;

namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallback : IAcceptorWithParameters<IMethodCallbackVisitor>
    {

    }

    public interface IMethodCallback<in T> : IAcceptorWithParameters<IMethodCallbackVisitor, T>
    {
        Action<T> Callback { get; }
    }

    public interface IMethodCallback<in T1, in T2> : IAcceptorWithParameters<IMethodCallbackVisitor, T1, T2>
    {
        Action<T1, T2> Callback { get; }
    }

    public interface IMethodCallback<in T1, in T2, in T3> : IAcceptorWithParameters<IMethodCallbackVisitor, T1, T2, T3>
    {
        Action<T1, T2, T3> Callback { get; }
    }

    public interface IMethodCallback<in T1, in T2, in T3, in T4> : IAcceptorWithParameters<IMethodCallbackVisitor, T1, T2, T3, T4>
    {
        Action<T1, T2, T3, T4> Callback { get; }
    }

    public interface IMethodCallback<in T1, in T2, in T3, in T4, in T5> : IAcceptorWithParameters<IMethodCallbackVisitor, T1, T2, T3, T4, T5>
    {
        Action<T1, T2, T3, T4, T5> Callback { get; }
    }
       
    public interface IMethodCallbackVisitor
    {
        void Visit(OnErrorCallback onErrorCallback);
        void Visit(OnCompleteCallback onCompleteCallback);
        void Visit<T>(OnCompleteCallback<T> onCompleteCallback, T arg);
        void Visit<T1, T2>(OnCompleteCallback<T1, T2> onCompleteCallback, T1 arg1, T2 arg2);
        void Visit<T1, T2, T3>(OnCompleteCallback<T1, T2, T3> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3);
        void Visit<T1, T2, T3, T4>(OnCompleteCallback<T1, T2, T3, T4> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
        void Visit<T1, T2, T3, T4, T5>(OnCompleteCallback<T1, T2, T3, T4, T5> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
        void Visit(ProgressableCallback0 progressableCallback);
        void Visit(OnCancelCallback onCancelCallback);
    }    
}