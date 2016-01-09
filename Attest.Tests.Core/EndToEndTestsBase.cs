using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    /// <summary>
    /// Base class for all End-To-End fixtures
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container</typeparam>
    public abstract class EndToEndTestsBase<TContainer> : TestsBase<TContainer>
        where TContainer : IIocContainer, new()
    {
    }
}
