namespace Attest.Fake.Setup
{
    internal interface IHaveNoDelegateWrapper<TDelegateWrapper>
    {
        IHaveDelegateWrapper<TDelegateWrapper> SetDelegateWrapper(TDelegateWrapper delegateWrapper);
    }

    /// <summary>
    /// Represents an object that contains delegate wrapper.
    /// </summary>
    /// <typeparam name="TDelegateWrapper">The type of the delegate wrapper.</typeparam>
    public interface IHaveDelegateWrapper<TDelegateWrapper>
    {
        /// <summary>
        /// Gets the delegate wrapper.
        /// </summary>
        /// <value>
        /// The delegate wrapper.
        /// </value>
        TDelegateWrapper DelegateWrapper { get; }
    }

    /// <summary>
    /// Base class for objects that contain delegate wrappers.
    /// </summary>
    /// <typeparam name="TDelegateWrapper">The type of the delegate wrapper.</typeparam>
    /// <seealso cref="Setup.IHaveDelegateWrapper{TDelegateWrapper}" />
    /// <seealso cref="Setup.IHaveNoDelegateWrapper{TDelegateWrapper}" />
    public abstract class HaveDelegateWrapperBase<TDelegateWrapper> : IHaveDelegateWrapper<TDelegateWrapper>, IHaveNoDelegateWrapper<TDelegateWrapper>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HaveDelegateWrapperBase{TDelegateWrapper}"/> class.
        /// </summary>
        protected HaveDelegateWrapperBase()
        {
           
        }

        /// <summary>
        /// Gets the delegate wrapper.
        /// </summary>
        /// <value>
        /// The delegate wrapper.
        /// </value>
        public TDelegateWrapper DelegateWrapper
        {
            get;
            private set;
        }        

        /// <summary>
        /// Sets the delegatet wrapper.
        /// </summary>
        /// <param name="delegateWrapper">The delegate wrapper.</param>
        /// <returns></returns>
        public IHaveDelegateWrapper<TDelegateWrapper> SetDelegateWrapper(TDelegateWrapper delegateWrapper)
        {
            DelegateWrapper = delegateWrapper;
            return this;
        }
    }
}