using System;
using MediatR;

namespace TTO.TodoApp.Application
{
    public record CompleteTodo(Guid Id) : IRequest;
}
