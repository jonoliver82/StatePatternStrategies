using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using RaiseEventPattern.Interfaces;
using Core.Services;
using Core.Interfaces;
using RaiseEventPattern.Services;

namespace RaiseEventPattern
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
                Console.Write("Raise Event Pattern");

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
