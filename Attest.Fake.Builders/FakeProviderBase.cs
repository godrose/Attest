using System;

namespace Attest.Fake.Builders
{
    public abstract class FakeProviderBase<TBuilder, TService>
        where TService : class
        where TBuilder : FakeBuilderBase<TService>
    {
        protected TService GetService(Func<TBuilder> createBuilder, Func<TBuilder, TBuilder> setupBuilder)
        {
            var builder = createBuilder();
            builder = setupBuilder(builder);
            return builder.GetService();
        }
    }
}
