using Learncafe.WebApi.Responses;
using MediatR;
using System.Collections.Generic;

namespace Learncafe.WebApi.Queries
{
    public class GetTodosQuery : IRequest<List<GetTodoResponse>>
    {
    }
}
