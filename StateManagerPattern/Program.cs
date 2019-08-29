using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateManagerPattern.Interfaces;
using StateManagerPattern.States;
using Autofac;
using Core.Services;
using Core.Interfaces;
using Core.Adapters;
using Core.Models;
using StateManagerPattern.Factories;
using StateManagerPattern.Services;

namespace StateManagerPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DateTimeAdapter>().As<IDateTimeService>();
            //builder.RegisterType<StateManager>().As<IStateManager>().SingleInstance();
            builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
            builder.RegisterType<StateFactory>().As<IStateFactory>();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                Console.WriteLine("State Manager Pattern");

                var service = scope.Resolve<IConnectionService>();

                while (service.Continue)
                {
                    var key = Console.ReadKey();
                    service.HandleKeyPress(key.KeyChar);
                }

                Console.WriteLine("Finished");
                Console.ReadLine();
            }



            //var container = builder.Build();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    Console.WriteLine("State Manager Pattern");
            //    Console.WriteLine("Press Q to quit, or spacebar to transition");

            //    var stateManager = scope.Resolve<IStateManager>();

            //    var key = new ConsoleKeyInfo();
            //    while (key.Key != ConsoleKey.Q)
            //    {
            //        key = Console.ReadKey();
            //        stateManager.Update(key.Key);
            //    }

            //    Console.WriteLine("Finished");
            //    Console.ReadLine();
            //}
        }
    }
}
