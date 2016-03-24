using System;
using System.Linq.Expressions;
using LightMock;

namespace Attest.Fake.LightMock
{
    /// <summary>
    /// Base class for manually created provider proxies.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    public abstract class ProviderProxyBase<TService>
    {
        private readonly IInvocationContext<TService> _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderProxyBase{TService}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected ProviderProxyBase(IInvocationContext<TService> context)
        {
            _context = context;
        }

        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        protected void Invoke(Expression<Action<TService>> method)
        {
            _context.Invoke(method);
        }

        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        protected TResult Invoke<TResult>(Expression<Func<TService, TResult>> method)
        {
            return _context.Invoke(method);
        }
    }
}