using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TTO.TodoApp.Domain;
using TTO.TodoApp.Infrastructure.Ef;

namespace TTO.TodoApp.Infrastructure
{
    public static class RegisterExtensions
    {
        internal static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddDbContext<TodoDbContext>(options =>
                {
                    options.UseInMemoryDatabase("Todos");
                })
                .AddTransient<ITodoRepository, TodoRepository>();
        }
    }
}
