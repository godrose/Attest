using Attest.Fake.Core;

namespace Attest.Fake.FakeItEasy
{
    /// <summary>
    /// Implementation of <see cref="IFakeFactory"/> using FakeItEasy framework
    /// </summary>
    public class FakeFactory : IFakeFactory
    {
        /// <summary>
        /// Returns an instance of fake
        /// </summary>
        /// <typeparam name="TFaked">Type of fake</typeparam>
        /// <returns>Fake instance</returns>
        public IFake<TFaked> CreateFake<TFaked>() where TFaked : class
        {
            return CreateFakeImpl<TFaked>();
        }

        /// <summary>
        /// Return an instance of mock
        /// </summary>
        /// <typeparam name="TFaked">Type of mock</typeparam>
        /// <returns>Mock instance</returns>
        public IMock<TFaked> CreateMock<TFaked>() where TFaked : class
        {
            return CreateFakeImpl<TFaked>();
        }

        private static IFake<TFaked> CreateFakeImpl<TFaked>() where TFaked : class
        {
            return new Fake<TFaked>();
        }
    }
}
