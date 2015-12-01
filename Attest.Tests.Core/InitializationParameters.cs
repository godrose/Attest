namespace Attest.Tests.Core
{
    public interface IInitializationParameters<TContainer>
    {
        TContainer IocContainer { get; }
    }

    class InitializationParameters<TContainer> : IInitializationParameters<TContainer>
    {
        public InitializationParameters(TContainer iocContainer)
        {
            IocContainer = iocContainer;
        }

        public TContainer IocContainer { get; private set; }
    }

}
