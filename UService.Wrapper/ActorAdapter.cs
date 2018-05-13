using System.Threading.Tasks;
using Proto;
using UService.Interface; 

namespace UService.Wrapper
{
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