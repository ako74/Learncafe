using System.Diagnostics;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Learncafe.WebApi.Messages
{
    public class MessageBus : IMessageBus
    {
        private readonly IBus _bus;
        private readonly ILogger<MessageBus> _logger;

        public MessageBus(IBus bus, ILogger<MessageBus> logger)
        {
            this._bus = bus ?? throw new System.ArgumentNullException(nameof(bus));
            this._logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task Send<T>(T message) where T : class
        {
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation($"Starting send message={message}");
            await _bus.Send(message);
            stopwatch.Stop();
            _logger.LogInformation($"Finished send message={message} in {stopwatch.Elapsed.Seconds}sec.");
        }

        public async Task Publish<T>(T message) where T : class
        {
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation($"Starting publish message={message}");
            await _bus.Publish(message);
            stopwatch.Stop();
            _logger.LogInformation($"Finished publish message={message} in {stopwatch.Elapsed.Seconds}sec.");
        }
    }
}