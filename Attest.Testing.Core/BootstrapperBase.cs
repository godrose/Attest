using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Bootstrapping
{
    /// <summary>
    /// Represents base bootstrapper for testing
    /// </summary>
    public abstract class BootstrapperBase :
        Solid.Bootstrapping.BootstrapperBase,       
        IHaveRegistrator,
        IExtensible<BootstrapperBase>
    {        
        private readonly ExtensibilityAspect<BootstrapperBase> _concreteExtensibilityAspect;        

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
            UseAspect(_concreteExtensibilityAspect);
        }

        /// <inheritdoc />
        public BootstrapperBase Use(IMiddleware<BootstrapperBase> middleware)
        {
            _concreteExtensibilityAspect.Use(middleware);
            return this;
        }
    }    
}