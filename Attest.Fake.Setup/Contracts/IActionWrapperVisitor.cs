namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Visitor for all action wrappers
    /// </summary>
    public interface IActionWrapperVisitor
    {
        /// <summary>
        /// Visits the specified action wrapper resulting in method callback template.
        /// </summary>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        IMethodCallbackTemplate<IActionWrapper> Visit(IActionWrapper actionWrapper);

        /// <summary>
        /// Visits the specified action wrapper resulting in method callback template.
        /// </summary>
        /// <typeparam name="T">The type of action's parameter.</typeparam>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        IMethodCallbackTemplate<IActionWrapper<T>, T> Visit<T>(IActionWrapper<T> actionWrapper);

        /// <summary>
        /// Visits the specified action wrapper resulting in method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the action's first parameter.</typeparam>
        /// <typeparam name="T2">The type of the action's second parameter.</typeparam>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        IMethodCallbackTemplate<IActionWrapper<T1, T2>, T1, T2> Visit<T1, T2>(IActionWrapper<T1, T2> actionWrapper);

        /// <summary>
        /// Visits the specified action wrapper resulting in method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the action's first parameter.</typeparam>
        /// <typeparam name="T2">The type of the action's second parameter.</typeparam>
        /// <typeparam name="T3">The type of the action's third parameter.</typeparam>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3>, T1, T2, T3> Visit<T1, T2, T3>(IActionWrapper<T1, T2, T3> actionWrapper);

        /// <summary>
        /// Visits the specified action wrapper resulting in method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the action's first parameter.</typeparam>
        /// <typeparam name="T2">The type of the action's second parameter.</typeparam>
        /// <typeparam name="T3">The type of the action's third parameter.</typeparam>
        /// <typeparam name="T4">The type of the action's fourth parameter.</typeparam>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4>, T1, T2, T3, T4> Visit<T1, T2, T3, T4>(IActionWrapper<T1, T2, T3, T4> actionWrapper);

        /// <summary>
        /// Visits the specified action wrapper resulting in method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the action's first parameter.</typeparam>
        /// <typeparam name="T2">The type of the action's second parameter.</typeparam>
        /// <typeparam name="T3">The type of the action's third parameter.</typeparam>
        /// <typeparam name="T4">The type of the action's fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the action's fifth parameter.</typeparam>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> Visit<T1, T2, T3, T4, T5>(IActionWrapper<T1, T2, T3, T4, T5> actionWrapper);
    }
}