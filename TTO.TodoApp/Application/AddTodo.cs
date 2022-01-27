using System;
using MediatR;

namespace TTO.TodoApp.Application
{
    public record AddTodo(Guid Id, string Text, bool IsCompleted) : IRequest;
}
