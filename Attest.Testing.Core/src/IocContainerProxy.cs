using System;
using System.Collections.Generic;
using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Static proxy for an instance of <see cref="IIocContainer"/>. 
    /// Used as a surrogate for the real implementation without exposing
    /// the real implementation type.
    /// </summary>   
    public class IocContainerProxy : IIocContainer
    {
        private readonly IDependencyRegistrator _registrator;
        private readonly IDependencyResolver _resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="IocContainerProxy"/> class.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <param name="resolver">The resolver.</param>
        public IocContainerProxy(IDependencyRegistrator registrator, IDependencyResolver resolver)
        {
            _registrator = registrator;
            _resolver = resolver;
        }

        /// <summary>
        /// Registers dependency in a transient lifetime style.
        /// </summary>
        /// <typeparam name="TService">Type of dependency declaration.</typeparam><typeparam name="TImplementation">Type of dependency implementation.</typeparam>
        public void RegisterTransient<TService, TImplementation>() where TImplementation : class, TService
        {
            _registrator.RegisterTransient<TService, TImplementation>();
        }

        public void RegisterTransient<TService, TImplementation>(Func<TImplementation> dependencyCreator) where TImplementation : class, TService
        {
            _registrator.RegisterTransient<TService, TImplementation>(dependencyCreator);
        }

        /// <summary>
        /// Registers dependency in a transient lifetime style.
        /// </summary>
        /// <typeparam name="TService">Type of dependency.</typeparam>
        public void RegisterTransient<TService>() where TService : class
        {
            _registrator.RegisterTransient<TService>();
        }

        /// <summary>
        /// Registers dependency in a transient lifetime style.
        /// </summary>
        /// <typeparam name="TService">Type of dependency.</typeparam>
        /// <param name="dependencyCreator">Dependency creator delegate.</param>
        public void RegisterTransient<TService>(Func<TService> dependencyCreator) where TService : class
        {
            _registrator.RegisterTransient(dependencyCreator);
        }

        /// <summary>
        /// Registers dependency in a transient lifetime style.
        /// </summary>
        /// <param name="serviceType">Type of dependency declaration.</param><param name="implementationType">Type of dependency implementation.</param>
        public void RegisterTransient(Type serviceType, Type implementationType)
        {
            _registrator.RegisterTransient(serviceType, implementationType);
        }

        /// <summary>
        /// Registers dependency in a transient lifetime style.
        /// </summary>
        /// <param name="serviceType">Type of dependency declaration.</param>
        /// <param name="implementationType">Type of dependency implementation.</param>
        /// <param name="dependencyCreator">Dependency creator delegate.</param>
        public void RegisterTransient(Type serviceType, Type implementationType, Func<object> dependencyCreator)
        {
            _registrator.RegisterTransient(serviceType, implementationType, dependencyCreator);
        }

        /// <summary>
        /// Registers dependency as a singleton.
        /// </summary>
        /// <typeparam name="TService">Type of dependency.</typeparam>
        public void RegisterSingleton<TService>() where TService : class
        {
            _registrator.RegisterSingleton<TService>();
        }

        /// <summary>
        /// Registers dependency as a singleton.
        /// </summary>
        /// <typeparam name="TService">Type of dependency.</typeparam>
        /// <param name="dependencyCreator">Dependency creator delegate.</param>
        public void RegisterSingleton<TService>(Func<TService> dependencyCreator) where TService : class
        {
            _registrator.RegisterSingleton(dependencyCreator);
        }

        /// <summary>
        /// Registers dependency as a singleton.
        /// </summary>
        /// <typeparam name="TService">Type of dependency declaration.</typeparam><typeparam name="TImplementation">Type of dependency implementation.</typeparam>
        public void RegisterSingleton<TService, TImplementation>() where TImplementation : class, TService
        {
            _registrator.RegisterSingleton<TService, TImplementation>();
        }

        /// <summary>
        /// Registers dependency as a singleton.
        /// </summary>
        /// <typeparam name="TService">Type of dependency declaration.</typeparam>
        /// <typeparam name="TImplementation">Type of dependency implementation.</typeparam>
        /// <param name="dependencyCreator">Dependency creator delegate.</param>
        public void RegisterSingleton<TService, TImplementation>(Func<TImplementation> dependencyCreator) where TImplementation : class, TService
        {
            _registrator.RegisterSingleton<TService, TImplementation>(dependencyCreator);
        }

        /// <summary>
        /// Registers dependency as a singleton.
        /// </summary>
        /// <param name="serviceType">Type of dependency declaration.</param><param name="implementationType">Type of dependency implementation.</param>
        public void RegisterSingleton(Type serviceType, Type implementationType)
        {
            _registrator.RegisterSingleton(serviceType, implementationType);
        }

        /// <summary>
        /// Registers dependency as a singleton.
        /// </summary>
        /// <param name="serviceType">Type of dependency declaration.</param>
        /// <param name="implementationType">Type of dependency implementation.</param>
        /// <param name="dependencyCreator">Dependency creator delegate.</param>
        public void RegisterSingleton(Type serviceType, Type implementationType, Func<object> dependencyCreator)
        {
            _registrator.RegisterSingleton(serviceType, implementationType, dependencyCreator);
        }

        /// <summary>
        /// Registers an instance of dependency.
        /// </summary>
        /// <typeparam name="TService">Type of dependency.</typeparam><param name="instance">Instance of dependency.</param>
        public void RegisterInstance<TService>(TService instance) where TService : class
        {
            _registrator.RegisterInstance(instance);
        }

        /// <summary>
        /// Registers an instance of dependency.
        /// </summary>
        /// <param name="dependencyType">Type of dependency.</param><param name="instance">Instance of dependency.</param>
        public void RegisterInstance(Type dependencyType, object instance)
        {
            _registrator.RegisterInstance(dependencyType, instance);
        }       

        /// <summary>
        /// Registers the collection of the dependencies.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam><param name="dependencyTypes">The dependency types.</param>
        public void RegisterCollection<TService>(IEnumerable<Type> dependencyTypes) where TService : class
        {
            _registrator.RegisterCollection<TService>(dependencyTypes);
        }

        /// <summary>
        /// Registers the collection of the dependencies.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam><param name="dependencies">The dependencies.</param>
        public void RegisterCollection<TService>(IEnumerable<TService> dependencies) where TService : class
        {
            _registrator.RegisterCollection(dependencies);
        }

        /// <summary>
        /// Registers the collection of the dependencies.
        /// </summary>
        /// <param name="dependencyType">The dependency type.</param><param name="dependencyTypes">The dependency types.</param>
        public void RegisterCollection(Type dependencyType, IEnumerable<Type> dependencyTypes)
        {
            _registrator.RegisterCollection(dependencyType, dependencyTypes);
        }

        /// <summary>
        /// Registers the collection of the dependencies.
        /// </summary>
        /// <param name="dependencyType">The dependency type.</param><param name="dependencies">The dependencies.</param>
        public void RegisterCollection(Type dependencyType, IEnumerable<object> dependencies)
        {
            _registrator.RegisterCollection(dependencyType, dependencies);
        }

        /// <summary>
        /// Resolves an instance of service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns/>
        public TService Resolve<TService>() where TService : class
        {
            return _resolver.Resolve<TService>();
        }

        /// <summary>
        /// Resolves an instance of service according to the service type.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns/>
        public object Resolve(Type serviceType)
        {
            return _resolver.Resolve(serviceType);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            
        }
    }
}