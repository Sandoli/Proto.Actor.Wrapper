using System.Threading.Tasks;
using Proto;

namespace Wrapper
{
    public interface IContext
    {
        object Message { get; }
    }

    public class Context : IContext
    {
        private readonly Proto.IContext _impl;

        public Context(Proto.IContext impl)
        {
            _impl = impl;
        }

        public object Message => _impl.Message;
    }

    public interface IService
    {
        Task ReceiveAsync(IContext context);
    }

    internal class ActorAdapter : IActor
    {
        private readonly IService _service;

        public ActorAdapter(IService service)
        {
            _service = service;
        }

        public Task ReceiveAsync(Proto.IContext protoContext)
        {
            var context = new Context(protoContext);
            return _service.ReceiveAsync(context);
        }
    }
}