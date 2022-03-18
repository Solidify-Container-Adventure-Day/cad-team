using Cad.MiningApp.Core.Interfaces;
using Cad.MiningApp.Core.Model;

namespace Cad.MiningApp.Api
{
    public class MinerService : IHostedService, IDisposable
    {
        private readonly IServiceProvider services;
        private Timer _timer = null!;

        public MinerService(IServiceProvider services)
        {
            this.services = services;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async void DoWork(object? state)
        {
            using var scope = services.CreateScope();
            var miningLogsRepository = scope.ServiceProvider.GetRequiredService<IMiningLogsRepository>();

            var miningLog = new MiningLog
            {
                Quantity = 1,
                ResourceType = 0,
                CompletedOn = DateTimeOffset.Now
            };
            await miningLogsRepository.AddAsync(miningLog);
        }
    }
}
