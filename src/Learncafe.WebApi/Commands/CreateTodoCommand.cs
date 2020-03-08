using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learncafe.WebApi.Responses;
using MediatR;

namespace Learncafe.WebApi.Commands
{
    public class CreateTodoCommand : IRequest<CreateTaskResponse>
    {
        public String TaskName { get; set; }
    }
}
