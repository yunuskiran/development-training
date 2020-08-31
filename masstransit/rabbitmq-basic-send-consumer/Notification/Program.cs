using Contracts;
using MassTransit;
using Notification.Models;
using System;

namespace Notification
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Configuration.ConfigureBus((configuration, host) =>
             {
                 configuration.ReceiveEndpoint(Constants.WeatherForecastServiceQueue, e =>
                 {
                     e.Consumer<CreateWeatherForecastConsumer>();
                 });
             });

            bus.Start();
            Console.WriteLine("Begin Consume");
            Console.ReadLine();
        }
    }
}
