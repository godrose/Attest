using System;
using System.Linq.Expressions;

namespace Attest.Fake.Core
{
    public interface IFake<TFaked> : IMock<TFaked> where TFaked: class
    {
        IFake<TFaked> SetupWithCallback(Expression<Action<TFaked>> expression, Action action);
        IFake<TFaked> SetupWithResult<TResult>(Expression<Func<TFaked, TResult>> expression, TResult result);
        IFake<TFaked> SetupWithException<TResult>(Expression<Func<TFaked, TResult>> expression, Exception exception);
        IFakeCallback Setup(Expression<Action<TFaked>> expression);
        IFakeCallbackWithResult<TResult> Setup<TResult>(Expression<Func<TFaked, TResult>> expression);
    }

    public interface IHaveFake<out TFaked> where TFaked : class
    {
        TFaked Object { get; }
    }
}
