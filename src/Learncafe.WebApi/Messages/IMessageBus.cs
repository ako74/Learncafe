using System.Threading.Tasks;

namespace Learncafe.WebApi.Messages
{
    public interface IMessageBus
    {
        Task Send<T>(T message) where T : class;

        Task Publish<T>(T message) where T : class;
    }
}