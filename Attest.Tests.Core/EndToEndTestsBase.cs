using Attest.Fake.Core;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    /// <summary>
    /// Base class for all End-To-End fixtures
    /// </summary>
    /// <typeparam name="TContainer">Type of IoC container</typeparam>
    /// <typeparam name="TFakeFactory">Type of fake factory</typeparam>    
    public abstract class EndToEndTestsBase<TContainer, TFakeFactory> : TestsBase<TContainer, TFakeFactory>
        where TContainer : IIocContainer, new()
        where TFakeFactory : IFakeFactory, new()
    {
    }
}
