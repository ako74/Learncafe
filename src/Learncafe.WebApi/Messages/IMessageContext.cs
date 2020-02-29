using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Messages
{
    public interface IMessageContext
    {
    }

    public interface ITaskToProcess : IMessageContext
    {
        string TaskName { get; set; }
    }

    public class TaskToProcess : ITaskToProcess
    {
        public string TaskName { get; set; }
    }
}
