using System;
using System.Linq.Expressions;

namespace Attest.Fake.Core
{
    /// <summary>
    /// Represents a mock, i.e. an object that can be tested for various method calls
    /// </summary>
    /// <typeparam name="TFaked">Type of fake</typeparam>
    public interface IMock<TFaked> : IHaveFake<TFaked> where TFaked : class
    {
        /// <summary>
        /// Verifies that a specific method was called on the fake
        /// </summary>
        /// <param name="expression">Verified method's call definition</param>
        void VerifyCall(Expression<Action<TFaked>> expression);
        /// <summary>
        /// Verifies that a specific method was not called on the fake
        /// </summary>
        /// <param name="expression">Verified method's call definition</param>
        void VerifyNoCall(Expression<Action<TFaked>> expression);
        /// <summary>
        /// Verifies that a specific method was called exactly once on the fake
        /// </summary>
        /// <param name="expression">Verified method's call definition</param>
        void VerifySingleCall(Expression<Action<TFaked>> expression);
    }
}
