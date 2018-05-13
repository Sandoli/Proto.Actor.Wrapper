using UService.Interface;

namespace UService.Wrapper
{
    public class Context : IContext
    {
        private readonly Proto.IContext _impl;

        public Context(Proto.IContext impl)
        {
            _impl = impl;
        }

        public object Message => _impl.Message;
    }
}