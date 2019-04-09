using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using StatePattern.Interfaces;
using StatePattern.Services;
using StatePattern.Strategies;
using System.Reflection;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConnectionService>().As<IConnectionService>().SingleInstance();
            builder.RegisterType<EventAggregatorService>().As<IEventAggregatorService>().SingleInstance();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            //builder.RegisterType<CallbackToControllerStateTransitionStrategy>().As<IStateTransitionStrategy>();
            //builder.RegisterType<RaiseEventStateTransitionStrategy>().As<IStateTransitionStrategy>();
            //builder.RegisterType<EventAggregatorStateTransitionStrategy>().As<IStateTransitionStrategy>();
            builder.RegisterType<SequentialStateTransitionStrategy>().As<IStateTransitionStrategy>();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AssignableTo<ITestState>().AsImplementedInterfaces();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IConnectionService>();
                
                while(service.Continue)
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
