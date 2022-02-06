using Solid.Practices.Middleware;

namespace Attest.Fake.Moq
{
    /// <summary>
    /// This middleware allows using Moq as fake functionality provider.
    /// </summary>
    /// <typeparam name="TExtensible"></typeparam>
    public class UseMoqMiddleware<TExtensible> : IMiddleware<TExtensible>
        where TExtensible : class
    {
        /// <inheritdoc/>
        public TExtensible Apply(TExtensible @object)
        {
            @object.UseMoq();
            return @object;
        }
    }
}
