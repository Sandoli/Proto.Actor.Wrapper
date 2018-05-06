using System;
using System.Threading;
using System.Threading.Tasks;
using Proto;

namespace Wrapper
{
    public interface IServicePid
    {
        void SendMessage(object message);
        void SendSystemMessage(object sys);
        void Request(object message, PID sender);
        Task<T> RequestAsync<T>(object message, TimeSpan timeout);
        Task<T> RequestAsync<T>(object message, CancellationToken cancellationToken);
        Task<T> RequestAsync<T>(object message);
        void Stop();
        string ToShortString();
    }
}