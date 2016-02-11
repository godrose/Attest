using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents method callback template with action wrapper.
    /// </summary>
    /// <typeparam name="TActionWrapper">The type of the action wrapper.</typeparam>
    public interface IMethodCallbackTemplateShared<TActionWrapper>
    {
        /// <summary>
        /// Gets the action wrapper.
        /// </summary>
        /// <value>
        /// The action wrapper.
        /// </value>
        TActionWrapper ActionWrapper { get; }
    }

    /// <summary>
    /// Represents method callback template without return value and no parameters
    /// </summary>
    /// <typeparam name="TActionWrapper">Type of the action wrapper.</typeparam>
    public interface IMethodCallbackTemplate<TActionWrapper> : IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback>, IMethodCallbackTemplateShared<TActionWrapper>
    {
        
    }

    /// <summary>
    /// Represents method callback template without return value and 1 parameter.
    /// </summary>
    /// <typeparam name="T">Type of parameter</typeparam>
    /// <typeparam name="TActionWrapper">Type of the action wrapper.</typeparam>
    public interface IMethodCallbackTemplate<TActionWrapper, T> : IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T>>, IMethodCallbackTemplateShared<TActionWrapper>
    {

    }

    /// <summary>
    /// Represents method callback template without return value and 2 parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TActionWrapper">Type of the action wrapper.</typeparam>
    public interface IMethodCallbackTemplate<TActionWrapper, T1, T2> : IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T1, T2>>, IMethodCallbackTemplateShared<TActionWrapper>
    {

    }

    /// <summary>
    /// Represents method callback template without return value and 3 parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="TActionWrapper">Type of the action wrapper.</typeparam>
    public interface IMethodCallbackTemplate<TActionWrapper, T1, T2, T3> : IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T1, T2, T3>>, IMethodCallbackTemplateShared<TActionWrapper>
    {

    }

    /// <summary>
    /// Represents method callback template without return value and 4 parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>    
    /// <typeparam name="TActionWrapper">Type of the action wrapper.</typeparam>
    public interface IMethodCallbackTemplate<TActionWrapper, T1, T2, T3, T4> : IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T1, T2, T3, T4>>, IMethodCallbackTemplateShared<TActionWrapper>
    {

    }

    /// <summary>
    /// Represents method callback template without return value and 5 parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>    
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="TActionWrapper">Type of the action wrapper.</typeparam>    
    public interface IMethodCallbackTemplate<TActionWrapper, T1, T2, T3, T4, T5> : IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T1, T2, T3, T4, T5>>, IMethodCallbackTemplateShared<TActionWrapper>
    {

    }
}