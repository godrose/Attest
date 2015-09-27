using System;
using System.Linq;

namespace Attest.Fake.Setup.Contracts
{
    public class MethodCallbackWithResultVisitor<TResult> : IMethodCallbackWithResultVisitor<TResult>
    {
        public TResult Visit(OnErrorCallbackWithResult<TResult> onErrorCallback)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit(OnCancelCallbackWithResult<TResult> onCancelCallback)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit(OnCompleteCallbackWithResult<TResult> onCompleteCallbackWithResult)
        {
            return onCompleteCallbackWithResult.ValueFunction();
        }

        public TResult Visit(ProgressCallbackWithResult<TResult> progressCallback)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return progressCallback.FinishCallback.Accept(this);
        }

        public TResult Visit(OnWithoutCallbackWithResult<TResult> withoutCallback)
        {
            throw new WithoutCallbackException();
        }
    }

    public class MethodCallbackWithResultVisitor<T, TResult> : IMethodCallbackWithResultVisitor<T, TResult>
    {
        public TResult Visit(OnErrorCallbackWithResult<T, TResult> onErrorCallback, T arg)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit(OnCancelCallbackWithResult<T, TResult> onCancelCallback, T arg)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit(OnCompleteCallbackWithResult<T, TResult> onCompleteCallbackWithResult, T arg)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg);
        }

        public TResult Visit(ProgressCallbackWithResult<T, TResult> progressCallback, T arg)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return progressCallback.FinishCallback.Accept(this, arg);
        }

        public TResult Visit(OnWithoutCallbackWithResult<T, TResult> withoutCallback, T arg)
        {
            throw new WithoutCallbackException();
        }
    }

    public class MethodCallbackWithResultVisitor<T1, T2, TResult> : IMethodCallbackWithResultVisitor<T1, T2, TResult>
    {
        public TResult Visit(OnErrorCallbackWithResult<T1, T2, TResult> onErrorCallback, T1 arg1, T2 arg2)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit(OnCancelCallbackWithResult<T1, T2, TResult> onCancelCallback, T1 arg1, T2 arg2)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit(OnCompleteCallbackWithResult<T1, T2, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg1, arg2);
        }

        public TResult Visit(ProgressCallbackWithResult<T1, T2, TResult> progressCallback, T1 arg1, T2 arg2)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return progressCallback.FinishCallback.Accept(this, arg1, arg2);
        }

        public TResult Visit(OnWithoutCallbackWithResult<T1, T2, TResult> onWithoutCallback, T1 arg1, T2 arg2)
        {
            throw new WithoutCallbackException();
        }
    }

    public class MethodCallbackWithResultVisitor<T1, T2, T3, TResult> : IMethodCallbackWithResultVisitor<T1, T2, T3, TResult>
    {
        public TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg1, arg2, arg3);
        }

        public TResult Visit(ProgressCallbackWithResult<T1, T2, T3, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return progressCallback.FinishCallback.Accept(this, arg1, arg2, arg3);
        }

        public TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            throw new WithoutCallbackException();
        }
    }

    public class MethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult> : IMethodCallbackWithResultVisitor<T1, T2, T3, T4, TResult>
    {
        public TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, T4, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, T4, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, T4, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg1, arg2, arg3, arg4);
        }

        public TResult Visit(ProgressCallbackWithResult<T1, T2, T3, T4, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return progressCallback.FinishCallback.Accept(this, arg1, arg2, arg3, arg4);
        }

        public TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, T4, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            throw new WithoutCallbackException();
        }
    }

    public class MethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult> : IMethodCallbackWithResultVisitor<T1, T2, T3, T4, T5, TResult>
    {
        public TResult Visit(OnErrorCallbackWithResult<T1, T2, T3, T4, T5, TResult> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            throw onErrorCallback.Exception;
        }

        public TResult Visit(OnCancelCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            throw new CancelCallbackException();
        }

        public TResult Visit(OnCompleteCallbackWithResult<T1, T2, T3, T4, T5, TResult> onCompleteCallbackWithResult, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return onCompleteCallbackWithResult.ValueFunction(arg1, arg2, arg3, arg4, arg5);
        }

        public TResult Visit(ProgressCallbackWithResult<T1, T2, T3, T4, T5, TResult> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            if (progressCallback.ProgressMessages.Any())
                throw new NotSupportedException("Value-returning calls with progress messages are not supported");
            return progressCallback.FinishCallback.Accept(this, arg1, arg2, arg3, arg4, arg5);
        }

        public TResult Visit(OnWithoutCallbackWithResult<T1, T2, T3, T4, T5, TResult> onWithoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            throw new WithoutCallbackException();
        }
    }
}