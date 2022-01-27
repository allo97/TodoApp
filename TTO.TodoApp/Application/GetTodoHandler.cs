using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TTO.TodoApp.Domain;

namespace TTO.TodoApp.Application
{
    public class GetTodoHandler: IRequestHandler<GetTodo, Todo>
    {
        private readonly ITodoRepository _todoRepository;

        public GetTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> Handle(GetTodo request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetAsync(request.Id);
            return todo;
        }
    }
}
