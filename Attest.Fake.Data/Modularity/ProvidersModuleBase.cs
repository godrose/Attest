using Solid.Practices.Modularity;

namespace Attest.Fake.Data.Modularity
{
    /// <summary>
    /// Base module for fake context-based providers.
    /// </summary>    
    /// <seealso cref="Solid.Practices.Modularity.ICompositionModule{TDependencyRegistrator}" />
    public abstract class ProvidersModuleBase<TDependencyRegistrator> : ICompositionModule<TDependencyRegistrator>        
    {
        /// <inheritdoc />        
        public void RegisterModule(TDependencyRegistrator dependencyRegistrator)
        {
            DeserializeBuiders();
            RegisterProviders(dependencyRegistrator);            
        }

        /// <summary>
        /// Override this method to provide custom builders deserialization logic.
        /// </summary>
        protected virtual void DeserializeBuiders()
        {
            BuildersCollectionContext.DeserializeBuilders();
        }

        /// <summary>
        /// Implement this method to register providers.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        protected abstract void RegisterProviders(TDependencyRegistrator dependencyRegistrator);
    }
}