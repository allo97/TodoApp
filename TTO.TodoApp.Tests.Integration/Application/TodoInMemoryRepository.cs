using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TTO.TodoApp.Domain;

namespace TTO.TodoApp.Tests.Integration.Application
{
    internal class TodoInMemoryRepository: ITodoRepository
    {
        private readonly List<Todo> _todos
            = new List<Todo>(10);

        public Task AddAsync(Todo todo, CancellationToken cancellationToken)
        {
            _todos.Add(todo);
            return Task.CompletedTask;
        }

        public Task<Todo> GetAsync(Guid id)
        {
            var todo = _todos
                .SingleOrDefault(x => x.Id.Equals(id));
            return Task.FromResult(todo);
        }
    }
}
