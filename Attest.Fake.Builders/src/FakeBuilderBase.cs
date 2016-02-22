using System;
using System.Linq.Expressions;
using Attest.Fake.Core;

namespace Attest.Fake.Builders
{
    /// <summary>
    /// Base class for service builders, supporting mock and fake capabilties
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    [Serializable]
    public abstract class FakeBuilderBase<TService> : IMock<TService> where TService : class
    {
        private IFake<TService> _fakeService;
        /// <summary>
        /// Fake that wraps the faked service
        /// </summary>                    
        protected IFake<TService> FakeService
        {
            get { return _fakeService ?? (_fakeService = FakeFactoryContext.Current.CreateFake<TService>()); }
        }

        /// <summary>
        /// Override this method to substitute method calls in the faked service
        /// </summary>
        protected abstract void SetupFake();

        /// <summary>
        /// Sets up the fake and gets the faked service
        /// </summary>
        /// <returns></returns>
        public TService GetService()
        {
            SetupFake();
            return FakeService.Object;
        }

        /// <summary>
        /// Verifies that the method on the fake was called
        /// </summary>
        /// <param name="expression">Method definition</param>
        public void VerifyCall(Expression<Action<TService>> expression)
        {
            FakeService.VerifyCall(expression);
        }

        /// <summary>
        /// Verifies that the method on the fake was not called
        /// </summary>
        /// <param name="expression">Method definition</param>
        public void VerifyNoCall(Expression<Action<TService>> expression)
        {
            FakeService.VerifyNoCall(expression);
        }

        /// <summary>
        /// Verifies that the method on the fake was called exacty once
        /// </summary>
        /// <param name="expression">Method definition</param>
        public void VerifySingleCall(Expression<Action<TService>> expression)
        {
            FakeService.VerifySingleCall(expression);
        }

        /// <summary>
        /// Faked service
        /// </summary>
        public TService Object
        {
            get { return FakeService.Object; }
        }
    }
}
