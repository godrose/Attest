using System;
using Solid.Patterns.Builder;

namespace Attest.Fake.Builders
{
    /// <summary>
    /// Base class for data/model providers
    /// </summary>
    /// <typeparam name="TBuilder">Type of builder</typeparam>
    /// <typeparam name="TService">Type of service</typeparam>
    public abstract class FakeProviderBase<TBuilder, TService>
        where TService : class
        where TBuilder : IBuilder<TService>
    {
        private readonly TBuilder _builder;

        /// <summary>
        /// Create an instance of the <see cref="FakeProviderBase{TBuilder,TService}"/>
        /// </summary>
        protected FakeProviderBase()
        {
            
        }

        /// <summary>
        /// Create an instance of the <see cref="FakeProviderBase{TBuilder,TService}"/> 
        /// using provided builder instance.
        /// </summary>
        /// <param name="builder"></param>
        protected FakeProviderBase(TBuilder builder)
            :this()
        {
            _builder = builder;
        }

        /// <summary>
        /// Gets an instance of the faked service, after the builder setup is applied.
        /// </summary>
        /// <param name="createBuilder">Builder instantiation function</param>
        /// <param name="setupBuilder">Builder setup function</param>
        /// <returns>Instance of service after the setup is applied</returns>
        protected TService GetService(Func<TBuilder> createBuilder, Func<TBuilder, TBuilder> setupBuilder)
        {
            return GetServiceImpl(createBuilder(), setupBuilder);
        }

        /// <summary>
        /// Gets an instance of the faked service, after the builder setup is applied.
        /// </summary>
        /// <param name="setupBuilder">Builder setup function</param>
        /// <returns>Instance of service after the setup is applied</returns>
        protected TService GetService(Func<TBuilder, TBuilder> setupBuilder)
        {
            return GetServiceImpl(_builder, setupBuilder);
        }

        /// <summary>
        /// Gets an instance of the faked service.
        /// </summary>        
        /// <returns>Instance of service</returns>
        protected TService GetService()
        {
            return _builder.Build();
        }

        private TService GetServiceImpl(TBuilder builder, Func<TBuilder, TBuilder> setupBuilder)
        {            
            builder = setupBuilder(builder);
            return builder.Build();
        }
    }
}
