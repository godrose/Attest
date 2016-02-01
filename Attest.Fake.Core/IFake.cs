using System;
using System.Linq.Expressions;

namespace Attest.Fake.Core
{
    /// <summary>
    /// Represents the general interface for a fake
    /// </summary>
    /// <typeparam name="TFaked">Type of faked service</typeparam>
    public interface IFake<TFaked> : IMock<TFaked> where TFaked: class
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
}
