namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a service call which has no method calls yet.
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IHaveNoMethods<TService> : ICanAddMethods<TService> where TService : class
    {
    }
}