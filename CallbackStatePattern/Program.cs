using Core.Interfaces;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CallbackStatePattern.Interfaces;
using CallbackStatePattern.Services;

namespace CallbackStatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                Console.Write("Callback State Pattern");

                var service = scope.Resolve<IConnectionService>();

                while (service.Continue)
                {
                    var key = Console.ReadKey();
                    service.HandleKeyPress(key.KeyChar);
                }

                Console.WriteLine("Finished");
                Console.ReadLine();
            }
        }
    }
}
