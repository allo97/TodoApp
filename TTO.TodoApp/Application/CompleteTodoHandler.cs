using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TTO.TodoApp.Domain;

namespace TTO.TodoApp.Application
{
    public class CompleteTodoHandler: IRequestHandler<CompleteTodo>
    {
        private readonly ITodoRepository _todoRepository;

        public CompleteTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(CompleteTodo request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetAsync(request.Id);

            if (todo is null)
                throw new Exception($"Todo with id {request.Id} not found.");

            todo.Complete();
            return Unit.Value;
        }
    }
}
