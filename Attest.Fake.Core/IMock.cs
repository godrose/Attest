using System;
using System.Linq.Expressions;

namespace Attest.Fake.Core
{
    public interface IMock<TFaked> : IHaveFake<TFaked> where TFaked : class
    {
        void VerifyCall(Expression<Action<TFaked>> expression);
        void VerifyNoCall(Expression<Action<TFaked>> expression);
        void VerifySingleCall(Expression<Action<TFaked>> expression);
    }
}
