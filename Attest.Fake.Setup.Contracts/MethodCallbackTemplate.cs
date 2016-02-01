using Solid.Patterns.Visitor;

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
        IMethodCallback Visit(MethodCallbackTemplate methodCallbackTemplate);
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallback<T> Visit<T>(MethodCallbackTemplate<T> methodCallbackTemplate);
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallback<T1, T2> Visit<T1, T2>(MethodCallbackTemplate<T1, T2> methodCallbackTemplate);
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        /// <returns></returns>
        IMethodCallback<T1, T2, T3> Visit<T1, T2, T3>(MethodCallbackTemplate<T1, T2, T3> methodCallbackTemplate);
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        IMethodCallback<T1, T2, T3, T4> Visit<T1, T2, T3, T4>(MethodCallbackTemplate<T1, T2, T3, T4> methodCallbackTemplate);
        /// <summary>
        /// Visits the specified method callback template.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
        /// <param name="methodCallbackTemplate">The method callback template.</param>
        IMethodCallback<T1, T2, T3, T4, T5> Visit<T1, T2, T3, T4, T5>(MethodCallbackTemplate<T1, T2, T3, T4, T5> methodCallbackTemplate);
    }

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
        IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback>
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
    /// Represents method callback template without return value and 1 parameter.
    /// </summary>
    /// <typeparam name="T">Type of parameter</typeparam>
    public class MethodCallbackTemplate<T> :
        MethodCallbackTemplateBase<IActionWrapper<T>>,
        IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T>>
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
    /// Represents method callback template without return value and 2 parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    public class MethodCallbackTemplate<T1, T2> :
        MethodCallbackTemplateBase<IActionWrapper<T1, T2>>,
        IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T1, T2>>
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
    /// Represents method callback template without return value and 3 parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    public class MethodCallbackTemplate<T1, T2, T3> :
        MethodCallbackTemplateBase<IActionWrapper<T1, T2, T3>>,
        IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T1, T2, T3>>
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
    /// Represents method callback template without return value and 4 parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    public class MethodCallbackTemplate<T1, T2, T3, T4> :
        MethodCallbackTemplateBase<IActionWrapper<T1, T2, T3, T4>>,
        IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T1, T2, T3, T4>>
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
    /// Represents method callback template without return value and 4 parameters.
    /// </summary>    
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fourth parameter.</typeparam>
    public class MethodCallbackTemplate<T1, T2, T3, T4, T5> :
        MethodCallbackTemplateBase<IActionWrapper<T1, T2, T3, T4, T5>>,
        IAcceptor<IMethodCallbackTemplateVisitor, IMethodCallback<T1, T2, T3, T4, T5>>
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

    internal class OnCompleteCallbackVisitor : IMethodCallbackTemplateVisitor
    {
        public IMethodCallback Visit(MethodCallbackTemplate methodCallbackTemplate)
        {
            return new OnCompleteCallback(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T> Visit<T>(MethodCallbackTemplate<T> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T>(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T1, T2> Visit<T1, T2>(MethodCallbackTemplate<T1, T2> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T1, T2>(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T1, T2, T3> Visit<T1, T2, T3>(MethodCallbackTemplate<T1, T2, T3> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T1, T2, T3>(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T1, T2, T3, T4> Visit<T1, T2, T3, T4>(MethodCallbackTemplate<T1, T2, T3, T4> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T1, T2, T3, T4>(methodCallbackTemplate.ActionWrapper.Action);
        }

        public IMethodCallback<T1, T2, T3, T4, T5> Visit<T1, T2, T3, T4, T5>(MethodCallbackTemplate<T1, T2, T3, T4, T5> methodCallbackTemplate)
        {
            return new OnCompleteCallback<T1, T2, T3, T4, T5>(methodCallbackTemplate.ActionWrapper.Action);
        }
    }
}