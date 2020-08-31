using Contracts;
using MassTransit;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class CreateWeatherForecastConsumer
        : IConsumer<ICreateWeatherForecastCommand>
    {
        public Task Consume(ConsumeContext<ICreateWeatherForecastCommand> context)
        {
            var message = context.Message;
            System.Console.WriteLine($"{message.Id} {message.Name}");
            return Task.CompletedTask;
        }
    }
}
