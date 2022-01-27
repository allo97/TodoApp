using System;
using MediatR;
using TTO.TodoApp.Domain;

namespace TTO.TodoApp.Application
{
    public record GetTodo(Guid Id) : IRequest<Todo>;
}
