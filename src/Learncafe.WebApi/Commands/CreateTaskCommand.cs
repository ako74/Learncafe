using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Learncafe.WebApi.Commands
{
    public class CreateTaskCommand : IRequest<CreateTaskResponse>
    {
        public String TaskName { get; set; }
    }
}
