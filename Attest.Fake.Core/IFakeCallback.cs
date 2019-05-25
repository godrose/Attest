using System;

namespace Attest.Fake.Core
{
    /// <summary>
    /// Represents an abstraction over calling methods without return value on the fake
    /// </summary>
    public interface IFakeCallback
    {
        /// <summary>
        /// Sets up the callback to an action with 0 parameters when invoked on the fake
        /// </summary>
        /// <param name="action">Action that will be invoked on the fake</param>
        void Callback(Action action);
        /// <summary>
        /// Sets up the callback to an action with 1 parameter when invoked on the fake
        /// </summary>
        /// <typeparam name="T">Type of the parameter</typeparam>
        /// <param name="action">Action that will be invoked on the fake</param>
        void Callback<T>(Action<T> action);
        /// <summary>
        /// Sets up the callback to an action with 2 parameters when invoked on the fake
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <param name="action">Action that will be invoked on the fake</param>
        void Callback<T1, T2>(Action<T1, T2> action);

        /// <summary>
        /// Sets up the callback to an action with 3 parameters when invoked on the fake
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <typeparam name="T3">Type of the third parameter</typeparam>
        /// <param name="action">Action that will be invoked on the fake</param>
        void Callback<T1, T2, T3>(Action<T1, T2, T3> action);

        /// <summary>
        /// Sets up the callback to an action with 4 parameters when invoked on the fake
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <typeparam name="T3">Type of the third parameter</typeparam>
        /// <typeparam name="T4">Type of the fourth parameter</typeparam>
        /// <param name="action">Action that will be invoked on the fake</param>
        void Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action);

        /// <summary>
        /// Sets up the callback to an action with 5 parameters when invoked on the fake
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <typeparam name="T3">Type of the third parameter</typeparam>
        /// <typeparam name="T4">Type of the fourth parameter</typeparam>
        /// <typeparam name="T5">Type of the fifth parameter</typeparam>
        /// <param name="action">Action that will be invoked on the fake</param>
        void Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action);
    }
}