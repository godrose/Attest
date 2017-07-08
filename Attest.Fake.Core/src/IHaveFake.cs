namespace Attest.Fake.Core
{
    /// <summary>
    /// Represents an object that contains a to-be-faked service of another type
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public interface IHaveFake<out TFaked> where TFaked : class
    {
        /// <summary>
        /// Faked service
        /// </summary>
        TFaked Object { get; }
    }
}