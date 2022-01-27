using System;
using System.Threading;
using System.Threading.Tasks;

namespace TTO.TodoApp.Domain
{
    public interface ITodoRepository
    {
        Task AddAsync(Todo todo, CancellationToken cancellationToken);
        Task<Todo> GetAsync(Guid id);
    }
}
