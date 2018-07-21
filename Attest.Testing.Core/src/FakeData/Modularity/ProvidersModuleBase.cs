using System;
using System.Linq;
using Attest.Testing.Core.FakeData.Shared;
using Solid.Patterns.Builder;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;
using RegistrationHelper = Attest.Fake.Registration.RegistrationHelper;

namespace Attest.Testing.Core.FakeData.Modularity
{
    /// <summary>
    /// Base module for fake context-based providers.
    /// </summary>    
    /// <seealso cref="Solid.Practices.Modularity.ICompositionModule{IDependencyRegistrator}" />
    public abstract class ProvidersModuleBase : ICompositionModule<IDependencyRegistrator>        
    {
        /// <summary>
        /// Registers composition module.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            BuildersCollectionContext.DeserializeBuilders();
            OnRegisterProviders(dependencyRegistrator);            
        }

        /// <summary>
        /// Override this method to register application providers.
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        protected virtual void OnRegisterProviders(IDependencyRegistrator dependencyRegistrator)
        {

        }

        /// <summary>
        /// Registers all builders of the given provider type.
        /// </summary>
        /// <typeparam name="TProvider">The type of the provider.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="defaultBuilderCreationFunc">The default builder creation function.</param>
        protected void RegisterAllBuilders<TProvider>(IDependencyRegistrator dependencyRegistrator, 
            Func<IBuilder<TProvider>> defaultBuilderCreationFunc) where TProvider : class
        {
            var builders = BuildersCollectionContext.GetBuilders<TProvider>().ToArray();
            if (builders.Length == 0)
            {
                RegistrationHelper.RegisterBuilder(dependencyRegistrator, defaultBuilderCreationFunc());
            }
            else
            {
                foreach (var builder in builders)
                {
                    RegistrationHelper.RegisterBuilder(dependencyRegistrator, builder);
                }
            }
        }
    }
}