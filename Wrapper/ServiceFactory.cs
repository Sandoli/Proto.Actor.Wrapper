using System;
using Proto;
using Proto.Remote;

//using Proto.Remote;

namespace Wrapper
{
    public static class ServiceFactory
    {
        public static IServiceConfig CreateConfig<T>(string name) where T : IService, new()
        {            
            var props = Actor.FromProducer(() => new ActorAdapter(new T()));  
            
            Remote.RegisterKnownKind(name, props);
            
            return new ServiceConfig(name, props);
        }

        public static IServiceConfig GetConfig(string name)
        {
            try
            {
                var props = Remote.GetKnownKind(name);
                return new ServiceConfig(name, props);
            }
            catch (ArgumentException e)
            {
                return null;
            }
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
        
        //public static IServicePid CreateRemote(IServiceConfig config, )
    }
}