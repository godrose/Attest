using System;

namespace Attest.Fake.Core
{
    public interface IFakeCallbackWithResult<in TResult>
    {
        void Callback(Func<TResult> func);
    }
}