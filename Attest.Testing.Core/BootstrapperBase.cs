using System.Collections.Generic;
using System.Reflection;
using Solid.Bootstrapping;
using Solid.Common;
using Solid.Core;
using Solid.Extensibility;
using Solid.Practices.Composition;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;
using Solid.Practices.Modularity;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Bootstrapping
{
    /// <summary>
    /// Represents base bootstrapper for testing
    /// </summary>
    public abstract class BootstrapperBase :
        IInitializable,
        IExtensible<BootstrapperBase>,
        IHaveAspects<BootstrapperBase>,
        ICompositionModulesProvider,
        IAssemblySourceProvider,
        IHaveRegistrator
    {
        private ModularityAspect _modularityAspect;
        private DiscoveryAspect _discoveryAspect;
        private readonly ExtensibilityAspect<BootstrapperBase> _concreteExtensibilityAspect;
        private readonly AspectsWrapper _aspectsWrapper = new AspectsWrapper();

        /// <summary>
        /// Creates an instance of <see cref="BootstrapperBase"/>
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator</param>
        protected BootstrapperBase(IDependencyRegistrator dependencyRegistrator) : this() =>
            Registrator = dependencyRegistrator;

        /// <inheritdoc />
        public IDependencyRegistrator Registrator { get; }

        private BootstrapperBase()
        {
            _concreteExtensibilityAspect = new ExtensibilityAspect<BootstrapperBase>(this);
        }

        IEnumerable<ICompositionModule> ICompositionModulesProvider<ICompositionModule>.Modules =>
            _modularityAspect.Modules;

        /// <inheritdoc />
        public BootstrapperBase Use(IMiddleware<BootstrapperBase> middleware)
        {
            return _concreteExtensibilityAspect.Use(middleware);
        }

        /// <summary>
        /// Override this to provide custom composition options
        /// </summary>
        public virtual CompositionOptions CompositionOptions => new CompositionOptions();

        /// <inheritdoc />
        public IEnumerable<Assembly> Assemblies => _discoveryAspect.Assemblies;

        /// <inheritdoc />
        public void Initialize()
        {
            _aspectsWrapper.UseCoreAspects(CreateCoreAspects());
            _aspectsWrapper.Initialize();
        }

        private IEnumerable<IAspect> CreateCoreAspects()
        {
            var aspects = new List<IAspect> { new PlatformAspect() };
            _discoveryAspect = new DiscoveryAspect(CompositionOptions);
            _modularityAspect = new ModularityAspect(_discoveryAspect, CompositionOptions);
            aspects.Add(_discoveryAspect);
            aspects.Add(_modularityAspect);
            aspects.Add(_concreteExtensibilityAspect);
            return aspects;
        }

        /// <inheritdoc />
        public BootstrapperBase UseAspect(IAspect aspect)
        {
            _aspectsWrapper.UseAspect(aspect);
            return this;
        }        
    }
}