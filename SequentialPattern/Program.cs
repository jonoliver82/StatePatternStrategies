using Autofac;
using Core.Interfaces;
using Core.Services;
using SequentialPattern.Factories;
using SequentialPattern.Interfaces;
using SequentialPattern.Services;
using System;
using System.Reflection;

namespace SequentialPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterType<SequentialStateFactory>().As<ISequentialStateFactory>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AssignableTo<ITestState>().AsImplementedInterfaces();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                Console.WriteLine("Sequential State Pattern");

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
