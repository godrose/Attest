using System;

namespace Attest.Fake.Setup.Contracts
{
    public interface IActionWrapper : IAcceptorWithParametersResult<IActionWrapperVisitor, MethodCallbackTemplate>
    {
        Action Action { get; }
    }

    public interface IActionWrapper<T> : IAcceptorWithParametersResult<IActionWrapperVisitor, MethodCallbackTemplate<T>>
    {
        Action<T> Action { get; }
    }

    public interface IActionWrapper<T1, T2> : IAcceptorWithParametersResult<IActionWrapperVisitor, MethodCallbackTemplate<T1, T2>>
    {
        Action<T1, T2> Action { get; }
    }      

    public interface IActionWrapperVisitor
    {
        MethodCallbackTemplate Visit(IActionWrapper actionWrapper);
        MethodCallbackTemplate<T> Visit<T>(IActionWrapper<T> actionWrapper);
        MethodCallbackTemplate<T1, T2> Visit<T1, T2>(IActionWrapper<T1, T2> actionWrapper);
    }

    public interface IResultWrapper<TResult> : IAcceptorWithParametersResult<IResultWrapperVisitor, MethodCallbackWithResultTemplate<TResult>>, IReturnResult<TResult>
    {
       
    }

    public interface IResultWrapper<T, TResult> : IAcceptorWithParametersResult<IResultWrapperVisitor, MethodCallbackWithResultTemplate<T, TResult>>, IReturnResult<TResult>
    {
    }

    public interface IResultWrapper<T1, T2, TResult> : IAcceptorWithParametersResult<IResultWrapperVisitor, MethodCallbackWithResultTemplate<T1, T2, TResult>>, IReturnResult<TResult>
    {
    }

    public interface IResultWrapperVisitor
    {
        MethodCallbackWithResultTemplate<TResult> Visit<TResult>(IResultWrapper<TResult> actionWrapper);
        MethodCallbackWithResultTemplate<T, TResult> Visit<T, TResult>(IResultWrapper<T, TResult> actionWrapper);
        MethodCallbackWithResultTemplate<T1, T2, TResult> Visit<T1, T2, TResult>(IResultWrapper<T1, T2, TResult> actionWrapper);
    }   
}
