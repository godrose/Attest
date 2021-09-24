using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using Moq;

namespace Attest.Fake.Moq
{
    /// <summary>
    /// Implementation of fake using <see cref="Moq"/> framework
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public class Fake<TFaked> : IFake<TFaked> where TFaked: class
    {
        private readonly Mock<TFaked> _fake;

        internal Fake(Mock<TFaked> fake)
        {
            _fake = fake;
        }

        /// <inheritdoc />       
        public IFakeCallback Setup(Expression<Action<TFaked>> expression)
        {
            return new MoqFakeCallback<TFaked>(_fake.Setup(expression));
        }

        /// <inheritdoc />       
        public IFakeCallbackWithResult<TResult> Setup<TResult>(Expression<Func<TFaked, TResult>> expression)
        {
            return new MoqFakeCallbackWithResult<TFaked, TResult>(_fake.Setup(expression));
        }

        /// <inheritdoc />        
        public TFaked Object => _fake.Object;

        /// <inheritdoc />       
        public void VerifyCall(Expression<Action<TFaked>> expression)
        {
            _fake.Verify(expression);
        }

        /// <inheritdoc />       
        public void VerifyNoCall(Expression<Action<TFaked>> expression)
        {
            _fake.Verify(expression, Times.Never);
        }

        /// <inheritdoc />     
        public void VerifySingleCall(Expression<Action<TFaked>> expression)
        {
            _fake.Verify(expression, Times.Once);
        }

        /// <inheritdoc />
        public void Raise(Action<TFaked> eventExpression, EventArgs eventArgs)
        {
            _fake.Raise(eventExpression, eventArgs);
        }
    }
}
