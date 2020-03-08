using Learncafe.WebApi.Commands;
using Learncafe.WebApi.Messages;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTodoCommand, CreateTaskResponse>
    {
        private readonly IMessageBus _bus;

        public CreateTaskHandler(IMessageBus bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        public  Task<CreateTaskResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var message = new TaskToProcess() { TaskName = request.TaskName };

            var result = _bus.Publish<TaskToProcess>(message);

            var response = new CreateTaskResponse() { TaskName = request.TaskName };
            return Task.FromResult(response);
        }


    }
}
