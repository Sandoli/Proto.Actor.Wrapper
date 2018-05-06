using System;
using System.Threading.Tasks;
using Proto;

namespace Wrapper
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
    }
}