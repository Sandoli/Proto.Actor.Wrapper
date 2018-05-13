using System.Threading.Tasks;

namespace UService.Interface
{
    public interface IService
    {
        Task ReceiveAsync(IContext context);
    }
}