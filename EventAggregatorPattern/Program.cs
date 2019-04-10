using Autofac;
using Core.Interfaces;
using Core.Services;
using EventAggregatorPattern.Factories;
using EventAggregatorPattern.Interfaces;
using EventAggregatorPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
            builder.RegisterType<EventAggregatorService>().As<IEventAggregatorService>().SingleInstance();
            builder.RegisterType<StateFactory>().As<IStateFactory>();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                Console.WriteLine("Event Aggregator Pattern");

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
