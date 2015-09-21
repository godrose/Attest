using System;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    public interface IActionWrapper : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate>
    {
        Action Action { get; }
    }

    public interface IActionWrapper<T> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T>>
    {
        Action<T> Action { get; }
    }

    public interface IActionWrapper<T1, T2> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2>>
    {
        Action<T1, T2> Action { get; }
    }

    public interface IActionWrapper<T1, T2, T3> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2, T3>>
    {
        Action<T1, T2, T3> Action { get; }
    }

    public interface IActionWrapper<T1, T2, T3, T4> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2, T3, T4>>
    {
        Action<T1, T2, T3, T4> Action { get; }
    }

    public interface IActionWrapper<T1, T2, T3, T4, T5> : IAcceptor<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2, T3, T4, T5>>
    {
        Action<T1, T2, T3, T4, T5> Action { get; }
    } 

    public interface IActionWrapperVisitor
    {
        MethodCallbackTemplate Visit(IActionWrapper actionWrapper);
        MethodCallbackTemplate<T> Visit<T>(IActionWrapper<T> actionWrapper);
        MethodCallbackTemplate<T1, T2> Visit<T1, T2>(IActionWrapper<T1, T2> actionWrapper);
        MethodCallbackTemplate<T1, T2, T3> Visit<T1, T2, T3>(IActionWrapper<T1, T2, T3> actionWrapper);
        MethodCallbackTemplate<T1, T2, T3, T4> Visit<T1, T2, T3, T4>(IActionWrapper<T1, T2, T3, T4> actionWrapper);
        MethodCallbackTemplate<T1, T2, T3, T4, T5> Visit<T1, T2, T3, T4, T5>(IActionWrapper<T1, T2, T3, T4, T5> actionWrapper);
    }

    public interface IResultWrapper<TResult> : IAcceptor<IResultWrapperVisitor, MethodCallbackWithResultTemplate<TResult>>        
    {
       
    }

    public interface IResultWrapper<T, TResult> : IAcceptor<IResultWrapperVisitor, MethodCallbackWithResultTemplate<T, TResult>>       
    {
    }

    public interface IResultWrapper<T1, T2, TResult> : IAcceptor<IResultWrapperVisitor, MethodCallbackWithResultTemplate<T1, T2, TResult>>        
    {
    }

    public interface IResultWrapperVisitor
    {
        MethodCallbackWithResultTemplate<TResult> Visit<TResult>(IResultWrapper<TResult> actionWrapper);
        MethodCallbackWithResultTemplate<T, TResult> Visit<T, TResult>(IResultWrapper<T, TResult> actionWrapper);
        MethodCallbackWithResultTemplate<T1, T2, TResult> Visit<T1, T2, TResult>(IResultWrapper<T1, T2, TResult> actionWrapper);
    }   
}
