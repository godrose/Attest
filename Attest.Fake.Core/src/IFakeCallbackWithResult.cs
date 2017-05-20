using System;

namespace Attest.Fake.Core
{
    /// <summary>
    /// Represents an abstraction over calling methods with return value on the fake
    /// </summary>
    public interface IFakeCallbackWithResult<in TResult>
    {
        /// <summary>
        /// Sets up the callback to a func with 0 parameters when invoked on the fake
        /// </summary>
        /// <param name="valueFunction">Func that will be invoked on the fake</param>
        void Callback(Func<TResult> valueFunction);
        /// <summary>
        /// Sets up the callback to a func with 1 parameter when invoked on the fake
        /// </summary>
        /// <typeparam name="T">Type of the parameter</typeparam>
        /// <param name="valueFunction">Func that will be invoked on the fake</param>
        void Callback<T>(Func<T, TResult> valueFunction);
        /// <summary>
        /// Sets up the callback to a func with 2 parameters when invoked on the fake
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <param name="valueFunction">Func that will be invoked on the fake</param>
        void Callback<T1, T2>(Func<T1, T2, TResult> valueFunction);
        /// <summary>
        /// Sets up the callback to a func with 3 parameters when invoked on the fake
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <typeparam name="T3">Type of the third parameter</typeparam>
        /// <param name="valueFunction">Func that will be invoked on the fake</param>
        void Callback<T1, T2, T3>(Func<T1, T2, T3, TResult> valueFunction);
        /// <summary>
        /// Sets up the callback to a func with 4 parameters when invoked on the fake
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <typeparam name="T3">Type of the third parameter</typeparam>
        /// <typeparam name="T4">Type of the fourth parameter</typeparam>
        /// <param name="valueFunction">Func that will be invoked on the fake</param>
        void Callback<T1, T2, T3, T4>(Func<T1, T2, T3, T4, TResult> valueFunction);
        /// <summary>
        /// Sets up the callback to a func with 5 parameters when invoked on the fake
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <typeparam name="T3">Type of the third parameter</typeparam>
        /// <typeparam name="T4">Type of the fourth parameter</typeparam>
        /// <typeparam name="T5">Type of the fifth parameter</typeparam>
        /// <param name="valueFunction">Func that will be invoked on the fake</param>
        void Callback<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, TResult> valueFunction);
    }
}