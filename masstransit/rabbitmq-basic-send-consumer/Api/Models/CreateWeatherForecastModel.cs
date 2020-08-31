using Contracts;

namespace Api.Models
{
    public class CreateWeatherForecastModel
        : ICreateWeatherForecastCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
