using System;
using Attest.Fake.Core;
using Solid.Patterns.Builder;
using Solid.Practices.IoC;

namespace Attest.Fake.Registration
{
    /// <summary>
    /// Provides utilities for registering different types of fake objects into an IoC container.
    /// </summary>
    public static class RegistrationHelper
    {
        /// <summary>
        /// Registers the dependency instance.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="instance">The dependency instance.</param>        
        public static void RegisterInstance<TDependency>(IDependencyRegistrator dependencyRegistrator, TDependency instance) where TDependency : class
        {
            dependencyRegistrator.RegisterInstance(instance);
        }

        /// <summary>
        /// Registers the dependency as singleton.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        public static void RegisterSingleton<TDependency, TImplementation>(IDependencyRegistrator dependencyRegistrator)
            where TImplementation : class, TDependency
        {
            dependencyRegistrator.RegisterSingleton<TDependency, TImplementation>();
        }

        /// <summary>
        /// Registers the dependency in the transient mode.
        /// </summary>
        /// <typeparam name="TService">The type of the dependency.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        public static void RegisterTransient<TService, TImplementation>(IDependencyRegistrator dependencyRegistrator)
            where TImplementation : class, TService
        {
            dependencyRegistrator.RegisterTransient<TService, TImplementation>();
        }

        /// <summary>
        /// Constructs the dependency using the suppiled builder and registers it in transient mode.
        /// </summary>
        /// <typeparam name="TDependency">The type of the service.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="builder">The dependency builder.</param>
        public static void RegisterBuilderProduct<TDependency>(IDependencyRegistrator dependencyRegistrator, IBuilder<TDependency> builder) 
            where TDependency : class
        {
            dependencyRegistrator.RegisterTransient(builder.Build);            
        }

        /// <summary>
        /// Constructs the dependency using the suppiled builder and registers it in transient mode.
        /// </summary>        
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="dependencyType">The type of the dependency.</param>
        /// <param name="builder">The dependency builder.</param>
        public static void RegisterBuilderProduct(IDependencyRegistrator dependencyRegistrator,Type dependencyType, IBuilder builder)
        {
            dependencyRegistrator.RegisterTransient(dependencyType, dependencyType, builder.Build);
        }

        /// <summary>
        /// Registers the dependency as instance.
        /// </summary>
        /// <typeparam name="TDependency">The type of dependency.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="fake">The fake wrapper of the dependency.</param>
        public static void RegisterFake<TDependency>(IDependencyRegistrator dependencyRegistrator, IFake<TDependency> fake) 
            where TDependency : class
        {
            RegisterHaveFake(dependencyRegistrator, fake);
        }

        /// <summary>
        /// Registers dependency as instance.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="dependencyRegistrator">The dependency registrator.</param>
        /// <param name="mock">The mock wrapper of the dependency.</param>
        public static void RegisterMock<TDependency>(IDependencyRegistrator dependencyRegistrator, IMock<TDependency> mock) where TDependency : class
        {
            RegisterHaveFake(dependencyRegistrator, mock);
        }

        private static void RegisterHaveFake<TDependency>(IDependencyRegistrator dependencyRegistrator, IHaveFake<TDependency> fake) where TDependency : class
        {
            RegisterInstance(dependencyRegistrator, fake.Object);
        }

        /// <summary>
        /// Resolves dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency.</typeparam>
        /// <param name="dependencyResolver">The dependency resolver.</param>
        /// <returns>The resolved dependency.</returns>
        public static TDependency Resolve<TDependency>(IDependencyResolver dependencyResolver) where TDependency : class
        {
            return dependencyResolver.Resolve<TDependency>();
        }
    }
}