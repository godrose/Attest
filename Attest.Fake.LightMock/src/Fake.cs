using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using LightMock;

namespace Attest.Fake.LightMock
{
    /// <summary>
    /// Implementation of fake using LightMock framework
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public class Fake<TFaked> : IFake<TFaked> where TFaked : class
    {        
        private readonly TFaked _fake;
        private readonly MockContext<TFaked> _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Fake{TFaked}"/> class.
        /// </summary>
        /// <param name="fake">The fake.</param>
        /// <param name="context">The context.</param>
        public Fake(TFaked fake, MockContext<TFaked> context)
        {
            _fake = fake;
            _context = context;
        }

        /// <summary>
        /// Sets up the fake according to the provided setup expression of fake call
        /// </summary>
        /// <param name="expression">Setup expression</param>
        /// <returns>Fake callback after the setup</returns>
        public IFakeCallback Setup(Expression<Action<TFaked>> expression)
        {
            return new LightFakeCallback<TFaked>(_context.Arrange(expression));
        }

        /// <summary>
        /// Sets up the fake according to the provided setup expression of fake call with return value
        /// </summary>
        /// <typeparam name="TResult">Type of return value</typeparam>
        /// <param name="expression">Setup expression</param>
        /// <returns>Fake callback after the setup</returns>
        public IFakeCallbackWithResult<TResult> Setup<TResult>(Expression<Func<TFaked, TResult>> expression)
        {
            return new LightFakeCallbackWithResult<TFaked, TResult>(_context.Arrange(expression));
        }

        /// <summary>
        /// Faked service
        /// </summary>
        public TFaked Object
        {
            get { return _fake; }
        }

        /// <summary>
        /// Verifies that a specific method was called on the fake
        /// </summary>
        /// <param name="expression">Verified method's call definition</param>
        public void VerifyCall(Expression<Action<TFaked>> expression)
        {
            _context.Assert(expression);
        }

        /// <summary>
        /// Verifies that a specific method was not called on the fake
        /// </summary>
        /// <param name="expression">Verified method's call definition</param>
        public void VerifyNoCall(Expression<Action<TFaked>> expression)
        {
            _context.Assert(expression, Invoked.Never);
        }

        /// <summary>
        /// Verifies that a specific method was called exactly once on the fake
        /// </summary>
        /// <param name="expression">Verified method's call definition</param>
        public void VerifySingleCall(Expression<Action<TFaked>> expression)
        {
            _context.Assert(expression, Invoked.Once);
        }
    }
}
