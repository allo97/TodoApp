using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TTO.TodoApp.Domain;

namespace TTO.TodoApp.Infrastructure.Ef
{
    internal class TodoRepository: ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Todo todo, CancellationToken cancellationToken)
        {
            await _dbContext
                .Todos
                .AddAsync(todo, cancellationToken);
            await _dbContext
                .SaveChangesAsync(cancellationToken);
        }

        public Task<Todo> GetAsync(Guid id)
        {
            return _dbContext
                .Todos
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
