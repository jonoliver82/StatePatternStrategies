using Autofac;
using Core.Interfaces;
using Core.Services;
using SequentialPattern.Interfaces;
using SequentialPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AssignableTo<ITestState>().AsImplementedInterfaces();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                Console.Write("Sequential State Pattern");

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
