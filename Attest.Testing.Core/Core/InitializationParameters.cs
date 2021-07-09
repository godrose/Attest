namespace Attest.Testing.Core
{
    /// <summary>
    /// Represents test/scenario initialization parameters.
    /// </summary>
    /// <typeparam name="TContainer">The type of the ioc container.</typeparam>
    public interface IInitializationParameters<TContainer>
    {
        /// <summary>
        /// Gets the ioc container.
        /// </summary>
        /// <value>
        /// The ioc container.
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
