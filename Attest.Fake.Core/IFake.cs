using System;
using System.Linq.Expressions;

namespace Attest.Fake.Core
{
    /// <summary>
    /// Represents an abstraction for a fake object.
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public interface IFake<TFaked> : IMock<TFaked>, IEventInvocator<TFaked> where TFaked: class
    {        
        /// <summary>
        /// Sets up the fake according to the provided setup expression of fake call
        /// </summary>
        /// <param name="expression">Setup expression</param>
        /// <returns>Fake callback after the setup</returns>
        IFakeCallback Setup(Expression<Action<TFaked>> expression);

        /// <summary>
        /// Sets up the fake according to the provided setup expression of fake call with return value
        /// </summary>
        /// <typeparam name="TResult">Type of return value</typeparam>
        /// <param name="expression">Setup expression</param>
        /// <returns>Fake callback after the setup</returns>
        IFakeCallbackWithResult<TResult> Setup<TResult>(Expression<Func<TFaked, TResult>> expression);
    }

    /// <summary>
    /// Represents means for raising events on a fake object.
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public interface IEventInvocator<TFaked> where TFaked: class
    {
        /// <summary>
        /// Raises the specified event on the fake object.
        /// </summary>
        /// <param name="eventExpression">The event to be raised.</param>
        /// <param name="eventArgs">The event arguments.</param>
        void Raise(Action<TFaked> eventExpression, EventArgs eventArgs);
    }
}
