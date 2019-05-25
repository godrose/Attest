namespace Attest.Fake.Core
{
    /// <summary>
    /// Factory for creating fakes and mocks
    /// </summary>
    public interface IFakeFactory
    {
        /// <summary>
        /// Returns an instance of fake
        /// </summary>
        /// <typeparam name="TFaked">Type of fake</typeparam>
        /// <returns>Fake instance</returns>
        IFake<TFaked> CreateFake<TFaked>() where TFaked : class;

        /// <summary>
        /// Returns an instance of mock
        /// </summary>
        /// <typeparam name="TFaked">Type of mock</typeparam>
        /// <returns>Mock instance</returns>
        IMock<TFaked> CreateMock<TFaked>() where TFaked : class;
    }
}