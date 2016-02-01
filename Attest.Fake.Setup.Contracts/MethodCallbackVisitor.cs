namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents visitor for different callbacks without return value and no parameters.
    /// </summary>
    public class MethodCallbackVisitor : MethodCallbackVisitorBase, IMethodCallbackVisitor
    {
        public void Visit(OnErrorCallback onErrorCallback)
        {
            VisitErrorImpl(onErrorCallback);
        }        

        public void Visit(OnCompleteCallback onCompleteCallback)
        {
            onCompleteCallback.Callback();
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

    /// <summary>
    /// Represents visitor for different callbacks without return value and one parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    public class MethodCallbackVisitor<T> : MethodCallbackVisitorBase, IMethodCallbackVisitor<T>
    {
        public void Visit(OnErrorCallback<T> onErrorCallback, T arg)
        {
            VisitErrorImpl(onErrorCallback);
        }

        public void Visit(OnCompleteCallback<T> onCompleteCallback, T arg)
        {
            onCompleteCallback.Callback(arg);
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <seealso cref="MethodCallbackVisitorBase" />
    /// <seealso cref="IMethodCallbackVisitor" />
    public class MethodCallbackVisitor<T1, T2> : MethodCallbackVisitorBase, IMethodCallbackVisitor<T1, T2>
    {
        public void Visit(OnErrorCallback<T1, T2> onErrorCallback, T1 arg1, T2 arg2)
        {
            VisitErrorImpl(onErrorCallback);
        }

        public void Visit(OnCompleteCallback<T1, T2> onCompleteCallback, T1 arg1, T2 arg2)
        {
            onCompleteCallback.Callback(arg1, arg2);
        }
    }

    public class MethodCallbackVisitor<T1, T2, T3> : MethodCallbackVisitorBase, IMethodCallbackVisitor<T1, T2, T3>
    {
        public void Visit(OnErrorCallback<T1, T2, T3> onErrorCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            VisitErrorImpl(onErrorCallback);
        }

        public void Visit(OnCompleteCallback<T1, T2, T3> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3);
        }
    }

    public class MethodCallbackVisitor<T1, T2, T3, T4> : MethodCallbackVisitorBase, IMethodCallbackVisitor<T1, T2, T3, T4>
    {
        public void Visit(OnErrorCallback<T1, T2, T3, T4> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            VisitErrorImpl(onErrorCallback);
        }

        public void Visit(OnCompleteCallback<T1, T2, T3, T4> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3, arg4);
        }
    }

    public class MethodCallbackVisitor<T1, T2, T3, T4, T5> : MethodCallbackVisitorBase,
        IMethodCallbackVisitor<T1, T2, T3, T4, T5>
    {
        public void Visit(OnErrorCallback<T1, T2, T3, T4, T5> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            VisitErrorImpl(onErrorCallback);
        }

        public void Visit(OnCompleteCallback<T1, T2, T3, T4, T5> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3, arg4, arg5);
        }
    }

    /// <summary>
    /// Base class for method callback visitors
    /// </summary>
    public abstract class MethodCallbackVisitorBase
    {
        protected static void VisitErrorImpl(IThrowException onErrorCallback)
        {
            throw onErrorCallback.Exception;
        }
    }
}