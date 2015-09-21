namespace Attest.Fake.Setup.Contracts
{
    public interface IMethodCallbackVisitor
    {
        void Visit(OnErrorCallback onErrorCallback);
        void Visit(OnCompleteCallback onCompleteCallback);
        void Visit(ProgressableCallback progressableCallback);
        void Visit(OnCancelCallback onCancelCallback);
    }

    public interface IMethodCallbackVisitor<T>
    {
        void Visit(OnErrorCallback<T> onErrorCallback, T arg);
        void Visit(OnCompleteCallback<T> onCompleteCallback, T arg);
    }

    public interface IMethodCallbackVisitor<T1, T2>
    {
        void Visit(OnErrorCallback<T1, T2> onErrorCallback, T1 arg1, T2 arg2);
        void Visit(OnCompleteCallback<T1, T2> onCompleteCallback, T1 arg1, T2 arg2);
    }

    public interface IMethodCallbackVisitor<T1, T2, T3>
    {
        void Visit(OnErrorCallback<T1, T2, T3> onErrorCallback, T1 arg1, T2 arg2, T3 arg3);
        void Visit(OnCompleteCallback<T1, T2, T3> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3);
    }

    public interface IMethodCallbackVisitor<T1, T2, T3, T4>
    {
        void Visit(OnErrorCallback<T1, T2, T3, T4> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
        void Visit(OnCompleteCallback<T1, T2, T3, T4> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    public interface IMethodCallbackVisitor<T1, T2, T3, T4, T5>
    {
        void Visit(OnErrorCallback<T1, T2, T3, T4, T5> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
        void Visit(OnCompleteCallback<T1, T2, T3, T4, T5> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
}