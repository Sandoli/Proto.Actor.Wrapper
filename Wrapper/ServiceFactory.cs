using Proto;

namespace Wrapper
{
    public static class ServiceFactory
    {
        public static IServiceConfig CreateConfig<T>() where T : IService, new()
        {            
            var props = Actor.FromProducer(() => new ActorAdapter(new T()));  
            return new ServiceConfig(props);
        }

        public static IServicePid Create(IServiceConfig config)
        {
            if (config is ServiceConfig concreteConfig)
            {
                var pid = Actor.Spawn(concreteConfig.Props);

                return new ServicePid(pid);
            }

            return null;
        }
    }
}