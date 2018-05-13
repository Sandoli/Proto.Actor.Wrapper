using System;
using System.Threading;
using System.Threading.Tasks;
using Proto;
using UService.Interface;

namespace UService.Wrapper
{
    public class ServicePid : IServicePid
    {
        private readonly PID _pid;

        public ServicePid(PID pid)
        {
            _pid = pid;
        }

        public void SendMessage(object message)
        {
            _pid.Tell(message);
        }

        public void SendSystemMessage(object sys)
        {
            _pid.SendSystemMessage(sys);
        }

        public void Request(object message, IServicePid sender)
        {
            if (sender is ServicePid concreteSender) _pid.Request(message, concreteSender._pid);
        }

        public Task<T> RequestAsync<T>(object message, TimeSpan timeout)
        {
            return _pid.RequestAsync<T>(message, timeout);
        }

        public Task<T> RequestAsync<T>(object message, CancellationToken cancellationToken)
        {
            return _pid.RequestAsync<T>(message, cancellationToken);
        }

        public Task<T> RequestAsync<T>(object message)
        {
            return _pid.RequestAsync<T>(message);
        }

        public void Stop()
        {
            _pid.Stop();
        }

        public string ToShortString()
        {
            return _pid.ToShortString();
        }
    }
}