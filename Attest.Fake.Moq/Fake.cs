using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using Moq;

namespace Attest.Fake.Moq
{
    public class Fake<TFaked> : IFake<TFaked> where TFaked: class
    {
        private readonly Mock<TFaked> _fake;

        internal Fake(Mock<TFaked> fake)
        {
            _fake = fake;
        }

        public IFake<TFaked> SetupWithCallback(Expression<Action<TFaked>> expression, Action action)
        {
            _fake.Setup(expression).Callback(action);
            return this;
        }

        public IFake<TFaked> SetupWithResult<TResult>(Expression<Func<TFaked, TResult>> expression, TResult result)
        {
            _fake.Setup(expression).Returns(result);
            return this;
        }

        public IFake<TFaked> SetupWithException<TResult>(Expression<Func<TFaked, TResult>> expression, Exception exception)
        {           
            _fake.Setup(expression).Throws(exception);
            return this;
        }

        public IFakeCallback Setup(Expression<Action<TFaked>> expression)
        {
            return new MoqFakeCallback<TFaked>(_fake.Setup(expression));
        }

        public IFakeCallbackWithResult<TResult> Setup<TResult>(Expression<Func<TFaked, TResult>> expression)
        {
            return new MoqFakeCallbackWithResult<TFaked, TResult>(_fake.Setup(expression));
        }

        public TFaked Object
        {
            get { return _fake.Object; }
        }

        public void VerifyCall(Expression<Action<TFaked>> expression)
        {
            _fake.Verify(expression);
        }

        public void VerifyNoCall(Expression<Action<TFaked>> expression)
        {
            _fake.Verify(expression, Times.Never);
        }

        public void VerifySingleCall(Expression<Action<TFaked>> expression)
        {
            _fake.Verify(expression, Times.Once);
        }
    }
}
