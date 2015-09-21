namespace Attest.Fake.Setup.Contracts
{
    public class MethodCallbackVisitor : IMethodCallbackVisitor
    {
        public void Visit(OnErrorCallback onErrorCallback)
        {
            throw onErrorCallback.Exception;
        }

        public void Visit<T>(OnErrorCallback<T> onErrorCallback, T arg)
        {
            throw onErrorCallback.Exception;
        }

        public void Visit<T1, T2>(OnErrorCallback<T1, T2> onErrorCallback, T1 arg1, T2 arg2)
        {
            throw onErrorCallback.Exception;
        }

        public void Visit<T1, T2, T3>(OnErrorCallback<T1, T2, T3> onErrorCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            throw onErrorCallback.Exception;
        }

        public void Visit<T1, T2, T3, T4>(OnErrorCallback<T1, T2, T3, T4> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            throw onErrorCallback.Exception;
        }

        public void Visit<T1, T2, T3, T4, T5>(OnErrorCallback<T1, T2, T3, T4, T5> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            throw onErrorCallback.Exception;
        }

        public void Visit(OnCompleteCallback onCompleteCallback)
        {
            onCompleteCallback.Callback();
        }

        public void Visit<T>(OnCompleteCallback<T> onCompleteCallback, T arg)
        {
            onCompleteCallback.Callback(arg);
        }

        public void Visit<T1, T2>(OnCompleteCallback<T1, T2> onCompleteCallback, T1 arg1, T2 arg2)
        {
            onCompleteCallback.Callback(arg1, arg2);
        }

        public void Visit<T1, T2, T3>(OnCompleteCallback<T1, T2, T3> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3);
        }

        public void Visit<T1, T2, T3, T4>(OnCompleteCallback<T1, T2, T3, T4> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3, arg4);
        }

        public void Visit<T1, T2, T3, T4, T5>(OnCompleteCallback<T1, T2, T3, T4, T5> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3, arg4, arg5);
        }

        public void Visit(ProgressableCallback progressableCallback)
        {
            throw new ProgressMessageException(progressableCallback.ProgressMessages,
                () =>
                {
                    if (progressableCallback.FinishCallback != null)
                    {
                        progressableCallback.FinishCallback.Accept(this);
                    }                    
                });
        }

        public void Visit(OnCancelCallback onCancelCallback)
        {
            throw new CancelCallbackException();
        }
    }
}