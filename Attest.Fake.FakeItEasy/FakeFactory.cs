using Attest.Fake.Core;

namespace Attest.Fake.FakeItEasy
{
    /// <summary>
    /// Implementation of Fake Factory using FakeItEasy framework
    /// </summary>
    public class FakeFactory : IFakeFactory
    {
        public IFake<TFaked> CreateFake<TFaked>() where TFaked : class
        {
            return CreateFakeImpl<TFaked>();
        }        

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
