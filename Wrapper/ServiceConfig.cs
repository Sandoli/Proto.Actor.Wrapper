using Proto;

namespace Wrapper
{
    public class ServiceConfig : IServiceConfig
    {
        internal readonly Props Props;

        public ServiceConfig(Props props)
        {
            Props = props;
        }
    }
}