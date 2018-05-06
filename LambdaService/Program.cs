using System;
using System.Threading.Tasks;
using Wrapper;

namespace LambdaService
{
//    public class Service1 : IService
//    {
//        
//    }

    public class Service1 : IService
    {
        public Task ReceiveAsync(IContext context) => Service.Done;
    }

    static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
            var config = ServiceFactory.CreateConfig<Service1>();

            var serviceId = ServiceFactory.Create(config);
//            serviceId.SendMessage(new Hello
//            {
//                Who = "MicroService";
//            });
        }
    }
}