using System.Threading.Tasks;
using Proto;

namespace Wrapper
{
    public static class Service
    {
        public static readonly Task Done = Actor.Done;
    }
}