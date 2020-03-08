using Learncafe.WebApi.Mapping;
using Learncafe.WebApi.Queries;
using Learncafe.WebApi.Responses;
using Learncafe.WebApi.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Handlers
{
    public class GetTodosHandler : IRequestHandler<GetTodosQuery, List<GetTodoResponse>>
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public GetTodosHandler(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<GetTodoResponse>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _todoService.GetTodos();
            return _mapper.MapTodoTaskDtoToGetTodoResponse(todos.ToList());
        }
    }


}
