using Solid.Practices.Modularity;

namespace Attest.Fake.Data.Modularity
{
    /// <summary>
    /// Base module for fake context-based providers.
    /// </summary>    
    /// <seealso cref="ICompositionModule{TDependencyRegistrator}" />
    public abstract class ProvidersModuleBase<TDependencyRegistrator> : ICompositionModule<TDependencyRegistrator>        
    {
        private readonly BuildersCollectionContext _buildersCollectionContext = new BuildersCollectionContext();

        /// <inheritdoc />        
        public void RegisterModule(TDependencyRegistrator dependencyRegistrator)
        {
            DeserializeBuilders(_buildersCollectionContext);
            RegisterProviders(dependencyRegistrator, _buildersCollectionContext);
        }

        /// <summary>
        /// Override this method to provide custom builders deserialization logic.
        /// </summary>
        protected virtual void DeserializeBuilders(BuildersCollectionContext buildersCollectionContext)
        {
            buildersCollectionContext.DeserializeBuilders();
        }

        /// <summary>
        /// Implement this method to register providers.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="buildersCollectionContext"></param>
        protected abstract void RegisterProviders(TDependencyRegistrator dependencyRegistrator, BuildersCollectionContext buildersCollectionContext);
    }
}