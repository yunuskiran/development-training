namespace Contracts
{
    public interface ICreateWeatherForecastCommand
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
