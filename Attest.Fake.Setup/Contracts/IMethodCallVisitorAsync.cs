namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents visitor for different method calls without return value
    /// </summary>
    public interface IMethodCallVisitorAsync<TService> where TService : class
    {
        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <param name="methodCall">The method call.</param>
        void Visit(IMethodCallAsync<TService, IMethodCallback> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T>(IMethodCallAsync<TService, IMethodCallback<T>> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T1, T2>(IMethodCallAsync<TService, IMethodCallback<T1, T2>> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="methodCall">The method call.</param>
        void Visit<T1, T2, T3>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3>> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>        
        /// <param name="methodCall">The method call.</param>
        void Visit<T1, T2, T3, T4>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3, T4>> methodCall);

        /// <summary>
        /// Visits the specified method call.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>        
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam>        
        /// <param name="methodCall">The method call.</param>
        void Visit<T1, T2, T3, T4, T5>(IMethodCallAsync<TService, IMethodCallback<T1, T2, T3, T4, T5>> methodCall);
    }
}