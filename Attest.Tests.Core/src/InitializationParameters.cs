namespace Attest.Tests.Core
{
    /// <summary>
    /// Represents test/scenario initialization parameters
    /// </summary>
    /// <typeparam name="TContainer">The type of the container.</typeparam>
    public interface IInitializationParameters<TContainer>
    {
        /// <summary>
        /// Gets the IoC container.
        /// </summary>
        /// <value>
        /// The IoC container.
        /// </value>
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
