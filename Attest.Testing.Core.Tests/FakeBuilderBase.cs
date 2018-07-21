using Attest.Fake.Core;
using Attest.Fake.Setup;
using Attest.Fake.Setup.Contracts;

namespace Attest.Testing.Core.Tests
{
    /// <summary>
    /// Provides some basic setup. Should consider merging with the original <see cref="Attest.Fake.Builders.FakeBuilderBase{TService}"/>
    /// </summary>
    /// <typeparam name="TProvider"></typeparam>
    internal abstract class FakeBuilderBase<TProvider> : Attest.Fake.Builders.FakeBuilderBase<TProvider> where TProvider : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeBuilderBase{TProvider}"/> class.
        /// </summary>
        protected FakeBuilderBase()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeBuilderBase{TProvider}"/> class
        /// with fake service instance.
        /// </summary>
        /// <param name="fake">The fake.</param>
        protected FakeBuilderBase(IFake<TProvider> fake)
            : base(fake)
        {

        }

        /// <summary>
        /// Creates initial template for the fake setup.
        /// </summary>
        /// <returns></returns>
        private IHaveNoMethods<TProvider> CreateInitialSetup()
        {
            return ServiceCallFactory.CreateServiceCall(FakeService);
        }

        /// <summary>
        /// Sets up the fake service calls.
        /// </summary>
        protected sealed override void SetupFake()
        {
            var initialSetup = CreateInitialSetup();
            var setup = CreateServiceCall(initialSetup);
            setup.Build();
        }

        /// <summary>
        /// Override this method to create service call from the provided template.
        /// </summary>
        /// <param name="serviceCallTemplate">The service call template.</param>
        /// <returns></returns>
        protected abstract IServiceCall<TProvider> CreateServiceCall(IHaveNoMethods<TProvider> serviceCallTemplate);
    }
}