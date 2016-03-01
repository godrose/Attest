using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{    
    /// <summary>
    /// Represents visitor for different callbacks without return value and no parameters.
    /// </summary>
    class MethodCallbackVisitor : IMethodCallbackVisitor
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        public void Visit(OnErrorCallback onErrorCallback)
        {
            MethodCallbackVisitorHelper.VisitError(onErrorCallback);
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        public void Visit(OnCompleteCallback onCompleteCallback)
        {
            onCompleteCallback.Callback();
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback</param>
        public void Visit(ProgressCallback progressCallback)
        {
            MethodCallbackVisitorHelper.VisitProgress(progressCallback, c => c.Accept(this));           
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        public void Visit(OnCancelCallback onCancelCallback)
        {
            MethodCallbackVisitorHelper.VisitCancel();
        }

        /// <summary>
        /// Visits never-ending callback.
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        public void Visit(OnWithoutCallback withoutCallback)
        {
            MethodCallbackVisitorHelper.VisitWithout();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and one parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    public class MethodCallbackVisitor<T> : IMethodCallbackVisitor<T>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        public void Visit(OnErrorCallback<T> onErrorCallback, T arg)
        {
            MethodCallbackVisitorHelper.VisitError(onErrorCallback);
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg">Parameter</param>
        public void Visit(OnCompleteCallback<T> onCompleteCallback, T arg)
        {
            onCompleteCallback.Callback(arg);
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg">Parameter.</param>
        public void Visit(ProgressCallback<T> progressCallback, T arg)
        {
            MethodCallbackVisitorHelper.VisitProgress(progressCallback, c => c.Accept(this, arg));
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg">Parameter.</param>
        public void Visit(OnCancelCallback<T> onCancelCallback, T arg)
        {
            MethodCallbackVisitorHelper.VisitCancel();
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg">Parameter.</param>
        public void Visit(OnWithoutCallback<T> withoutCallback, T arg)
        {
            MethodCallbackVisitorHelper.VisitWithout();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and two parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <seealso cref="MethodCallbackVisitorHelper" />    
    public class MethodCallbackVisitor<T1, T2> : IMethodCallbackVisitor<T1, T2>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        public void Visit(OnErrorCallback<T1, T2> onErrorCallback, T1 arg1, T2 arg2)
        {
            MethodCallbackVisitorHelper.VisitError(onErrorCallback);
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        public void Visit(OnCompleteCallback<T1, T2> onCompleteCallback, T1 arg1, T2 arg2)
        {
            onCompleteCallback.Callback(arg1, arg2);
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        public void Visit(ProgressCallback<T1, T2> progressCallback, T1 arg1, T2 arg2)
        {
            MethodCallbackVisitorHelper.VisitProgress(progressCallback, c => c.Accept(this, arg1, arg2));
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        public void Visit(OnCancelCallback<T1, T2> onCancelCallback, T1 arg1, T2 arg2)
        {
            MethodCallbackVisitorHelper.VisitCancel();
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        public void Visit(OnWithoutCallback<T1, T2> withoutCallback, T1 arg1, T2 arg2)
        {
            MethodCallbackVisitorHelper.VisitWithout();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and 3 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <seealso cref="MethodCallbackVisitorHelper" />    
    public class MethodCallbackVisitor<T1, T2, T3> : IMethodCallbackVisitor<T1, T2, T3>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        public void Visit(OnErrorCallback<T1, T2, T3> onErrorCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            MethodCallbackVisitorHelper.VisitError(onErrorCallback);
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        public void Visit(OnCompleteCallback<T1, T2, T3> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3);
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        public void Visit(ProgressCallback<T1, T2, T3> progressCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            MethodCallbackVisitorHelper.VisitProgress(progressCallback, c => c.Accept(this, arg1, arg2, arg3));            
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        public void Visit(OnCancelCallback<T1, T2, T3> onCancelCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            MethodCallbackVisitorHelper.VisitCancel();
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        public void Visit(OnWithoutCallback<T1, T2, T3> withoutCallback, T1 arg1, T2 arg2, T3 arg3)
        {
            MethodCallbackVisitorHelper.VisitWithout();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <seealso cref="MethodCallbackVisitorHelper" />
    public class MethodCallbackVisitor<T1, T2, T3, T4> : IMethodCallbackVisitor<T1, T2, T3, T4>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        public void Visit(OnErrorCallback<T1, T2, T3, T4> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            MethodCallbackVisitorHelper.VisitError(onErrorCallback);
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        public void Visit(OnCompleteCallback<T1, T2, T3, T4> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        public void Visit(ProgressCallback<T1, T2, T3, T4> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            MethodCallbackVisitorHelper.VisitProgress(progressCallback, c => c.Accept(this, arg1, arg2, arg3, arg4));
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        public void Visit(OnCancelCallback<T1, T2, T3, T4> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            MethodCallbackVisitorHelper.VisitCancel();
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        public void Visit(OnWithoutCallback<T1, T2, T3, T4> withoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            MethodCallbackVisitorHelper.VisitWithout();
        }
    }

    /// <summary>
    /// Represents visitor for different callbacks without return value and 5 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <seealso cref="MethodCallbackVisitorHelper" />
    public class MethodCallbackVisitor<T1, T2, T3, T4, T5> : IMethodCallbackVisitor<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Visits exception throwing callback
        /// </summary>
        /// <param name="onErrorCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        public void Visit(OnErrorCallback<T1, T2, T3, T4, T5> onErrorCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            MethodCallbackVisitorHelper.VisitError(onErrorCallback);
        }

        /// <summary>
        /// Visits successful completion callback
        /// </summary>
        /// <param name="onCompleteCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        public void Visit(OnCompleteCallback<T1, T2, T3, T4, T5> onCompleteCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            onCompleteCallback.Callback(arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>
        /// Visits progress callback
        /// </summary>
        /// <param name="progressCallback">Callback.</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        public void Visit(ProgressCallback<T1, T2, T3, T4, T5> progressCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            MethodCallbackVisitorHelper.VisitProgress(progressCallback, c => c.Accept(this, arg1, arg2, arg3, arg4, arg5));
        }

        /// <summary>
        /// Visits cancellation callback
        /// </summary>
        /// <param name="onCancelCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        public void Visit(OnCancelCallback<T1, T2, T3, T4, T5> onCancelCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            MethodCallbackVisitorHelper.VisitCancel();
        }

        /// <summary>
        /// Visits never-ending callback
        /// </summary>
        /// <param name="withoutCallback">Callback</param>
        /// <param name="arg1">First parameter</param>
        /// <param name="arg2">Second parameter</param>
        /// <param name="arg3">Third parameter</param>
        /// <param name="arg4">Fourth parameter</param>
        /// <param name="arg5">Fifth parameter</param>
        public void Visit(OnWithoutCallback<T1, T2, T3, T4, T5> withoutCallback, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            MethodCallbackVisitorHelper.VisitWithout();
        }
    }
}