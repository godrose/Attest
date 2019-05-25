using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using FakeItEasy;

namespace Attest.Fake.FakeItEasy
{
    /// <summary>
    /// Implementation of fake using <see cref="FakeItEasy"/>
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public class Fake<TFaked> : IFake<TFaked> where TFaked : class
    {
        /// <inheritdoc />       
        public void VerifyCall(Expression<Action<TFaked>> expression)
        {
            A.CallTo(() => expression).MustHaveHappened();            
        }

        /// <inheritdoc />      
        public void VerifyNoCall(Expression<Action<TFaked>> expression)
        {
            A.CallTo(expression).MustNotHaveHappened();
        }

        /// <inheritdoc />       
        public void VerifySingleCall(Expression<Action<TFaked>> expression)
        {
            A.CallTo(expression).MustHaveHappenedOnceExactly();
        }

        /// <inheritdoc />       
        public IFakeCallback Setup(Expression<Action<TFaked>> expression)
        {
            return new EasyFakeCallback<TFaked>(A.CallTo(expression));
        }

        /// <inheritdoc />       
        public IFakeCallbackWithResult<TResult> Setup<TResult>(Expression<Func<TFaked, TResult>> expression)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />       
        public TFaked Object { get; } = A.Fake<TFaked>();

        /// <inheritdoc />
        public void Raise(Action<TFaked> eventExpression, EventArgs eventArgs)
        {
            throw new NotImplementedException("Raising events is not supported with FakeItEasy");
        }
    }
}
