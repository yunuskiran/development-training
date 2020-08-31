using System;

namespace Contracts
{
    public interface IRegisterWeatherForecastEvent
    {
        Guid EventId { get; set; }
    }
}
