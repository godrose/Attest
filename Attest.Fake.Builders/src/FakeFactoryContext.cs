using Attest.Fake.Core;

namespace Attest.Fake.Builders
{
    /// <summary>
    /// Ambient context for <see cref="IFakeFactory"/>
    /// </summary>
    public static class FakeFactoryContext
    {
        private static IFakeFactory _fakeFactory;

        /// <summary>
        /// Gets or sets the current value of <see cref="IFakeFactory"/>.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static IFakeFactory Current
        {
            get { return _fakeFactory; }
            set { _fakeFactory = value; }
        }
    }
}
