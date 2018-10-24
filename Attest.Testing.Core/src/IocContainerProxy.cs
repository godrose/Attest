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

        /// <inheritdoc />
        public void RegisterTransient<TService, TImplementation>() where TImplementation : class, TService
        {
            _registrator.RegisterTransient<TService, TImplementation>();
        }

        /// <inheritdoc />
        public void RegisterTransient<TService, TImplementation>(Func<TImplementation> dependencyCreator) where TImplementation : class, TService
        {
            _registrator.RegisterTransient<TService, TImplementation>(dependencyCreator);
        }

        /// <inheritdoc />
        public void RegisterTransient<TService>() where TService : class
        {
            _registrator.RegisterTransient<TService>();
        }

        /// <inheritdoc />
        public void RegisterTransient<TService>(Func<TService> dependencyCreator) where TService : class
        {
            _registrator.RegisterTransient(dependencyCreator);
        }

        /// <inheritdoc />
        public void RegisterTransient(Type serviceType, Type implementationType)
        {
            _registrator.RegisterTransient(serviceType, implementationType);
        }

        /// <inheritdoc />
        public void RegisterTransient(Type serviceType, Type implementationType, Func<object> dependencyCreator)
        {
            _registrator.RegisterTransient(serviceType, implementationType, dependencyCreator);
        }

        /// <inheritdoc />
        public void RegisterSingleton<TService>() where TService : class
        {
            _registrator.RegisterSingleton<TService>();
        }

        /// <inheritdoc />
        public void RegisterSingleton<TService>(Func<TService> dependencyCreator) where TService : class
        {
            _registrator.RegisterSingleton(dependencyCreator);
        }

        /// <inheritdoc />
        public void RegisterSingleton<TService, TImplementation>() where TImplementation : class, TService
        {
            _registrator.RegisterSingleton<TService, TImplementation>();
        }

        /// <inheritdoc />
        public void RegisterSingleton<TService, TImplementation>(Func<TImplementation> dependencyCreator) where TImplementation : class, TService
        {
            _registrator.RegisterSingleton<TService, TImplementation>(dependencyCreator);
        }

        /// <inheritdoc />
        public void RegisterSingleton(Type serviceType, Type implementationType)
        {
            _registrator.RegisterSingleton(serviceType, implementationType);
        }

        /// <inheritdoc />
        public void RegisterSingleton(Type serviceType, Type implementationType, Func<object> dependencyCreator)
        {
            _registrator.RegisterSingleton(serviceType, implementationType, dependencyCreator);
        }

        /// <inheritdoc />
        public void RegisterInstance<TService>(TService instance) where TService : class
        {
            _registrator.RegisterInstance(instance);
        }

        /// <inheritdoc />
        public void RegisterInstance(Type dependencyType, object instance)
        {
            _registrator.RegisterInstance(dependencyType, instance);
        }       

        /// <inheritdoc />
        public void RegisterCollection<TService>(IEnumerable<Type> dependencyTypes) where TService : class
        {
            _registrator.RegisterCollection<TService>(dependencyTypes);
        }

        /// <inheritdoc />
        public void RegisterCollection<TService>(IEnumerable<TService> dependencies) where TService : class
        {
            _registrator.RegisterCollection(dependencies);
        }

        /// <inheritdoc />
        public void RegisterCollection(Type dependencyType, IEnumerable<Type> dependencyTypes)
        {
            _registrator.RegisterCollection(dependencyType, dependencyTypes);
        }

        /// <inheritdoc />
        public void RegisterCollection(Type dependencyType, IEnumerable<object> dependencies)
        {
            _registrator.RegisterCollection(dependencyType, dependencies);
        }

        /// <inheritdoc />
        public TService Resolve<TService>() where TService : class
        {
            return _resolver.Resolve<TService>();
        }

        /// <inheritdoc />
        public object Resolve(Type serviceType)
        {
            return _resolver.Resolve(serviceType);
        }

        /// <inheritdoc />
        public IEnumerable<TDependency> ResolveAll<TDependency>() where TDependency : class
        {
            return _resolver.ResolveAll<TDependency>();
        }

        /// <inheritdoc />
        public IEnumerable<object> ResolveAll(Type dependencyType)
        {
            return _resolver.ResolveAll(dependencyType);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            
        }
    }
}