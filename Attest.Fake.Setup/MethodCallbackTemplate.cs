using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Base class for method callback templates.
    /// </summary>
    /// <typeparam name="TActionWrapper">The type of the action wrapper.</typeparam>
    public class MethodCallbackTemplateBase<TActionWrapper>
    {        
        internal void SetActionWrapperInternal(TActionWrapper actionWrapper)
        {
            ActionWrapper = actionWrapper;
        }

        /// <summary>
        /// Gets the action wrapper.
        /// </summary>
        /// <value>
        /// The action wrapper.
        /// </value>
        public TActionWrapper ActionWrapper { get; private set; }
    }

    /// <summary>
    /// Represents method callback template without return value and no parameters
    /// </summary>
    public class MethodCallbackTemplate : 
        MethodCallbackTemplateBase<IActionWrapper>,
        IMethodCallbackTemplate<IActionWrapper>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallback Accept(IMethodCallbackTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        /// Sets the action wrapper.
        /// </summary>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        public MethodCallbackTemplate SetActionWrapper(IActionWrapper actionWrapper)
        {
            SetActionWrapperInternal(actionWrapper);
            return this;
        }
    }

    /// <summary>
    /// Represents method callback template without return value and one parameter.
    /// </summary>
    /// <typeparam name="T">Type of parameter</typeparam>
    public class MethodCallbackTemplate<T> :
        MethodCallbackTemplateBase<IActionWrapper<T>>,
        IMethodCallbackTemplate<IActionWrapper<T>, T>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallback<T> Accept(IMethodCallbackTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        /// Sets the action wrapper.
        /// </summary>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        public MethodCallbackTemplate<T> SetActionWrapper(IActionWrapper<T> actionWrapper)
        {
            SetActionWrapperInternal(actionWrapper);
            return this;
        }
    }

    /// <summary>
    /// Represents method callback template without return value and two parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    public class MethodCallbackTemplate<T1, T2> :
        MethodCallbackTemplateBase<IActionWrapper<T1, T2>>,
        IMethodCallbackTemplate<IActionWrapper<T1, T2>, T1, T2>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallback<T1, T2> Accept(IMethodCallbackTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        /// Sets the action wrapper.
        /// </summary>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        public MethodCallbackTemplate<T1, T2> SetActionWrapper(IActionWrapper<T1, T2> actionWrapper)
        {
            SetActionWrapperInternal(actionWrapper);
            return this;
        }        
    }

    /// <summary>
    /// Represents method callback template without return value and three parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    public class MethodCallbackTemplate<T1, T2, T3> :
        MethodCallbackTemplateBase<IActionWrapper<T1, T2, T3>>,
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3>, T1, T2, T3>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallback<T1, T2, T3> Accept(IMethodCallbackTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        /// Sets the action wrapper.
        /// </summary>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        public MethodCallbackTemplate<T1, T2, T3> SetActionWrapper(IActionWrapper<T1, T2, T3> actionWrapper)
        {
            SetActionWrapperInternal(actionWrapper);
            return this;
        }        
    }

    /// <summary>
    /// Represents method callback template without return value and four parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    public class MethodCallbackTemplate<T1, T2, T3, T4> :
        MethodCallbackTemplateBase<IActionWrapper<T1, T2, T3, T4>>,
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4>, T1, T2, T3, T4>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallback<T1, T2, T3, T4> Accept(IMethodCallbackTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        /// Sets the action wrapper.
        /// </summary>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        public MethodCallbackTemplate<T1, T2, T3, T4> SetActionWrapper(IActionWrapper<T1, T2, T3, T4> actionWrapper)
        {
            SetActionWrapperInternal(actionWrapper);
            return this;
        }        
    }

    /// <summary>
    /// Represents method callback template without return value and five parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    public class MethodCallbackTemplate<T1, T2, T3, T4, T5> :
        MethodCallbackTemplateBase<IActionWrapper<T1, T2, T3, T4, T5>>,
        IMethodCallbackTemplate<IActionWrapper<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns/>
        public IMethodCallback<T1, T2, T3, T4, T5> Accept(IMethodCallbackTemplateVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        /// Sets the action wrapper.
        /// </summary>
        /// <param name="actionWrapper">The action wrapper.</param>
        /// <returns></returns>
        public MethodCallbackTemplate<T1, T2, T3, T4, T5> SetActionWrapper(IActionWrapper<T1, T2, T3, T4, T5> actionWrapper)
        {
            SetActionWrapperInternal(actionWrapper);
            return this;
        }        
    }
}