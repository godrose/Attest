using Attest.Fake.Core;

namespace Attest.Fake.Moq
{
    /// <summary>
    /// The registrator extensions.
    /// </summary>
    public static class RegistratorExtensions
    {
        /// <summary>
        /// Registers Moq services as fake functionality providers.
        /// </summary>
        /// <typeparam name="TExtensible"></typeparam>
        /// <param name="extensible"></param>
        /// <returns></returns>
        public static TExtensible UseMoq<TExtensible>(
            this TExtensible extensible)
            where TExtensible : class
        {
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
            return extensible;
        }
    }
}
