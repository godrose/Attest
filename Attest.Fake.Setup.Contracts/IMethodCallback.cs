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
}