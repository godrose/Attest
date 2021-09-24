namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents visitor for different method callback templates without return value
    /// </summary>
    public interface IMethodCallbackTemplateVisitor
    {
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallback Visit(IMethodCallbackTemplate<IActionWrapper> methodCallbackTemplate);
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallback<T> Visit<T>(IMethodCallbackTemplate<IActionWrapper<T>, T> methodCallbackTemplate);
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallback<T1, T2> Visit<T1, T2>(IMethodCallbackTemplate<IActionWrapper<T1, T2>, T1, T2> methodCallbackTemplate);
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallback<T1, T2, T3> Visit<T1, T2, T3>(IMethodCallbackTemplate<IActionWrapper<T1, T2, T3>, T1, T2, T3> methodCallbackTemplate);

        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        IMethodCallback<T1, T2, T3, T4> Visit<T1, T2, T3, T4>(
            IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4>, T1, T2, T3, T4> methodCallbackTemplate);

        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        IMethodCallback<T1, T2, T3, T4, T5> Visit<T1, T2, T3, T4, T5>(
            IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> methodCallbackTemplate);
    }
}