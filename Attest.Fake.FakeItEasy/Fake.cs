using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using FakeItEasy;

namespace Attest.Fake.FakeItEasy
{
    /// <summary>
    /// Implementation of fake using FakeItEasy framework
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public class Fake<TFaked> : IFake<TFaked> where TFaked : class
    {
        private readonly TFaked _fake = A.Fake<TFaked>();

        public void VerifyCall(Expression<Action<TFaked>> expression)
        {
            A.CallTo(expression).MustHaveHappened();
        }

        public void VerifyNoCall(Expression<Action<TFaked>> expression)
        {
            A.CallTo(expression).MustNotHaveHappened();
        }

        public void VerifySingleCall(Expression<Action<TFaked>> expression)
        {
            A.CallTo(expression).MustHaveHappened(Repeated.Exactly.Once);
        }

        public IFakeCallback Setup(Expression<Action<TFaked>> expression)
        {
            return new EasyFakeCallback<TFaked>(A.CallTo(expression));
        }

        public IFakeCallbackWithResult<TResult> Setup<TResult>(Expression<Func<TFaked, TResult>> expression)
        {            
            throw new NotImplementedException();
        }

        public TFaked Object
        {
            get { return _fake; }
        }
    }
}
