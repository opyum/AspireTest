using MassTransit;
namespace SagaPattern.InventoryService
{


    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new { Value = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
