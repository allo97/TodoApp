using Microsoft.EntityFrameworkCore;
using TTO.TodoApp.Domain;

namespace TTO.TodoApp.Infrastructure.Ef
{
    public class TodoDbContext: DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
