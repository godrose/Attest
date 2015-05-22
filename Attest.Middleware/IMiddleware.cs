using Solid.Practices.IoC;

namespace Attest.Middleware
{
    public interface IMiddleware
    {
        void Apply(IIocContainer iocContainer);
    }
}
