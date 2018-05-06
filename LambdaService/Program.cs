using System;
using System.Threading;
using System.Threading.Tasks;
using Messages;
using Wrapper;

namespace LambdaService
{
//    public class Service1 : IService
//    {
//        
//    }

    public class Service1 : IService
    {
        public Task ReceiveAsync(IContext context)
        {
            if (context.Message is Hello message) Console.WriteLine($"Message is {message.Who}");

            return Service.Done;
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
            var config = ServiceFactory.CreateConfig<Service1>("Service1");

            var serviceId = ServiceFactory.Create(config);
            serviceId.SendMessage(new Hello
            {
                Who = "MicroService"
            });

            Thread.Sleep(10000);
        }
    }
}