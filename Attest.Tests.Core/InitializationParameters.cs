namespace Attest.Tests.Core
{
    public interface IInitializationParameters<TBootstrapper, TContainer>
    {
        TContainer IocContainer { get; }
    }

    class InitializationParameters<TBootstrapper, TContainer> : IInitializationParameters<TBootstrapper, TContainer>
    {
        public InitializationParameters(TContainer iocContainer)
        {
            IocContainer = iocContainer;
        }

        public TContainer IocContainer { get; private set; }
    }

}
