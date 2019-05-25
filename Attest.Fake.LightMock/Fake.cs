using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using LightMock;

namespace Attest.Fake.LightMock
{
    /// <summary>
    /// Implementation of fake using <see cref="LightMock"/>
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public class Fake<TFaked> : IFake<TFaked> where TFaked : class
    {
        private readonly MockContext<TFaked> _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Fake{TFaked}"/> class.
        /// </summary>
        /// <param name="fake">The fake.</param>
        /// <param name="context">The context.</param>
        public Fake(TFaked fake, MockContext<TFaked> context)
        {
            Object = fake;
            _context = context;
        }

        /// <inheritdoc />       
        public IFakeCallback Setup(Expression<Action<TFaked>> expression)
        {
            return new LightFakeCallback<TFaked>(_context.Arrange(expression));
        }

        /// <inheritdoc />        
        public IFakeCallbackWithResult<TResult> Setup<TResult>(Expression<Func<TFaked, TResult>> expression)
        {
            return new LightFakeCallbackWithResult<TFaked, TResult>(_context.Arrange(expression));
        }

        /// <inheritdoc />      
        public TFaked Object { get; }

        /// <inheritdoc />       
        public void VerifyCall(Expression<Action<TFaked>> expression)
        {
            _context.Assert(expression);
        }

        /// <inheritdoc />       
        public void VerifyNoCall(Expression<Action<TFaked>> expression)
        {
            _context.Assert(expression, Invoked.Never);
        }

        /// <inheritdoc />       
        public void VerifySingleCall(Expression<Action<TFaked>> expression)
        {
            _context.Assert(expression, Invoked.Once);
        }

        /// <inheritdoc />
        public void Raise(Action<TFaked> eventExpression, EventArgs eventArgs)
        {            
            throw new NotImplementedException("Raising events is not supported with LightMock");
        }
    }
}
