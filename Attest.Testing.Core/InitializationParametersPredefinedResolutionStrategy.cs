namespace Attest.Testing.Core
{
    class InitializationParametersPredefinedResolutionStrategy<TContainer>
        : IInitializationParametersResolutionStrategy<TContainer> where TContainer : new()
    {
        private readonly TContainer _container;

        public InitializationParametersPredefinedResolutionStrategy(TContainer container)
        {
            _container = container;
        }

        public IInitializationParameters<TContainer> GetInitializationParameters()
        {
            return new InitializationParameters<TContainer>(_container);
        }
    }
}