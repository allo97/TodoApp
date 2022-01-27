using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TTO.TodoApp.Domain;

namespace TTO.TodoApp.Application
{
    public class AddTodoHandler: IRequestHandler<AddTodo>
    {
        private readonly ITodoRepository _todoRepository;

        public AddTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(AddTodo request, CancellationToken cancellationToken)
        {
            var todo = new Todo(request.Id, request.Text, request.IsCompleted);
            await _todoRepository.AddAsync(todo, cancellationToken);
            return Unit.Value;
        }
    }
}
