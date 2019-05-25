using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using Attest.Fake.Setup;
using Attest.Fake.Setup.Contracts;
using Solid.Patterns.Builder;

namespace Attest.Fake.Builders
{
    /// <summary>
    /// Base class for service builders, supporting mock and fake capabilities.
    /// </summary>
    /// <typeparam name="TService">The type of the service</typeparam>    
    public abstract class FakeBuilderBase<TService> : IMock<TService>, IBuilder, IBuilder<TService>
        where TService : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeBuilderBase{TService}"/> class.
        /// </summary>
        protected FakeBuilderBase()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeBuilderBase{TService}"/> class
        /// using the specified fake instance.
        /// </summary>
        /// <param name="fakeService">The instance of the fake service.</param>
        protected FakeBuilderBase(IFake<TService> fakeService)
        {
            _fakeService = fakeService;
        }

        private IFake<TService> _fakeService;
        /// <summary>
        /// Fake service.
        /// </summary>                    
        protected IFake<TService> FakeService => _fakeService ??
                                                 (_fakeService =
                                                     FakeFactoryContext.Current.CreateFake<TService>());

        /// <summary>
        /// Override this method to substitute method calls in the faked service.
        /// </summary>
        protected abstract void SetupFake();

        private TService BuildImpl()
        {
            SetupFake();
            return FakeService.Object;
        }

        /// <summary>
        /// Verifies that the method on the fake was called.
        /// </summary>
        /// <param name="expression">Method definition.</param>
        public void VerifyCall(Expression<Action<TService>> expression)
        {
            FakeService.VerifyCall(expression);
        }

        /// <summary>
        /// Verifies that the method on the fake was not called.
        /// </summary>
        /// <param name="expression">Method definition.</param>
        public void VerifyNoCall(Expression<Action<TService>> expression)
        {
            FakeService.VerifyNoCall(expression);
        }

        /// <summary>
        /// Verifies that the method on the fake was called exactly once.
        /// </summary>
        /// <param name="expression">Method definition.</param>
        public void VerifySingleCall(Expression<Action<TService>> expression)
        {
            FakeService.VerifySingleCall(expression);
        }

        /// <inheritdoc />
        public TService Object => FakeService.Object;

        object IBuilder.Build()
        {
            return BuildImpl();
        }

        TService IBuilder<TService>.Build()
        {
            return BuildImpl();
        }

        /// <summary>
        /// Base class for service builders, supporting mock and fake capabilities.
        /// This class supports basic initial setup.
        /// This is the recommended way of using <see cref="FakeBuilderBase{TService}"/>
        /// </summary>
        public abstract class WithInitialSetup : FakeBuilderBase<TService>
        {
            /// <inheritdoc />           
            protected sealed override void SetupFake()
            {
                var initialSetup = CreateInitialSetup();
                var setup = CreateServiceCall(initialSetup);
                setup.Build();
            }

            /// <summary>
            /// Creates initial template for the fake setup.
            /// </summary>
            /// <returns></returns>
            private IHaveNoMethods<TService> CreateInitialSetup()
            {
                return ServiceCallFactory.CreateServiceCall(FakeService);
            }

            /// <summary>
            /// Override this method to create service call from the provided template.
            /// </summary>
            /// <param name="serviceCallTemplate">The service call template.</param>
            /// <returns></returns>
            protected abstract IServiceCall<TService> CreateServiceCall(IHaveNoMethods<TService> serviceCallTemplate);
        }
    }
}
