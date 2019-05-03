using Solid.Bootstrapping;
using Solid.Practices.IoC;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Bootstrapping
{
    /// <summary>
    /// Represents base bootstrapper for testing
    /// </summary>
    public abstract class BootstrapperBase :
        Solid.Bootstrapping.BootstrapperBase,       
        IHaveRegistrator
    {        
        //private readonly ExtensibilityAspect<BootstrapperBase> _concreteExtensibilityAspect;        

        /// <summary>
        /// Creates an instance of <see cref="BootstrapperBase"/>
        /// </summary>
        /// <param name="dependencyRegistrator">The dependency registrator</param>
        protected BootstrapperBase(IDependencyRegistrator dependencyRegistrator) =>
            Registrator = dependencyRegistrator;

        /// <inheritdoc />
        public IDependencyRegistrator Registrator { get; }

        //private BootstrapperBase()
        //{
        //    _concreteExtensibilityAspect = new ExtensibilityAspect<BootstrapperBase>(this);
        //}
                
    }    
}