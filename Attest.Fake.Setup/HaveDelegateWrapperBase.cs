namespace Attest.Fake.Setup
{
    internal interface IHaveNoDelegateWrapper<TDelegateWrapper>
    {
        IHaveDelegateWrapper<TDelegateWrapper> SetDelegateWrapper(TDelegateWrapper delegateWrapper);
    }

    public interface IHaveDelegateWrapper<TDelegateWrapper>
    {
        TDelegateWrapper DelegateWrapper { get; }
    }

    public abstract class HaveDelegateWrapperBase<TDelegateWrapper> : IHaveDelegateWrapper<TDelegateWrapper>, IHaveNoDelegateWrapper<TDelegateWrapper>
    {
        protected HaveDelegateWrapperBase()
        {
           
        }

        public TDelegateWrapper DelegateWrapper
        {
            get;
            private set;
        }        

        public IHaveDelegateWrapper<TDelegateWrapper> SetDelegateWrapper(TDelegateWrapper delegateWrapper)
        {
            DelegateWrapper = delegateWrapper;
            return this;
        }
    }
}