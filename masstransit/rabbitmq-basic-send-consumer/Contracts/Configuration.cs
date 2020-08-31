using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace Contracts
{
    public static class Configuration
    {
        public static IBusControl
            ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
            => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri(Constants.Uri), hst =>
                    {
                        hst.Username(Constants.Username);
                        hst.Password(Constants.Password);
                    });

                    registrationAction?.Invoke(cfg, host);
                });
    }
}
