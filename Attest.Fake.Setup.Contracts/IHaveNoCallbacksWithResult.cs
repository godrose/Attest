namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>
    /// <typeparam name="TResult">Type of return value.</typeparam>
    public interface IHaveNoCallbacksWithResult<TCallback, in TResult> : IAddCallbackWithResult<TCallback, TResult>
    {

    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T">Type of parameter</typeparam>
    public interface IHaveNoCallbacksWithResult<TCallback, T, in TResult> : IAddCallbackWithResult<TCallback, T, TResult>
    {
    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public interface IHaveNoCallbacksWithResult<TCallback, T1, T2, in TResult> : IAddCallbackWithResult<TCallback, T1, T2, TResult>
    {
    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public interface IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, in TResult> : IAddCallbackWithResult<TCallback, T1, T2, T3, TResult>
    {
    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    public interface IHaveNoCallbacksWithResult<TCallback, T1,T2, T3, T4, in TResult> : IAddCallbackWithResult<TCallback, T1, T2, T3, T4, TResult>
    {
    }

    /// <summary>
    /// Represents a callbacks container without method callbacks.
    /// </summary>
    /// <typeparam name="TCallback">Type of method callback.</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="T4">Type of fourth parameter</typeparam>
    /// <typeparam name="T5">Type of fifth parameter</typeparam>
    public interface IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, T4, T5, in TResult> : IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, TResult>
    {
    }
}