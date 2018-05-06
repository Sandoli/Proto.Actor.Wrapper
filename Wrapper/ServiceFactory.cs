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

            // TODO Make this not throw?
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
            catch (ArgumentException)
            {
                return null;
            }
        }

        public static IServicePid Create(IServiceConfig config)
        {
            switch (config)
            {
                case ServiceConfig concreteConfig:
                    var pid = Actor.Spawn(concreteConfig.Props);
                    return new ServicePid(pid);
            }

            return null;
        }

        //public static IServicePid CreateRemote(IServiceConfig config, )
    }
}