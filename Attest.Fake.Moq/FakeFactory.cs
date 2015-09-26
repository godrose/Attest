using Attest.Fake.Core;
using Moq;

namespace Attest.Fake.Moq
{
    /// <summary>
    /// Implementation of fake factory using Moq framework
    /// </summary>
    public class FakeFactory : IFakeFactory
    {
        public IFake<TFaked> CreateFake<TFaked>() where TFaked : class
        {
            return CreateFakeImpl<TFaked>();
        }

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
