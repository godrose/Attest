using Attest.Testing.Core.FakeData.Shared;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Attest.Testing.Core.FakeData.Modularity
{
    /// <summary>
    /// Base module for fake context-based providers.
    /// </summary>    
    /// <seealso cref="Solid.Practices.Modularity.ICompositionModule{IDependencyRegistrator}" />
    public abstract class ProvidersModuleBase : ICompositionModule<IDependencyRegistrator>        
    {
        /// <inheritdoc />        
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            BuildersCollectionContext.DeserializeBuilders();
            OnRegisterProviders(dependencyRegistrator);            
        }

        /// <summary>
        /// Override this method to inject additional functionality into providers' registration flow.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        protected virtual void OnRegisterProviders(IDependencyRegistrator dependencyRegistrator)
        {

        }        
    }
}