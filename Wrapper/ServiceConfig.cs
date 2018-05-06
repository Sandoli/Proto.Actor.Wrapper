using Proto;

namespace Wrapper
{
    public class ServiceConfig : IServiceConfig
    {
        public string Name { get; }
        internal readonly Props Props;

        public ServiceConfig(string name, Props props)
        {
            Name = name;
            Props = props;
        }
    }
}