using System.Threading.Tasks;
using Proto;

namespace UService.Wrapper
{
    public static class Service
    {
        public static readonly Task Done = Actor.Done;
    }
}