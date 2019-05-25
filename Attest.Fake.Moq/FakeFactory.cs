using Attest.Fake.Core;
using Moq;

namespace Attest.Fake.Moq
{
    /// <summary>
    /// Implementation of fake factory using Moq framework
    /// </summary>    
    public class FakeFactory : IFakeFactory
    {
        /// <summary>
        /// Returns an instance of fake.
        /// </summary>
        /// <typeparam name="TFaked">Type of fake</typeparam>
        /// <returns>Fake instance</returns>
        public IFake<TFaked> CreateFake<TFaked>() where TFaked : class
        {
            return CreateFakeImpl<TFaked>();
        }

        /// <summary>
        /// Return an instance of mock.
        /// </summary>
        /// <typeparam name="TFaked">Type of mock</typeparam>
        /// <returns>Mock instance</returns>
        public Core.IMock<TFaked> CreateMock<TFaked>() where TFaked : class
        {
            return CreateFakeImpl<TFaked>();
        }

        private static IFake<TFaked> CreateFakeImpl<TFaked>() where TFaked : class
        {
            return new Fake<TFaked>(new Mock<TFaked>(MockBehavior.Default));
        }
    }
}
